#pragma once
#include<vector>
#include<iostream>
using namespace std;
class ApkInfo
{
public:
	struct SupportedArchi
	{
		bool all = true;
		bool armeabi=true;
		bool armeabi_v7a = true;
		bool arm64_v8a = true;
		bool x86 = true;
		bool x86_64 = true;
		bool mips = true;
		bool mips64 = true;
	}; 
	ApkInfo(const string& filePathOrContent,bool isFile);
	void parse(const string & content);
	void readFile(const string & filePathOrContent,  string & content);
	static void split(vector<string>& v, string s, string delimiter);

private:
	string packageName;
	string versionCode;
	string versionName;
	string minSDKVersion;
	string targetSDKVersion;
	vector<string> permissions;
	vector<string> launchableActivities;
	SupportedArchi supportedArchi;
	bool testOnly = false;
	bool appDebuggable = false;
};