#pragma once


using namespace System::Collections::Generic;
#include"Vulnerability.h"

using namespace Types;
namespace APKInfoExtraction {
	public	value struct SupportedArchitectures
	{
		bool all;
		bool armeabi;
		bool armeabi_v7a;
		bool arm64_v8a;
		bool x86;
		bool x86_64;
		bool mips;
		bool mips64;

	};
	public ref class APKInfoExtractor
	{
	private:
		void grabInfoFromApk();
		void grabInfoFromManifest();
		void changeApkName(String^ apkPath);
	public:
		APKInfoExtractor(String^ apkPath);
		void startExtraction();
	static	String^ getCurrentTime();

		String^ realApkPath;
		Boolean  debuggableFlag;
		Boolean  testFlag;
		cli::array<String^>^ launchableActivities;
		cli::array<String^>^ permissions;
		String^ versionName;
		String^ versionCode;
		String^ packageName;
		String^ minSDKVersion;
		String^ targetSDKVersion;
		SupportedArchitectures supportedArchitectures;

		String^ apkTime;

		Boolean backupFlag;
		Boolean externalStorageFlag;
		property List<Vulnerability>^ vulnerabilities;
	};
}
