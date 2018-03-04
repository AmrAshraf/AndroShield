#pragma once

using namespace System::Collections::Generic;
using namespace System::Xml;

#include"Vulnerability.h"
using namespace Types;
namespace TaintAnalysis{
public ref class TaintAnalyser
{
private : 
	void changeApkPathInConfigurationFile(String^ apkPath);
	void extractTaintData();
public:
	TaintAnalyser(String^ apkPath);
	property List<Vulnerability>^ vulnerabilities;
	
};
}

