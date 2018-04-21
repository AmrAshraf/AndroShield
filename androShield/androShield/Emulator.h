#pragma once
using namespace System;
namespace DynamicAnalysis
{

	public ref class Emulator
	{
	private:
		String^ emulatorPath = "C:\\androidEmulator\\emulator\\emulator.exe";
		String^ emulatorName = "Nexus_5X_google_API_26";
	public:
		Emulator();
		void runEmulator(String^ emulatorName );
		void killEmulator();
	};

}