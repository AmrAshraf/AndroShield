# AndroShield - Automated Vulnerability Detection of Android Applications Web Application
This reposatory hosts the AndroShield ASP.NET web application. AndroShield generates reports of detected vulnerabilities in Android applications using static and dynamic analysis methodologies.

## Features
1. Extract general information about the submitted APK
   - Package Name
   - Version Name
   - Version Code
   - Minimum SDK Version
   - Target SDK Version
   - Test Only Flag (Yes/No)
2. Detect static vulnerabilities
   - Debug Mode (Yes/No)
   - Backup Mode (Yes/No)
   - Information Leaks
   - Exported Components
3. Detect dynamic vulnerabilities
   - Insecure Network Requests (Http) 
   - Intent crashes
4. Generate report containing all the extracted information and the detected vulnerabilities.
5. Store the reports in users' account.

## Developing Environment
- Visual Studio 2015/2017
- SQL Server/Visual Studio SQL Server
- JDK 8
- python 2.7
- Android Studio Emulator X86 Oreo version

## Installation Steps
[Installation steps](./Installation Instructions/instructions.txt) make it easier to deal with this project. We are trying to make these steps compatible with different versions of development environment.

## Contributors
- Amr Amin
- Nouran Abdeen
- MennaTullah Magdy
- Amgad ElDessouki
- Hanan Hindy
- Islam Hegazy 


## Contributing to AndroShield
Contributions are always welcome. AndroShield is an open source project that we published in the hope that it will be useful to the research and industry community.

## Citation
````
TBU
````
## License
AndroShield is licensed under the LGPL license, see LICENSE file. This basically means that you are free to use the tool (even in commercial, closed-source projects). However, if you extend or modify the tool, you must make your changes available under the LGPL as well. This ensures that we can continue to improve the tool as a community effort.
