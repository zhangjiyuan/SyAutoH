#pragma once

#include <boost/thread/shared_mutex.hpp>
#include <boost/thread/shared_lock_guard.hpp>

typedef boost::shared_mutex rwmutex;
typedef boost::shared_lock<rwmutex> readLock;
typedef boost::unique_lock<rwmutex> writeLock; 

#define RLock(M)  for(readLock M##_lock = readLock(M); M##_lock; M##_lock.unlock())
#define WLock(M)  for(writeLock M##_lock = writeLock(M); M##_lock; M##_lock.unlock())