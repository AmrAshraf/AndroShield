#pragma once
using namespace System;
namespace DynamicAnalysis
{
	public ref class UserSimulator
	{
		String^ emulatorPath = "C:\\androidEmulator\\emulator\\emulator.exe";
		String^ emulatorName = "Nexus_5X_google_API_26";
		String^ outputDir = "C:\\GPTempDir";
		//String^ droidbotPath = "C:\\Python27\\Scripts\\droidbot.exe";
		String^ droidbotPath = "droidbot";
		String^ outputPath;
	public:
		UserSimulator();
		void runEmulator();
		void startSimulation(String^ apkPath, int numberOfEvents);
		String^ getLogcatPath();
		void removeOutputFolder();

	};

}