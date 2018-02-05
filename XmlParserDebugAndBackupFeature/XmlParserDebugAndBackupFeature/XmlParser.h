#pragma once
#include "rapidxml-1.13\rapidxml.hpp";
#include <string>;
#include <fstream>;
#include <sstream>;

using namespace std;
using namespace rapidxml;

class XmlParser
{
	string xmlContent;
	xml_document<> doc;
	ofstream permissionsFile;
	ofstream exportedComponents;

	string getFileLines(string relativePath);
	string isExported(xml_node<>* node);
	string getComponentPermissionString(xml_node<>* child);
	
public:
	XmlParser(string relativePath);

	bool DebugModeEnabled();
	bool BackupModeEnabled();
	bool ExternalStorage();

	void getApplicationPermissions(); 
	void getComponentsPermissions();
	void getExportedComponents();
	void getActivities();
	~XmlParser();
};

