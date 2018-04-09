#include "IntentCrashesDetector.h"
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;

namespace DynamicAnalysis
{
	IntentCrashesDetector::IntentCrashesDetector(String ^ logfilePath)
	{
		grabCrashes(logfilePath);
	}
	void IntentCrashesDetector::grabCrashes(String ^ fileLocation)
	{
		List<String^>^ crashesInfo = gcnew List<String^>();
		String^ SPattern = " E AndroidRuntime: FATAL EXCEPTION:";

		FileStream^ FS = gcnew FileStream(fileLocation, FileMode::Open);
		StreamReader^ SR = gcnew StreamReader(FS);
		String^ line;

		while (SR->Peek() != -1)
		{
			line = SR->ReadLine();

			if (line->Contains(SPattern))
			{
				String^ error = "";
				while (SR->Peek() != -1)
				{
					line = SR->ReadLine();
					if (line->Contains(" E AndroidRuntime:"))
					{	
						array<String^>^ errorLine= line->Split(gcnew array<String^>{ " E AndroidRuntime:" }, StringSplitOptions::RemoveEmptyEntries);
						error += errorLine[1] + Environment::NewLine;
					}
					else
					{
						crashesInfo->Add(error);
						break;
					}
				}
			}


		}
		SR->Close();
		vulnerabilities = gcnew List<Vulnerability>();
		for each (String^ err in crashesInfo)
		{
			//create new vulnerability
			Vulnerability vul;
			vul.extraInfo = err;
			vul.type = "dynamic";
			vul.category = "Intent Crash";
			vul.severity = 0.9;
			vulnerabilities->Add(vul);
			
		}
		
	}
}