#pragma once
#include "Singleton.h"

class MMoveCtrlServer;
class MMoveCtrlServer : public Singleton< MMoveCtrlServer >
{
public:
	void Run(int argc, _TCHAR** argv);
	void Stop();
};

