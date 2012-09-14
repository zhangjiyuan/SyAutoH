#ifndef ATOMICBOOLEAN_HPP__
#define ATOMICBOOLEAN_HPP__

class AtomicULong
{
public:
	AtomicULong() { Value = 0; }

	AtomicULong(unsigned long InitialValue) { Value = InitialValue; }

	////////////////////////////////////////////////////////////
	//unsigned long SetVal( unsigned long NewValue )
	// lockless threadsafe set operation on the contained value
	//
	// Parameters
	//  unsigned long val  -  value to be set
	//
	// Return values
	//  Returns the initial value contained
	///////////////////////////////////////////////////////////
	unsigned long SetVal(unsigned long NewValue)
	{
		unsigned long ret = 0;
		ret = InterlockedExchange(reinterpret_cast< volatile LONG* >(&Value), LONG(NewValue));
		return ret;
	}


	///////////////////////////////////////////////////////////
	//unsigned long GetVal()
	// non-threadsafe get operation on the contained value
	//
	// Parameters
	//  None
	//
	// Return values
	//  Returns the value contained
	//////////////////////////////////////////////////////////
	unsigned long GetVal() { return Value; }


private:
	// Disabled copy constructor
	AtomicULong(const AtomicULong & other) {}

	// Disabled assignment operator
	AtomicULong operator=(AtomicULong & other) { return *this; }


protected:

#ifdef WIN32
	__declspec(align(4))  volatile unsigned long Value;
#else
	volatile unsigned long Value;
#endif
};
	//////////////////////////////////////////////////////
	//class AtomicBoolean
	//  Stores a Boolean atomically, using an AtomicULong
	//
	//////////////////////////////////////////////////////
	class AtomicBoolean
	{

		public:
			AtomicBoolean() : Value(0) {}

			AtomicBoolean(bool val)
			{
				if(val)
					Value.SetVal(1);
				else
					Value.SetVal(0);
			}

			////////////////////////////////////////////////////////////
			//bool SetVal( bool val )
			// lockless threadsafe set operation on the contained value
			//
			// Parameters
			//  bool val  -  value to be set
			//
			// Return values
			//  Returns the initial value contained
			///////////////////////////////////////////////////////////
			bool SetVal(bool val)
			{
				unsigned long oldval = 0;

				if(val)
					oldval = Value.SetVal(1);
				else
					oldval = Value.SetVal(0);

				return (oldval & 1);
			}


			///////////////////////////////////////////////////////////
			//bool GetVal()
			// non-threadsafe get operation on the contained value
			//
			// Parameters
			//  None
			//
			// Return values
			//  Returns the value contained
			//////////////////////////////////////////////////////////
			bool GetVal()
			{
				unsigned long val = 0;

				val = Value.GetVal();

				return (val & 1);
			}

		private:
			// Disabled copy constructor
			AtomicBoolean(const AtomicBoolean & other) {}

			// Disabled assignment operator
			AtomicBoolean operator=(const AtomicBoolean & other) { return *this; }

			AtomicULong Value;
	};

#endif
