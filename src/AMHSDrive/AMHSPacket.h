#pragma once

#include "../shared/ByteBuffer.h"

class AMHSPacket : public ByteBuffer
{
public:
	__inline AMHSPacket() : ByteBuffer(), m_opcode(0) { }
	__inline AMHSPacket(uint32 opcode, size_t res) : ByteBuffer(res), m_opcode(opcode) {}
	__inline AMHSPacket(size_t res) : ByteBuffer(res), m_opcode(0) { }
	__inline AMHSPacket(const AMHSPacket & packet) : ByteBuffer(packet), m_opcode(packet.m_opcode) {}

	//! Clear packet and set opcode all in one mighty blow
	__inline void Initialize(uint32 opcode)
	{
		clear();
		m_opcode = opcode;
	}

	__inline uint32 GetOpcode() const { return m_opcode; }
	__inline void SetOpcode(uint32 opcode) { m_opcode = opcode; }

protected:
	uint32 m_opcode;
};

