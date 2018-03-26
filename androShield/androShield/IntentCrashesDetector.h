#pragma once

using namespace System::Collections::Generic;
#include"Vulnerability.h"
using namespace Types;

namespace DynamicAnalysis
{
	public ref class IntentCrashesDetector
	{
	public:
		IntentCrashesDetector(String ^ logfilePath);
		void grabCrashes(String^ fileLocation);
		property List<Vulnerability>^ vulnerabilities;
	};
}