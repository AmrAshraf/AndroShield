#include <msclr/marshal.h>
#include "Emulator.h"
#include"ShellExecutionProcess.h"

namespace DynamicAnalysis
{

	Emulator::Emulator()
	{
	}
	void Emulator::runEmulator(String^ emulatorName ) //pass null to run out default one
	{
		if (emulatorName == nullptr)
			emulatorName = "Nexus_4_API_26_NoSkin";
		String^ command = "/C start /b " + emulatorPath + " -avd " + emulatorName;
		msclr::interop::marshal_context context;
		ShellExecutionProcess shellExecutionProcess(context.marshal_as<const char*>(command));
	}
	void Emulator::killEmulator()
	{
		String^ command = "/C adb emu kill";
		msclr::interop::marshal_context context;
		ShellExecutionProcess shellExecutionProcess(context.marshal_as<const char*>(command));
		
	}
}