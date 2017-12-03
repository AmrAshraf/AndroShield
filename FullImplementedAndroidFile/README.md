How to get full implemented android.jar full implemented Android APIs file for recent versions of Android?
why not using just one that shiped with Android SDK? because internal and hidden functions are implemented as stubs .
Solutions:
1- to get full source code from google android and build it which requires alot of hardware and internet capabilities. (failed to achive this one)
2-get framework.jar file which contains the real implementation of this stubs from emulator,real phone or factory android image and rebuild android.jar with the framework.jar and the old one (Done).
2.1- for android 4.2 and below (dalvik compiler) you can find framework.jar under : /system/framework/framework.jar
2.1.1-rebuild framework.jar file with the original android.jar file and get the full implemented android.jar file .

2.2- for android 4.4 and above (ART compiler) they optimized alot of files so we have to do more steps .
2.2.1- get /system/framework/[arm/X86]/boot.oat file .
2.2.2- reverse it by oat2dex to get framework.dex [framework2.dex][...] file(s) .
2.2.3-covert framework.dex files to framework.jar files by using recent pre release dex2jar tool .
2.2.4-rebuild framework.jar files with the original android.jar file as in step 2.1.1 .