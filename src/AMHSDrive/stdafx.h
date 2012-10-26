// stdafx.h : 标准系统包含文件的包含文件，
// 或是经常使用但不常更改的
// 特定于项目的包含文件
//

#pragma once

#include "targetver.h"

#define WIN32_LEAN_AND_MEAN             //  从 Windows 头文件中排除极少使用的信息
// Windows 头文件:
#include <windows.h>
#include <winsock2.h>
#include <ws2tcpip.h>
#include "Common.h"
#include "../shared/Network.h"
#include "../shared/log.h"
#include "../shared/FastQueue.h"
#include "AMHSPacket.h"

#include <boost/bind.hpp>
#include <boost/asio.hpp>
#include <boost/thread/thread.hpp>

// TODO: 在此处引用程序需要的其他头文件
