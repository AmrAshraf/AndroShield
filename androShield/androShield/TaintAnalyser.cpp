#include <windows.h>
#include "TaintAnalyser.h"


#include <string> 
namespace TaintAnalysis {
	void TaintAnalyser::changeConfigurationFileData(String ^ apkPath)
	{
		XmlDocument^ xmlDoc = gcnew XmlDocument();	
		xmlDoc->Load("C:\\taintAnalysis\\configuration.xml");
		XmlNodeList^ list=xmlDoc->GetElementsByTagName("targetAPK");
		list[0]->InnerXml = apkPath;
		list = xmlDoc->GetElementsByTagName("outputFile");
		taintOutputFilePath = "C:\\taintAnalysis\\" + System::IO::Path::GetFileNameWithoutExtension(apkPath) + ".xml";
		list[0]->InnerXml = taintOutputFilePath;
		xmlDoc->Save("C:\\taintAnalysis\\configuration.xml");
			}
	void TaintAnalyser::extractTaintData()
	{
		XmlDocument^ xmlDoc = gcnew XmlDocument();
		xmlDoc->Load(taintOutputFilePath);
		XmlNodeList^ results = xmlDoc->GetElementsByTagName("Result");
		for (int i = 0; i < results->Count; ++i)
		{
			XmlNode^ result = results[i];
			XmlNodeList^ sink_sources = result->ChildNodes;
			String^ extraInfo = gcnew String("");
			
				XmlNode^ sink = sink_sources[0];//sink
				extraInfo += "Sink : " + sink->Attributes["Statement"]->Value + Environment::NewLine
					+ "Category : " + sink->Attributes["Category"]->Value + Environment::NewLine;
			
				XmlNodeList^ sources = sink_sources[1]->ChildNodes;
			
			for (int j = 0;j < sources->Count; ++j)//sources
			{
					XmlNode^ source = sources[j];
					extraInfo += "Source : " + source->Attributes["Statement"]->Value + Environment::NewLine
						+ "Category : " + source->Attributes["Category"]->Value + Environment::NewLine;
				
			}
			//create new vulnerability
			Vulnerability vul;
			vul.extraInfo = extraInfo;
			vul.type = "static";
			vul.category = "information leak";
			vul.severity = 0.5;
			vulnerabilities->Add(vul);
		}
				
	}
	short TaintAnalyser::getFreeMem()
	{
		MEMORYSTATUSEX status;
		status.dwLength = sizeof(status);
		GlobalMemoryStatusEx(&status);
		return status.ullAvailPhys / (1024 * 1024 * 1024);
	}

	TaintAnalyser::TaintAnalyser(String^ realApkPath)
	{

		vulnerabilities = gcnew List<Vulnerability>();
		changeConfigurationFileData(realApkPath);
		short freeMemory = getFreeMem();
		std::string command;
		if (freeMemory<1)
			command = "/C java -jar C:\\taintAnalysis\\soot-infoflow-cmd.jar -c C:\\taintAnalysis\\configuration.xml ";
		else
			command = "/C java -Xmx" + std::to_string(freeMemory) + "g -jar C:\\taintAnalysis\\soot-infoflow-cmd.jar -c C:\\taintAnalysis\\configuration.xml ";

		//system(command.c_str());
		//HINSTANCE retVal = ShellExecute(NULL, "open", "cmd", command.c_str(), "C:\\", SW_HIDE);
		SHELLEXECUTEINFO ShExecInfo = { 0 };
		ShExecInfo.cbSize = sizeof(SHELLEXECUTEINFO);
		ShExecInfo.fMask = SEE_MASK_NOCLOSEPROCESS;
		ShExecInfo.hwnd = NULL;
		ShExecInfo.lpVerb = NULL;
		ShExecInfo.lpFile = "cmd";
		ShExecInfo.lpParameters = command.c_str();
		ShExecInfo.lpDirectory = "C:\\";
		ShExecInfo.nShow = SW_HIDE;
		ShExecInfo.hInstApp = NULL;
		ShellExecuteEx(&ShExecInfo);
		WaitForSingleObject(ShExecInfo.hProcess, INFINITE);
		extractTaintData();
		System::IO::File::Delete(taintOutputFilePath);
	}
}