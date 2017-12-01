#include "XmlParser.h";
#include<iostream>
using namespace std;
void main() {

	string relpath = "D:\\ReverseEngineering\\Tests\\jadx-result3\\AndroidManifest.xml";
	XmlParser *x = new XmlParser(relpath);
	x->getApplicationPermissions();
	x->getComponentsPermissions();
	x->getComponentsPermissions();
	x->getExportedComponents();
	int xx;
	xx = 5;
}