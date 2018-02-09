#include<iostream>
#include "XmlParser.h"
using namespace std;
int main(int argc, const char * argv[])
{

	string relpath = "D:\\androshield\\XmlParserDebugAndBackupFeature\\test.xml";
	XmlParser *x = new XmlParser(relpath);
	x->getActivities();
	return 0;
}