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
			//std::cout.write(read_msg_.body(), read_msg_.body_length());
			//std::cout << "\n";
			int mOpcode = read_msg_.command();
			int mSize = read_msg_.body_length();
			AMHSPacket* Packet;
			Packet = new AMHSPacket(static_cast<uint16>(mOpcode), mSize);
			Packet->resize(mSize);

			memcpy((void*)Packet->contents(), read_msg_.body(), mSize);
			if (m_pHandleCommand != NULL)
			{
				m_pHandleCommand(m_pVirtualDevice, Packet);
			}
			delete Packet;

			/*switch(mOpcode)
			{
			case OHT_MCS_STATUS_BACK_TIME:
			{
			uint8 nID = 0;
			uint8 nTime = 0;
			*Packet >> nID;
			*Packet >> nTime;
			printf("OHT Status Back Time:  %d Time %d\n", nID, nTime);
			delete Packet;
			}
			break;
			case OHT_MCS_ACK_AUTH:
			{

			}
			break;
			case STK_MCS_ACK_AUTH:
			{
			uint8 nID = 0;
			uint8 nAuthRes = 0;
			uint64 uTime = 0;
			*Packet >> nID;
			*Packet >> nAuthRes;
			*Packet >> uTime;
			__time64_t tTime;
			memcpy(&tTime, &uTime, 8);

			printf("Stocker %d Auth %d SysTime: %s\n", nID, nAuthRes, _ctime64( &tTime ));
			delete Packet;
			}
			break;
			default:
			{
			delete Packet;
			}
			break;
			}*/




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