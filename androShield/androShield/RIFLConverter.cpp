#include "RIFLConverter.h"


void RIFLConverter::writeInterfacespec(XmlWriter ^ xmlWriter, String^ filePath)
{
	String^ lastCategory;
	xmlWriter->WriteStartElement("interfacespec");

	array<String^>^ lines = File::ReadAllLines(filePath);
	for each (String^ line in lines)
	{
		if (String::IsNullOrEmpty(line))
			continue;
		array<String^>^ fields = line->Split(' ');
		if (fields->Length == 1)
		{
			lastCategory = fields[0];
			xmlWriter->WriteStartElement("assignable");
			xmlWriter->WriteAttributeString("handle", lastCategory);
		
			xmlWriter->WriteStartElement("category");
			xmlWriter->WriteStartElement("category");
			xmlWriter->WriteAttributeString("name", lastCategory);
		
			continue;
		}
		else if (fields->Length == 3)
		{
			xmlWriter->WriteEndElement();
			xmlWriter->WriteEndElement();
			xmlWriter->WriteEndElement();
			continue;
		}
		else if (fields->Length != 5)
			continue;
		//fields[0] class //fields[1] return (neglect) // fields[2] method //fields[3] (neglect) // fields[4] _SOURCE_ or _SINK_
		fields[0] = fields[0]->TrimStart('<');
		fields[0] = fields[0]->TrimEnd(':');
		fields[2] = fields[2]->TrimEnd('>');
		if (fields[4]->Equals("_SOURCE_"))
		{

			xmlWriter->WriteStartElement("source");
			xmlWriter->WriteStartElement("returnvalue");
			xmlWriter->WriteAttributeString("class", fields[0]);
			xmlWriter->WriteAttributeString("method", fields[2]);
		}
		else if (fields[4]->Equals("_SINK_"))
		{
			xmlWriter->WriteStartElement("sink");
				
			xmlWriter->WriteStartElement("parameter");
			xmlWriter->WriteAttributeString("class", fields[0]);
			xmlWriter->WriteAttributeString("method", fields[2]);
			xmlWriter->WriteAttributeString("parameter", "0");

		}
		xmlWriter->WriteEndElement();
		xmlWriter->WriteEndElement();

	}
	xmlWriter->WriteEndElement();
}

void RIFLConverter::writeDomains(XmlWriter ^ xmlWriter)
{
	xmlWriter->WriteStartElement("domains");

	xmlWriter->WriteStartElement("domain");
	xmlWriter->WriteAttributeString("name", "top");
	xmlWriter->WriteEndElement();

	xmlWriter->WriteStartElement("domain");
	xmlWriter->WriteAttributeString("name", "bottom");
	xmlWriter->WriteEndElement();

	xmlWriter->WriteEndElement();
}

void RIFLConverter::writeDomainassignment(XmlWriter ^ xmlWriter)
{
	xmlWriter->WriteStartElement("domainassignment");

	xmlWriter->WriteStartElement("assign");
	xmlWriter->WriteAttributeString("domain", "top");
	xmlWriter->WriteAttributeString("handle", "NETWORK_INFORMATION_src");
	xmlWriter->WriteEndElement();

	xmlWriter->WriteStartElement("domain");
	xmlWriter->WriteAttributeString("domain", "bottom");
	xmlWriter->WriteAttributeString("handle", "ACCOUNT_SETTINGS_snk");
	xmlWriter->WriteEndElement();

	xmlWriter->WriteEndElement();
}

void RIFLConverter::writeFlowrelation(XmlWriter ^ xmlWriter)
{
	xmlWriter->WriteStartElement("flowrelation");

	xmlWriter->WriteStartElement("flow");
	xmlWriter->WriteAttributeString("from", "top");
	xmlWriter->WriteAttributeString("to", "top");
	xmlWriter->WriteEndElement();

	xmlWriter->WriteStartElement("flow");
	xmlWriter->WriteAttributeString("from", "bottom");
	xmlWriter->WriteAttributeString("to", "bottom");
	xmlWriter->WriteEndElement();

	xmlWriter->WriteStartElement("flow");
	xmlWriter->WriteAttributeString("from", "bottom");
	xmlWriter->WriteAttributeString("to", "top");
	xmlWriter->WriteEndElement();

	xmlWriter->WriteEndElement();
}

RIFLConverter::RIFLConverter(String^ filePath, Boolean outputFile)
{
	XmlWriter^ xmlWriter = XmlWriter::Create("sourcesSinks.rifl");
	
	xmlWriter->WriteStartDocument();
	xmlWriter->WriteStartElement("riflspec");

	writeInterfacespec(xmlWriter,filePath);
	writeDomains(xmlWriter);
	writeDomainassignment(xmlWriter);
	writeFlowrelation(xmlWriter);
	
	
	xmlWriter->WriteEndElement();
	xmlWriter->WriteEndDocument();
	xmlWriter->Close();
}
