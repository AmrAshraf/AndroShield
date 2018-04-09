#include "CurrentTimeString.h"
#include<chrono>

String ^ CurrentTimeString::getCurrentTime()
{
	std::chrono::time_point<std::chrono::system_clock> currentTime = std::chrono::system_clock::now();
	time_t tt;
	tt = std::chrono::system_clock::to_time_t(currentTime);
	return tt.ToString();
}
