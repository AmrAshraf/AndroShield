#include <msclr/marshal.h>
#include "UserSimulator.h"
#include "CurrentTimeString.h"
#include "ShellExecutionProcess.h"

namespace DynamicAnalysis
{

	UserSimulator::UserSimulator()
	{
	}

	void UserSimulator::runEmulator()
	{
		String^ command = "/C start /b " + emulatorPath+ " -avd "+ emulatorName;
		msclr::interop::marshal_context context;
		ShellExecutionProcess shellExecutionProcess(context.marshal_as<const char*>(command));
	}

	void UserSimulator::startSimulation(String^ apkPath,int numberOfEvents)
	{
		
		outputPath = outputDir + "\\droidbot" + CurrentTimeString::getCurrentTime();
		String^ command = "/C "+droidbotPath + " -a "+ apkPath+" -o "+ outputPath+" -random -count "+ numberOfEvents.ToString() +" -is_emulator -interval 1 -timeout "+ (numberOfEvents * 2).ToString() +" -keep_env -grant_perm";
		
		msclr::interop::marshal_context context;
		ShellExecutionProcess shellExecutionProcess(context.marshal_as<const char*>(command));
	}

	String ^ UserSimulator::getLogcatPath()
	{
		return outputPath + "\\logcat.txt";
	}

	void UserSimulator::removeOutputFolder()
	{
		System::IO::Directory::Delete(outputPath, true);
		outputPath = "";
	}

}