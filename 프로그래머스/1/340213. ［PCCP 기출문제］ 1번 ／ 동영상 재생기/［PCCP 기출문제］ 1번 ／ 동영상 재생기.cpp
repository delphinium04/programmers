#include <iostream>
#include <string>
#include <vector>
#include <iomanip>
#include <cstdio>

using namespace std;

int ConvertTime(string time){
     return ((time[0] - '0') * 10 + (time[1] - '0')) * 60
            + ((time[3] - '0') * 10 + (time[4] - '0'));
}

string ConvertTime(int time) {
    char buffer[6];
    sprintf(buffer, "%02d:%02d", time/60, time%60);
    return string(buffer);
}


string solution(string video_len, string pos, string op_start, string op_end, vector<string> commands) {
    string answer = "";
            
    int videoLength = ConvertTime(video_len);
    int opStart = ConvertTime(op_start);
    int opEnd = ConvertTime(op_end);
    int current = ConvertTime(pos);
    
    if (current < 0) current = 0;
    if (current > videoLength) current = videoLength;
    if (opStart <= current && current <= opEnd) current = opEnd;
    
    vector<string>::iterator it = commands.begin();    
    for(; it != commands.end(); it++) {
        current += (*it == "next") ? 10 : -10;
        
        // 이동 조건 확인
        if (current < 0) current = 0;
        if (current > videoLength) current = videoLength;
        if (opStart <= current && current <= opEnd) current = opEnd;
    }
    
    answer = ConvertTime(current);    
    return answer;
}