#include"ApkInfo.h"
#include <string>
#include <fstream>
#include <streambuf>


ApkInfo::ApkInfo(const string& filePathOrContent, bool isFile)
{
	string lines;
	if (isFile)	
		readFile(filePathOrContent, lines);
	else
		lines = filePathOrContent;
	parse(lines);
}
void ApkInfo::parse(const string &content)
{
	vector<string> lines;
	split(lines, content, "\n");
	size_t size = lines.size();
	for (size_t i = 0; i <size; ++i)
	{
		try {
			if(lines[i].size()>8)
			if (lines[i].substr(0, 7) == "package")
			{
				vector<string> temp;
				split(temp, lines[i], "'");
				packageName = temp[1];
				versionCode = temp[3];
				versionName = temp[5];
			}

			else if (lines[i].substr(0, 10) == "sdkVersion")
			{
				vector<string> temp;
				split(temp, lines[i], "'");
				minSDKVersion = temp[1];
			}
			else if (lines[i].substr(0, 16) == "targetSdkVersion")
			{
				vector<string> temp;
				split(temp, lines[i], "'");
				targetSDKVersion = temp[1];
			}
			else if (lines[i].substr(0, 15) == "uses-permission")
			{
				vector<string> temp;
				split(temp, lines[i], "'");
				permissions.push_back(temp[1]);

			}
			else if (lines[i].substr(0, 8) == "testOnly")
			{
				vector<string> temp;
				split(temp, lines[i], "'");
				if (temp[1] == "-1")
					testOnly = true;
			}
			else if (lines[i].substr(0, 22) == "application-debuggable")
			{
					appDebuggable = true;
			}
			else if (lines[i].substr(0, 19) == "launchable-activity")
			{
				vector<string> temp;
				split(temp, lines[i], "'");
				launchableActivities.push_back(temp[1]);
			}
			else if (lines[i].substr(0, 11) == "native-code")
			{
				supportedArchi.all =
				supportedArchi.arm64_v8a = 
				supportedArchi.armeabi =
				supportedArchi.armeabi_v7a =
				supportedArchi.mips =
				supportedArchi.mips64 =
				supportedArchi.x86 =
				supportedArchi.x86_64 =false;
				vector<string> temp;
				split(temp, lines[i], "'");
				for (int j = 1; j < temp.size(); j += 2)
				{
					if (temp[j] == "arm64-v8a")
						supportedArchi.arm64_v8a = true;
					else if (temp[j] == "armeabi")
						supportedArchi.armeabi = true;
					else if (temp[j] == "armeabi-v7a")
						supportedArchi.armeabi_v7a = true;
					else if (temp[j] == "mips")
						supportedArchi.mips = true;
					else if (temp[j] == "mips64")
						supportedArchi.mips64 = true;
					else if (temp[j] == "x86")
						supportedArchi.x86 = true;
					else if (temp[j] == "x86_64")
						supportedArchi.x86_64 = true;
				}
				
			}
		}
		catch (const exception& ex) { cout<<ex.what()<<endl; };
	}
}
void ApkInfo::readFile(const string& filePathOrContent, string& content)
{
	ifstream f(filePathOrContent);
	string temp((istreambuf_iterator<char>(f)),
		istreambuf_iterator<char>());
	content = temp;
}
void ApkInfo::split(vector<string> &v, string s, string delimiter)
{
	size_t last = 0;
	size_t next = 0;

	while ((next = s.find(delimiter, last)) != string::npos)
	{
		v.push_back(s.substr(last, next - last));
		last = next + 1;
	}
	string temp = s.substr(last);
	if (temp.size() != 0)
		v.push_back(temp);
}