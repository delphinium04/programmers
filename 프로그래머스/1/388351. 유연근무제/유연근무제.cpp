#include <string>
#include <vector>

using namespace std;

int solution(vector<int> schedules, vector<vector<int>> timelogs, int startday) {
    int answer = 0;
        
    for(int memIdx = 0; memIdx < schedules.size(); memIdx++){
        int currentDay = startday;
        int goalTime = schedules[memIdx] + 10;
        if(goalTime % 100 >= 60){
            goalTime = goalTime + 40;
        }
        
        bool ok = true;
        
        for(int timeIdx = 0; timeIdx < 7; timeIdx++){
            if(currentDay <= 5){
                if(goalTime < timelogs[memIdx][timeIdx]){
                    ok = false;
                    break;
                }
            }            
            currentDay = (currentDay % 7) + 1;
        } 
        
        if(ok) answer++;
    }
    
    return answer;
}