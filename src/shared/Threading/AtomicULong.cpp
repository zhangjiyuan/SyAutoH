#include "stdafx.h"
#include "Common.h"

namespace syamhs
{
	namespace Threading
	{

		unsigned long AtomicULong::SetVal(unsigned long NewValue)
		{
			unsigned long ret = 0;

			ret = InterlockedExchange(reinterpret_cast< volatile LONG* >(&Value), LONG(NewValue));

			return ret;

		}

	}
}