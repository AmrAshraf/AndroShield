#pragma once
#include "rapidxml-1.13\rapidxml.hpp";
#include <string>;
#include <fstream>;
#include <sstream>;
#include <vector>;
#include <utility>;
#include <map>;

using namespace std;
using namespace rapidxml;

class XmlParser
{
	vector<string> activities;
	vector<string> services;
	vector<string> contentProviders;
	vector<string> broadcastReceivers;

	vector<string> exportedActivities;
	vector<string> exportedServices;
	vector<string> exportedContentProviders;
	vector<string> exportedBroadcastReceivers;

	vector<pair<string, string>> activitiesPermissions;
	vector<pair<string, string>> servicesPermissions;
	vector<pair<string, string>> contentProvidersPermissions;
	vector<pair<string, string>> broadcastReceiversPermissions;

	vector<pair<string, string>> appPermissionsWithProtectionLevels;
	vector<string> appPermissionsWithoutProtectionLevels;
	vector<string> appPermissionsForSDK23orHigher;

	map<string, string> permissionsWithProtectionLevels;

	string xmlContent;
	xml_document<> doc;
	ofstream permissionsFile;
	ofstream exportedComponents;

	string getFileLines(string relativePath);
	string isExported(xml_node<>* node);
	string getComponentPermissionString(xml_node<>* child);
	bool debugFlag;
	bool backupFlag;
	bool externalStorageFlag;

public:

	XmlParser(string manifestPath);

	void grebDebugModeEnabledFlag();
	void grebBackupModeEnabledFlag();
	void grebExternalStorageFlag();

	void grebAppPermissionsExplicitProtectionLevels();
	void grebAppPermissionsWithoutProtectionLevels();
	void grebAppPermissionsForSDK23OrHigher();

	void grebActivitiesPermissions();
	void grebServicesPermissions();
	void grebProvidersPermissions();
	void grebReceiversPermissions();

	void grebActivities();
	void grebServices();
	void grebContentProviders();
	void grebBroadcastReceivers();

	void grebExportedActivities();
	void grebExportedServices();
	void grebExportedContentProviders();
	void grebExportedBroadcastReceivers();

	bool getBackupFlag();
	bool getExternalStorageFlag();
	vector<string> getExportedActivities();
	vector<string> getExportedServices();
	vector<string> getExportedContentProviders();
	vector<string> getExportedBroadcastReceivers();
	~XmlParser();
};

