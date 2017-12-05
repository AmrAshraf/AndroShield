#include <iostream> 
#include <string>
using namespace std;
void main()
{
	string inputA, batchFile;
	cout << "Please enter the name of the script" << endl;
	cin >> batchFile;
	cout << "Please enter the name of the apk for example: trial.apk" << endl;
	cout<<"and make sure it's in the same folder as the project" << endl;
	cin >> inputA;
	string trial = "CMD.exe /C "+batchFile+" " + inputA;
	system(trial.c_str());
	system("pause");
}
