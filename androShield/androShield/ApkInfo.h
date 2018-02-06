#pragma once
#include<vector>
#include<iostream>
using namespace std;
class ApkInfo
{
private:

public:
	ApkInfo(string filePathOrContent,bool isFile);
	static void split(vector<string>& v, string s, string delimiter);
};