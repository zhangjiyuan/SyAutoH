#pragma once

class amhs_message
{
public:
	enum { header_length = sizeof(AMHSPktHeader) };
	enum { max_body_length = 512 };

	amhs_message()
		: body_length_(0),
		cmd_(0)
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

	bool decode_header()
	{
		AMHSPktHeader PktHeader;
		memcpy(&PktHeader, data_, header_length);
		cmd_ = PktHeader.cmd;
		body_length_ = PktHeader.size;
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
		memcpy(data_, &PktHeader, header_length);
	}

private:
	uint8 data_[header_length + max_body_length];
	size_t body_length_;
	uint32 cmd_;

};
