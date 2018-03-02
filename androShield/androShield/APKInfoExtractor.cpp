
#include <msclr\marshal.h>  

#include "APKInfoExtractor.h"
#include"ApkInfo.h"
#include"XmlParser.h"

namespace APKInfoExtraction {


	APKInfoExtractor::APKInfoExtractor()
	{
	}
	void APKInfoExtractor::getInfoFromManifest(String^ manifestPath, Boolean & backupFlag, Boolean & externalStorageFlag, cli::array<String^>^% exportedActivities, cli::array<String^>^% exportedServices, cli::array<String^>^% exportedContentProviders, cli::array<String^>^% exportedBroadCastReceivers)
	{
		msclr::interop::marshal_context context;
		XmlParser* xmlParser = new XmlParser(context.marshal_as<const char*>(manifestPath));
		xmlParser->grebBackupModeEnabledFlag();
		xmlParser->grebExternalStorageFlag();
		xmlParser->grebExportedActivities();
		xmlParser->grebExportedServices();
		xmlParser->grebExportedContentProviders();
		xmlParser->grebExportedBroadcastReceivers();
		backupFlag = xmlParser->getBackupFlag();
		externalStorageFlag = xmlParser->getExternalStorageFlag();
		vector<string> tempExportedActivities = xmlParser->getExportedActivities();
		vector<string> tempExportedBroadcasts = xmlParser->getExportedBroadcastReceivers();
		vector<string> tempExportedContentProviders = xmlParser->getExportedContentProviders();
		vector<string> tempExportedServices = xmlParser->getExportedServices();

		exportedActivities = gcnew cli::array<String^>(tempExportedActivities.size());
		exportedBroadCastReceivers = gcnew cli::array<String^>(tempExportedBroadcasts.size());
		exportedContentProviders = gcnew cli::array<String^>(tempExportedContentProviders.size());
		exportedServices = gcnew cli::array<String^>(tempExportedServices.size());
		for (int i = 0; i < tempExportedActivities.size(); ++i)
		{
			String^ t = gcnew String(&tempExportedActivities[i][0]);
			exportedActivities[i] = t;
		}
		for (int i = 0; i < tempExportedBroadcasts.size(); ++i)
		{
			String^ t = gcnew String(&tempExportedBroadcasts[i][0]);
			exportedBroadCastReceivers[i] = t;
		}
		for (int i = 0; i < tempExportedContentProviders.size(); ++i)
		{
			String^ t = gcnew String(&tempExportedContentProviders[i][0]);
			exportedContentProviders[i] = t;
		}
		for (int i = 0; i < tempExportedServices.size(); ++i)
		{
			String^ t = gcnew String(&tempExportedServices[i][0]);
			exportedServices[i] = t;
		}
	}
	String^ APKInfoExtractor::getInfoFromApk(String^ apkPath, Boolean % debuggableFlag, Boolean % testFlag, cli::array<String^>^% launchableActivities,
		cli::array<String^>^% permissions, String^% versionName, String^% versionCode, String^% packageName, String^% minSDKVersion,
		String^% targetSDKVersion, SupportedArchitectures % supportedArchitectures)
	{
		msclr::interop::marshal_context context;
		system("dir>hello.txt");
		//ApkInfo* apkInfo = new ApkInfo(context.marshal_as<const char*>(apkPath), true);
		ApkInfo* apkInfo = new ApkInfo("D:\\androshield\\androShield\\test", true);
		debuggableFlag = apkInfo->getAppDebuggableFlag();
		testFlag = apkInfo->getTestOnlyFlag();
		vector<string> tempLaunchableActivities = apkInfo->getLaunchableActivities();
		vector<string> tempPermissions = apkInfo->getPermissions();
		permissions = gcnew cli::array<String^>(tempPermissions.size());
		launchableActivities = gcnew cli::array<String^>(tempLaunchableActivities.size());
		for (int i = 0; i < tempLaunchableActivities.size(); ++i)
		{
			String^ t = gcnew String(&tempLaunchableActivities[i][0]);
			launchableActivities[i] = t;
		}
		for (int i = 0; i < tempPermissions.size(); ++i)
		{
			String^ t = gcnew String(&tempPermissions[i][0]);
			permissions[i] = t;
		}

		versionName = gcnew String(&apkInfo->getVersionName()[0]);
		versionCode = gcnew String(&apkInfo->getVersionCode()[0]);
		packageName = gcnew String(&apkInfo->getPackageName()[0]);
		minSDKVersion = gcnew String(&apkInfo->getMinSDKVersion()[0]);
		targetSDKVersion = gcnew String(&apkInfo->getTargetSDKVersion()[0]);
		ApkInfo::SupportedArchi temp = apkInfo->getSupportedArchi();
		supportedArchitectures.all = temp.all;
		supportedArchitectures.arm64_v8a = temp.arm64_v8a;
		supportedArchitectures.armeabi = temp.armeabi;
		supportedArchitectures.armeabi_v7a = temp.armeabi_v7a;
		supportedArchitectures.mips = temp.mips;
		supportedArchitectures.mips64 = temp.mips64;
		supportedArchitectures.x86 = temp.x86;
		supportedArchitectures.x86_64 = temp.x86_64;
		delete apkInfo;

		return ("dsa");
		
	}
}