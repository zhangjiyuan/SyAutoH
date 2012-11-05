#pragma once

using boost::asio::ip::tcp;

typedef std::deque<amhs_message> amhs_message_queue;
typedef void(*ProcessCommand)(void*, AMHSPacket* packet);
class amhs_client
{
public:
	ProcessCommand m_pHandleCommand;
	void* m_pVirtualDevice;
public:
	amhs_client(boost::asio::io_service& io_service,
		tcp::resolver::iterator endpoint_iterator)
		: io_service_(io_service),
		socket_(io_service)
	{
		boost::asio::async_connect(socket_, endpoint_iterator,
			boost::bind(&amhs_client::handle_connect, this,
			boost::asio::placeholders::error));
		m_pHandleCommand = NULL;
	}

	void write_packet(AMHSPacket& packet)
	{
		size_t szLen = packet.size();
		size_t szLimit = amhs_message::max_body_length;
		int nLoop = szLen / szLimit + 1;
		
		size_t szPacketLen = 0;
		for (int i=0; i<nLoop; i++)
		{
			amhs_message msg;
			msg.Index(i+1);
			if ((i+1) < nLoop)
			{
				msg.IsLast(0);
			}
			else
			{
				msg.IsLast(1);
			}
			if (szLen > szLimit)
			{
				szPacketLen = szLimit;
				szLen -= szLimit;
			}
			else
			{
				szPacketLen = szLen;
			}
			msg.command(packet.GetOpcode());
			msg.body_length(szPacketLen);
			msg.IsNeedRespond(true);
			memcpy(msg.body(), packet.contents() + (i*szLimit), msg.body_length());
			msg.encode_header();
			write(msg);
		}
		
	}

	void write(const amhs_message& msg)
	{
		io_service_.post(boost::bind(&amhs_client::do_write, this, msg));
	}

	void close()
	{
		io_service_.post(boost::bind(&amhs_client::do_close, this));
	}

private:

	void handle_connect(const boost::system::error_code& error)
	{
		if (!error)
		{
			boost::asio::async_read(socket_,
				boost::asio::buffer(read_msg_.data(), amhs_message::header_length),
				boost::bind(&amhs_client::handle_read_header, this,
				boost::asio::placeholders::error));
		}
		else
		{
			std::cout<< "Cannot connected to server. " << error <<std::endl;
		}
	}

	void handle_read_header(const boost::system::error_code& error)
	{
		if (!error && read_msg_.decode_header())
		{
			boost::asio::async_read(socket_,
				boost::asio::buffer(read_msg_.body(), read_msg_.body_length()),
				boost::bind(&amhs_client::handle_read_body, this,
				boost::asio::placeholders::error));
		}
		else
		{
			do_close();
		}
	}

	void handle_read_body(const boost::system::error_code& error)
	{
		if (!error)
		{
			int mOpcode = read_msg_.command();
			int mSize = read_msg_.body_length();
			bool bXor = read_msg_.CheckXOR();
			if (false == bXor)
			{
				cout << "Cilent XOR error" << endl;

				boost::asio::async_read(socket_,
					boost::asio::buffer(read_msg_.data(), amhs_message::header_length),
					boost::bind(&amhs_client::handle_read_header, this,
					boost::asio::placeholders::error));

				return;
			}

			AMHSPacket* Packet;
			Packet = new AMHSPacket(static_cast<uint16>(mOpcode), mSize);
			Packet->resize(mSize);

			memcpy((void*)Packet->contents(), read_msg_.body(), mSize);
			if (m_pHandleCommand != NULL)
			{
				m_pHandleCommand(m_pVirtualDevice, Packet);
			}
			delete Packet;

			boost::asio::async_read(socket_,
				boost::asio::buffer(read_msg_.data(), amhs_message::header_length),
				boost::bind(&amhs_client::handle_read_header, this,
				boost::asio::placeholders::error));
		}
		else
		{
			do_close();
		}
	}

	void do_write(amhs_message msg)
	{
		bool write_in_progress = !write_msgs_.empty();
		write_msgs_.push_back(msg);
		if (!write_in_progress)
		{
			boost::asio::async_write(socket_,
				boost::asio::buffer(write_msgs_.front().data(),
				write_msgs_.front().length()),
				boost::bind(&amhs_client::handle_write, this,
				boost::asio::placeholders::error));
		}
	}

	void handle_write(const boost::system::error_code& error)
	{
		if (!error)
		{
			write_msgs_.pop_front();
			if (!write_msgs_.empty())
			{
				boost::asio::async_write(socket_,
					boost::asio::buffer(write_msgs_.front().data(),
					write_msgs_.front().length()),
					boost::bind(&amhs_client::handle_write, this,
					boost::asio::placeholders::error));
			}
		}
		else
		{
			do_close();
		}
	}

	void do_close()
	{
		socket_.close();
	}

private:
	boost::asio::io_service& io_service_;
	tcp::socket socket_;
	amhs_message read_msg_;
	amhs_message_queue write_msgs_;
};