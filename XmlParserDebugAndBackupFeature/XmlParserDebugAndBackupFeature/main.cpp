#include<iostream>
#include "XmlParser.h"

using namespace std;
int main(int argc, const char * argv[])
{
	string relpath = "C:\\Users\\noura\\Documents\\Visual Studio 2017\\Projects\\XmlParserDebugAndBackupFeature\\test.xml";
	XmlParser *x = new XmlParser(relpath);

	x->getAppPermissionsExplicitProtectionLevels();
	x->getAppPermissionsWithoutProtectionLevels();
	x->getAppPermissionsForSDK23OrHigher();

	x->getActivitiesPermissions();
	x->getServicesPermissions();
	x->getProvidersPermissions();
	x->getReceiversPermissions();

	int xx;
	xx = 6;
	return 0;
}