#pragma once
using namespace System;
namespace DynamicAnalysis
{
	public ref class UserSimulator
	{

		String^ outputDir = "C:\\GPTempDir";
		String^ droidbotPath = "droidbot";
		String^ outputPath;
	public:
		UserSimulator();
		void startSimulation(String^ apkPath, int numberOfEvents);
		String^ getLogcatPath();
		void removeOutputFolder();

	};

}