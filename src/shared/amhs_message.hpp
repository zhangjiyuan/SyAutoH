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
		nIndex(1),
		nIsLast(1),
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

	uint8 hash_xor_body()
	{
		uint8 uhash = 0;
		uint8* pData = body();
		for (size_t i=0; i<body_length_; i++)
		{
			uhash ^= *pData++;
		}

		return uhash;
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

	bool CheckXOR()
	{
		uint8 hash = hash_xor_body();
		if (hXor == hash)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	uint32 command() const { return cmd_; }
	void command(uint32 val) { cmd_ = val; }

	bool IsNeedRespond() const { return isNeedRespond_; }
	void IsNeedRespond(bool val) { isNeedRespond_ = val; }

	bool IsRespond() const { return isRespond_; }
	void IsRespond(bool val) { isRespond_ = val; }

	void Header_HexLike()
	{
		AMHSPktHeader PktHeader;
		memcpy(&PktHeader, data_, header_length);
		int nSize = sizeof(AMHSPktHeader);
		uint8* pData = (uint8*)&PktHeader;
		printf("Decode Header: ");
		for (int i=0; i<nSize; i++)
		{
			printf("%02X ", *pData++);
		}
		printf("\r\n");

	}

	bool decode_header()
	{
		AMHSPktHeader PktHeader;
		memcpy(&PktHeader, data_, header_length);
		uint8 comm = PktHeader.comm;
		isRespond_ = (comm & 0x80 ? true : false);
		isNeedRespond_ = (comm & 0x40 ? true : false);
		cmd_ = PktHeader.cmd;
		body_length_ = PktHeader.size;
		nIndex = PktHeader.index;
		nIsLast = PktHeader.bLast;
		
		if (body_length_ > max_body_length)
		{
			body_length_ = 0;
			return false;
		}

		hXor = PktHeader.check;

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
			comm |= 0x02;
		}

		if (isRespond_)
		{
			comm |= 0x01;
		}
		PktHeader.comm = comm;

		PktHeader.index = nIndex;
		PktHeader.bLast = nIsLast;
		PktHeader.check = hash_xor_body();

		memcpy(data_, &PktHeader, header_length);

		Header_HexLike();
	}
	
	uint8 IsLast() const { return nIsLast; }
	void IsLast(uint8 val) { nIsLast = val; }
	uint16 Index() const { return nIndex; }
	void Index(uint16 val) { nIndex = val; }
	uint8 Xor() const { return hXor; }

private:
	uint8 data_[header_length + max_body_length];
	
	bool isNeedRespond_;
	bool isRespond_;
	uint32 cmd_;
	size_t body_length_;
	uint16 nIndex;
	uint8   nIsLast;
	uint8  hXor;
};
