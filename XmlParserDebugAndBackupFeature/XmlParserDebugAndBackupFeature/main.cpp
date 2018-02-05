#include "XmlParser.h"
#include<iostream>

#include<vector>
using namespace std;

void main() {

string relpath = "D:\\androshield\\XmlParserDebugAndBackupFeature\\test.xml";
	XmlParser *x = new XmlParser(relpath);
	x->getApplicationPermissions();
	x->getComponentsPermissions();
	x->getExportedComponents();
	x->getActivities();	
}