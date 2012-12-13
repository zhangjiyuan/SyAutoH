#include "StdAfx.h"
#include "amhs_dev_server.h"

amhs_session::amhs_session(boost::asio::io_service& io_service, amhs_room& room)
	: socket_(io_service),
	room_(room)
{
	nDevType_ = DEV_TYPE_UNKNOW;
	nID_ = -1;
}

tcp::socket& amhs_session::socket()
{
	return socket_;
}

void amhs_session::PutSocketInfo(tcp::socket& socket_)
{
	tcp::socket::endpoint_type ep = socket_.remote_endpoint();
	sIP_ = ep.address().to_string();
	uPort_ = ep.port();
	std::cout<< "socket IP: " << sIP_ << " Port: " << uPort_ << std::endl;
}

void amhs_session::start()
{
	room_.join(shared_from_this());
	boost::asio::async_read(socket_,
		boost::asio::buffer(read_msg_.data(), amhs_message::header_length),
		boost::bind(
		&amhs_session::handle_read_header, shared_from_this(),
		boost::asio::placeholders::error));

	PutSocketInfo(socket_);
}

void amhs_session::deliver(const amhs_message& msg)
{
	bool write_in_progress = !write_msgs_.empty();
	write_msgs_.push_back(msg);
	if (!write_in_progress)
	{
		boost::asio::async_write(socket_,
			boost::asio::buffer(write_msgs_.front().data(),
			write_msgs_.front().length()),
			boost::bind(&amhs_session::handle_write, shared_from_this(),
			boost::asio::placeholders::error));
	}
}

void amhs_session::handle_read_header(const boost::system::error_code& error)
{
	if (!error && read_msg_.decode_header())
	{
		//printf("Decode ");
		//read_msg_.Header_HexLike();
		boost::asio::async_read(socket_,
			boost::asio::buffer(read_msg_.body(), read_msg_.max_body_length), //OHT
			//boost::asio::buffer(read_msg_.body(), read_msg_.body_length()), //STK
			boost::bind(&amhs_session::handle_read_body, shared_from_this(),
			boost::asio::placeholders::error));
	}
	else
	{
		room_.leave(shared_from_this());
	}
}

void amhs_session::handle_read_body(const boost::system::error_code& error)
{
	// TODO: need message index check for packet sequence
	if (!error)
	{
		int mOpcode = read_msg_.command();
		int mSize = read_msg_.body_length();
		bool bXor = read_msg_.CheckXOR();
		if (false == bXor)
		{
		cout << "Server XOR error" << endl;

		boost::asio::async_read(socket_,
		boost::asio::buffer(read_msg_.data(), amhs_message::header_length),
		boost::bind(&amhs_session::handle_read_header, shared_from_this(),
		boost::asio::placeholders::error));

		return;
		}

		if (mSize > 0)
		{
			AMHSPacket* Packet;
			Packet_Map::iterator it = read_packets_.find(mOpcode);
			if (it != read_packets_.end())
			{
				Packet = it->second;
			}
			else
			{
				Packet = new AMHSPacket(static_cast<uint16>(mOpcode), mSize);
				Packet->resize(0);
				read_packets_.insert(std::make_pair(mOpcode, Packet));
			}

			if (read_msg_.IsLast() == 1)
			{
				Packet_Map::iterator it = read_packets_.find(mOpcode);
				if (it != read_packets_.end())
				{
					read_packets_.erase(it);
				}

				Packet->append(read_msg_.body(), mSize);

				int nDecode = room_.DecodePacket(shared_from_this(), *Packet);	
				if (nDecode < 0)
				{
					printf("Decode failed. Not processer. \n");
				}

				delete Packet;
			}
			else
			{
				Packet->append(read_msg_.body(), mSize);
			}
		}

		boost::asio::async_read(socket_,
			boost::asio::buffer(read_msg_.data(), amhs_message::header_length),
			boost::bind(&amhs_session::handle_read_header, shared_from_this(),
			boost::asio::placeholders::error));
	}
	else
	{
		room_.leave(shared_from_this());
	}
}

void amhs_session::handle_write(const boost::system::error_code& error)
{
	if (!error)
	{
		write_msgs_.pop_front();
		if (!write_msgs_.empty())
		{
			boost::asio::async_write(socket_,
				boost::asio::buffer(write_msgs_.front().data(),
				write_msgs_.front().length()),
				boost::bind(&amhs_session::handle_write, shared_from_this(),
				boost::asio::placeholders::error));
		}
	}
	else
	{
		room_.leave(shared_from_this());
	}

}