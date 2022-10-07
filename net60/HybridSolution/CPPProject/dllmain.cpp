// dllmain.cpp : Implementation of DllMain.

#include "pch.h"
#include "framework.h"
#include "resource.h"
#include "CPPProject_i.h"
#include "dllmain.h"

CCPPProjectModule _AtlModule;

// DLL Entry Point
extern "C" BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID lpReserved)
{
	hInstance;
	return _AtlModule.DllMain(dwReason, lpReserved);
}
