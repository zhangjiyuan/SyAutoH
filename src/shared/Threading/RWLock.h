

#ifndef RWLOCK_H
#define RWLOCK_H

#include "Mutex.h"

class RWLock
{
	public:
		inline void AcquireReadLock()
		{
			_lock.Acquire();
		}

		inline void ReleaseReadLock()
		{
			_lock.Release();
		}

		inline void AcquireWriteLock()
		{
			_lock.Acquire();
		}

		inline void ReleaseWriteLock()
		{
			_lock.Release();
		}

	private:
		Mutex _lock;
};

#endif
