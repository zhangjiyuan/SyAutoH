#pragma once
#include "Singleton.h"

class MetaMoveCtrlServer;
class MetaMoveCtrlServer : public Singleton< MetaMoveCtrlServer >
{
public:
	void Run(int argc, _TCHAR** argv);
	void Stop();
};

