#include "stdafx.h"
#include "AtomicCounter.h"

namespace syamhs
{
	namespace Threading
	{

		unsigned long AtomicCounter::operator++()
		{
			unsigned long val = 0;

			val = InterlockedIncrement(reinterpret_cast< volatile LONG* >(&Value));

			return val;
		}

		unsigned long AtomicCounter::operator--()
		{
			unsigned long val = 0;

			val = InterlockedDecrement(reinterpret_cast< volatile LONG* >(&Value));

			return val;
		}

	}
}