#pragma once
using namespace System::Collections::Generic;
using namespace System;
using namespace System::Xml;
using namespace System::IO;
ref class RIFLConverter
{
	void writeInterfacespec(XmlWriter^ xmlWriter, String^ filePath);
	void writeDomains(XmlWriter^ xmlWriter);
	void writeDomainassignment(XmlWriter^ xmlWriter);
	void writeFlowrelation(XmlWriter^ xmlWriter);
public:

	RIFLConverter(String^ filePath,Boolean outputFile);
	property String^ RIFLLines;
};

