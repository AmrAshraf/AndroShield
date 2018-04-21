#pragma once
using namespace System::Collections::Generic;
#include"Vulnerability.h"
using namespace Types;
namespace DynamicAnalysis
{
	public ref class HttpRequestsDetector
	{
	public:
		HttpRequestsDetector(String^ logcatPath);
		void detectHttp(String^ logcatPath);
		Vulnerability inSecureVulnerability;
	};
}
