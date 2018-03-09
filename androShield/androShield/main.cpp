#include<iostream>
#include<vector>
#include"ApkInfo.h"
#include "XmlParser.h"
#include"APKInfoExtractor.h"
#include"TaintAnalyser.h"
#include<chrono>
using namespace std;
void testExtractInfoFromAPK()
{
	string path = "D:\\androshield\\androShield\\test";
	string path2 = "D:\\androshield\\androShield\\test2";
	std::string lines = "package: name='com.example.wasla' versionCode='1' versionName='1.0' platformBuildVersionName=''\r\n"
		"sdkVersion:'15'\r\n"
		"targetSdkVersion:'26'\r\n"
		"uses-permission: name='android.permission.ACCESS_WIFI_STATE'\r\n"
		"uses-permission: name='android.permission.ACCESS_NETWORK_STATE'\r\n"
		"uses-permission: name='android.permission.INTERNET'\r\n"
		"uses-permission: name='android.permission.WAKE_LOCK'\r\n"
		"uses-permission: name='com.google.android.c2dm.permission.RECEIVE'\r\n"
		"uses-permission: name='com.example.wasla.permission.C2D_MESSAGE'\r\n"
		"application-label:'Wasla'\r\n"
		"application-label-af:'Wasla'\r\n"
		"application-label-am:'Wasla'\r\n"
		"application-label-ar:'Wasla'\r\n"
		"application-label-az:'Wasla'\r\n"
		"application-label-be:'Wasla'\r\n"
		"application-label-bg:'Wasla'\r\n"
		"application-label-bn:'Wasla'\r\n"
		"application-label-bs:'Wasla'\r\n"
		"application-label-ca:'Wasla'\r\n"
		"application-label-cs:'Wasla'\r\n"
		"application-label-da:'Wasla'\r\n"
		"application-label-de:'Wasla'\r\n"
		"application-label-el:'Wasla'\r\n"
		"application-label-en-AU:'Wasla'\r\n"
		"application-label-en-GB:'Wasla'\r\n"
		"application-label-en-IN:'Wasla'\r\n"
		"application-label-es:'Wasla'\r\n"
		"application-label-es-US:'Wasla'\r\n"
		"application-label-et:'Wasla'\r\n"
		"application-label-eu:'Wasla'\r\n"
		"application-label-fa:'Wasla'\r\n"
		"application-label-fi:'Wasla'\r\n"
		"application-label-fr:'Wasla'\r\n"
		"application-label-fr-CA:'Wasla'\r\n"
		"application-label-gl:'Wasla'\r\n"
		"application-label-gu:'Wasla'\r\n"
		"application-label-hi:'Wasla'\r\n"
		"application-label-hr:'Wasla'\r\n"
		"application-label-hu:'Wasla'\r\n"
		"application-label-hy:'Wasla'\r\n"
		"application-label-in:'Wasla'\r\n"
		"application-label-is:'Wasla'\r\n"
		"application-label-it:'Wasla'\r\n"
		"application-label-iw:'Wasla'\r\n"
		"application-label-ja:'Wasla'\r\n"
		"application-label-ka:'Wasla'\r\n"
		"application-label-kk:'Wasla'\r\n"
		"application-label-km:'Wasla'\r\n"
		"application-label-kn:'Wasla'\r\n"
		"application-label-ko:'Wasla'\r\n"
		"application-label-ky:'Wasla'\r\n"
		"application-label-lo:'Wasla'\r\n"
		"application-label-lt:'Wasla'\r\n"
		"application-label-lv:'Wasla'\r\n"
		"application-label-mk:'Wasla'\r\n"
		"application-label-ml:'Wasla'\r\n"
		"application-label-mn:'Wasla'\r\n"
		"application-label-mr:'Wasla'\r\n"
		"application-label-ms:'Wasla'\r\n"
		"application-label-my:'Wasla'\r\n"
		"application-label-nb:'Wasla'\r\n"
		"application-label-ne:'Wasla'\r\n"
		"application-label-nl:'Wasla'\r\n"
		"application-label-pa:'Wasla'\r\n"
		"application-label-pl:'Wasla'\r\n"
		"application-label-pt:'Wasla'\r\n"
		"application-label-pt-BR:'Wasla'\r\n"
		"application-label-pt-PT:'Wasla'\r\n"
		"application-label-ro:'Wasla'\r\n"
		"application-label-ru:'Wasla'\r\n"
		"application-label-si:'Wasla'\r\n"
		"application-label-sk:'Wasla'\r\n"
		"application-label-sl:'Wasla'\r\n"
		"application-label-sq:'Wasla'\r\n"
		"application-label-sr:'Wasla'\r\n"
		"application-label-sr-Latn:'Wasla'\r\n"
		"application-label-sv:'Wasla'\r\n"
		"application-label-sw:'Wasla'\r\n"
		"application-label-ta:'Wasla'\r\n"
		"application-label-te:'Wasla'\r\n"
		"application-label-th:'Wasla'\r\n"
		"application-label-tl:'Wasla'\r\n"
		"application-label-tr:'Wasla'\r\n"
		"application-label-uk:'Wasla'\r\n"
		"application-label-ur:'Wasla'\r\n"
		"application-label-uz:'Wasla'\r\n"
		"application-label-vi:'Wasla'\r\n"
		"application-label-zh-CN:'Wasla'\r\n"
		"application-label-zh-HK:'Wasla'\r\n"
		"application-label-zh-TW:'Wasla'\r\n"
		"application-label-zu:'Wasla'\r\n"
		"application-icon-160:'res/mipmap-mdpi-v4/ic_launcher.png'\r\n"
		"application-icon-240:'res/mipmap-hdpi-v4/ic_launcher.png'\r\n"
		"application-icon-320:'res/mipmap-xhdpi-v4/ic_launcher.png'\r\n"
		"application-icon-480:'res/mipmap-xxhdpi-v4/ic_launcher.png'\r\n"
		"application-icon-640:'res/mipmap-xxxhdpi-v4/ic_launcher.png'\r\n"
		"application-icon-65534:'res/mipmap-mdpi-v4/ic_launcher.png'\r\n"
		"application: label='Wasla' icon='res/mipmap-mdpi-v4/ic_launcher.png'\r\n"
		"testOnly='-1'\r\n"
		"application-debuggable\r\n"
		"launchable-activity: name='com.example.wasla.view.ContactsActivity'  label='' icon=''\r\n"
		"feature-group: label=''\r\n"
		"  uses-feature: name='android.hardware.faketouch'\r\n"
		"  uses-implied-feature: name='android.hardware.faketouch' reason='default feature for all apps'\r\n"
		"  uses-feature: name='android.hardware.wifi'\r\n"
		"  uses-implied-feature: name='android.hardware.wifi' reason='requested android.permission.ACCESS_WIFI_STATE permission'\r\n"
		"main\r\n"
		"other-activities\r\n"
		"other-receivers\r\n"
		"other-services\r\n"
		"supports-screens: 'small' 'normal' 'large' 'xlarge'\r\n"
		"supports-any-density: 'true'\r\n"
		"locales: '--_--' 'af' 'am' 'ar' 'az' 'be' 'bg' 'bn' 'bs' 'ca' 'cs' 'da' 'de' 'el' 'en-AU' 'en-GB' 'en-IN' 'es' 'es-US' 'et' 'eu' 'fa' 'fi' 'fr' 'fr-CA' 'gl' 'gu' 'hi' 'hr' 'hu' 'hy' 'in' 'is' 'it' 'iw' 'ja' 'ka' 'kk' 'km' 'kn' 'ko' 'ky' 'lo' 'lt' 'lv' 'mk' 'ml' 'mn' 'mr' 'ms' 'my' 'nb' 'ne' 'nl' 'pa' 'pl' 'pt' 'pt-BR' 'pt-PT' 'ro' 'ru' 'si' 'sk' 'sl' 'sq' 'sr' 'sr-Latn' 'sv' 'sw' 'ta' 'te' 'th' 'tl' 'tr' 'uk' 'ur' 'uz' 'vi' 'zh-CN' 'zh-HK' 'zh-TW' 'zu'\r\n"
		"densities: '160' '240' '320' '480' '640' '65534'\r\n";
	ApkInfo apkInfo(path, true);
	ApkInfo apkInfo2(lines, false);
	ApkInfo apkInfo3(path2, true);
}
int main(int argc, const char * argv[])
{
	/*
	//Amr test
	testExtractInfoFromAPK();
	//Nouran test
	string relpath = ".\\..\\test.xml";
	XmlParser *x = new XmlParser(relpath);
	x->getActivities();
	*/
	/*
	APKInfoExtraction::APKInfoExtractor ^temp=gcnew APKInfoExtraction::APKInfoExtractor();

	String^ apkPath="D:\\gp\\apks\\wasla.apk";
	Boolean  debuggableFlag;
	Boolean  testFlag;

	Boolean  b1;
	Boolean  b2;

	cli::array<String^>^ launchableActivities;
	cli::array<String^>^ Permissions;


	cli::array<String^>^ a1;
	cli::array<String^>^ a2;
	cli::array<String^>^ a3;
	cli::array<String^>^ a4;
	String^ versionName;
	String^ versionCode;
	String^ packageName;
	String^ minSDKVersion;
	String^ targetSDKVersion;
	APKInfoExtraction::SupportedArchitectures supportedArchitectures;

	temp->getInfoFromApk(apkPath, debuggableFlag, testFlag, launchableActivities, Permissions, versionName,versionCode, packageName, minSDKVersion, targetSDKVersion, supportedArchitectures);
	temp->getInfoFromManifest(apkPath, b1, b2, a1, a2, a3, a4);
	
	cout << testFlag << endl << b1 << endl ;
	system("pause");*/
	//	TaintAnalysis::TaintAnalyser^ analyser = gcnew TaintAnalysis::TaintAnalyser("D:\\gp\\apks\\ArrayCopy1.apk");
	APKInfoExtraction::APKInfoExtractor^ a = gcnew APKInfoExtraction::APKInfoExtractor("D:\\gp\\apks\\bb.apk");
	a->startExtraction();
	TaintAnalysis::TaintAnalyser ^ t = gcnew TaintAnalysis::TaintAnalyser(a->realApkPath);
	return 0;
}