#include"ApkInfo.h"
#include <string>
#include <fstream>
#include <streambuf>


ApkInfo::ApkInfo(string filePathOrContent, bool isFile)
{
	string lines;
	if (isFile)
	{
		ifstream f(filePathOrContent);
		string temp((istreambuf_iterator<char>(f)),
			istreambuf_iterator<char>());
		lines = temp;
	}
	else
		lines = filePathOrContent;
	int x;
	x = 6;
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