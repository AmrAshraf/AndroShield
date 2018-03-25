#pragma once

using namespace System::Collections::Generic;
using namespace System::Xml;

#include"Vulnerability.h"
using namespace Types;
namespace TaintAnalysis{
public ref class TaintAnalyser
{
private : 
	String^ taintOutputFilePath;
	void changeConfigurationFileData(String^ apkPath);
	void extractTaintData();
	short getFreeMem();
public:
	TaintAnalyser(String^ realApkPath);
	property List<Vulnerability>^ vulnerabilities;
	
};
}

