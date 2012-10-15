#pragma once

#include "OptCodes.h"
class amhs_message
{
public:
	enum { header_length = sizeof(AMHSPktHeader) };
	enum { max_body_length = 512 };

	amhs_message()
		: body_length_(0),
		cmd_(0),
		isNeedRespond_(false),
		isRespond_(false)
	{
	}

	const uint8* data() const
	{
		return data_;
	}

	uint8* data()
	{
		return data_;
	}

	size_t length() const
	{
		return header_length + body_length_;
	}

	const uint8* body() const
	{
		return data_ + header_length;
	}

	uint8* body()
	{
		return data_ + header_length;
	}

	size_t body_length() const
	{
		return body_length_;
	}

	void body_length(size_t new_length)
	{
		body_length_ = new_length;
		if (body_length_ > max_body_length)
			body_length_ = max_body_length;
	}

	uint32 command() const { return cmd_; }
	void command(uint32 val) { cmd_ = val; }

	bool IsNeedRespond() const { return isNeedRespond_; }
	void IsNeedRespond(bool val) { isNeedRespond_ = val; }

	bool IsRespond() const { return isRespond_; }
	void IsRespond(bool val) { isRespond_ = val; }

	bool decode_header()
	{
		AMHSPktHeader PktHeader;
		memcpy(&PktHeader, data_, header_length);
		cmd_ = PktHeader.cmd;
		body_length_ = PktHeader.size;
		uint8 comm = PktHeader.comm;
		isRespond_ = (comm & 0x80 ? true : false);
		isNeedRespond_ = (comm & 0x40 ? true : false);
		if (body_length_ > max_body_length)
		{
			body_length_ = 0;
			return false;
		}
		return true;
	}

	void encode_header()
	{
		AMHSPktHeader PktHeader;
		memset(&PktHeader, 0, header_length);
		PktHeader.cmd = cmd_;
		PktHeader.size = body_length_;
		uint8 comm = 0;
		if (isNeedRespond_)
		{
			comm |= 0x40;
		}

		if (isRespond_)
		{
			comm |= 0x80;
		}
		PktHeader.comm = comm;

		if (body_length_ < 512)
		{
			PktHeader.bLast = 1;
			PktHeader.index = 1;
		}

		memcpy(data_, &PktHeader, header_length);
	}

private:
	uint8 data_[header_length + max_body_length];
	size_t body_length_;
	uint32 cmd_;
	bool isNeedRespond_;
	bool isRespond_;
};
