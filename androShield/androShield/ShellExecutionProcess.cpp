#include <windows.h>
#include "ShellExecutionProcess.h"


ShellExecutionProcess::ShellExecutionProcess(const char* command) //  add /C before command while using paths
{
	SHELLEXECUTEINFO ShExecInfo = { 0 };
	ShExecInfo.cbSize = sizeof(SHELLEXECUTEINFO);
	ShExecInfo.fMask = SEE_MASK_NOCLOSEPROCESS;
	ShExecInfo.hwnd = NULL;
	ShExecInfo.lpVerb = NULL;
	ShExecInfo.lpFile = "cmd";
	ShExecInfo.lpParameters = command;
	ShExecInfo.lpDirectory = "C:\\";
	ShExecInfo.nShow = SW_SHOW;   //for debugging
	//ShExecInfo.nShow = SW_HIDE;
	ShExecInfo.hInstApp = NULL;
	ShellExecuteEx(&ShExecInfo);
	WaitForSingleObject(ShExecInfo.hProcess, INFINITE);
}


ShellExecutionProcess::~ShellExecutionProcess()
{
}
