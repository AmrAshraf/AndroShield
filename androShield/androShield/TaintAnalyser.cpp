#include "TaintAnalyser.h"
#include <string> 
namespace TaintAnalysis {
	void TaintAnalyser::changeApkPathInConfigurationFile(String ^ apkPath)
	{
		XmlDocument^ xmlDoc = gcnew XmlDocument();	
		xmlDoc->Load("..\\taintAnalysis\\configuration.xml");
		XmlNodeList^ list=xmlDoc->GetElementsByTagName("targetAPK");
		list[0]->InnerXml = apkPath;
		xmlDoc->Save("..\\taintAnalysis\\configuration.xml");
		
	}
	void TaintAnalyser::extractTaintData()
	{
		XmlDocument^ xmlDoc = gcnew XmlDocument();
		xmlDoc->Load("taintOutputFile.xml");
		XmlNodeList^ results = xmlDoc->GetElementsByTagName("Result");
		for (size_t i = 0; i < results->Count; ++i)
		{
			XmlNode^ result = results[i];
			XmlNodeList^ sink_sources = result->ChildNodes;
			String^ extraInfo = gcnew String("");
			
				XmlNode^ sink = sink_sources[0];//sink
				extraInfo += "Sink : " + sink->Attributes["Statement"]->Value + Environment::NewLine
					+ "Category : " + sink->Attributes["Category"]->Value + Environment::NewLine;
			
				XmlNodeList^ sources = sink_sources[1]->ChildNodes;
			
			for (size_t j = 0;j < sources->Count; ++j)//sources
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
	TaintAnalyser::TaintAnalyser(String^ apkPath)
	{

		vulnerabilities = gcnew List<Vulnerability>();
		changeApkPathInConfigurationFile(apkPath);
		std::string command = "java -Xmx3g -jar ..\\taintAnalysis\\soot-infoflow-cmd.jar -c ..\\taintAnalysis\\configuration.xml ";
		system(command.c_str());
		extractTaintData();
	}
}