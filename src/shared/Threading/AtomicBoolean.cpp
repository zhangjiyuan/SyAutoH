#include "stdafx.h"
#include "Common.h"

namespace syamhs
{
	namespace Threading
	{

		bool AtomicBoolean::SetVal(bool val)
		{
			unsigned long oldval = 0;

			if(val)
				oldval = Value.SetVal(1);
			else
				oldval = Value.SetVal(0);

			return (oldval & 1);
		}
	}
}