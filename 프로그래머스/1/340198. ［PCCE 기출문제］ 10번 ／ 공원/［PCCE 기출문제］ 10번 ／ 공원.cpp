#include <string>
#include <vector>

using namespace std;

bool IsAvailable(vector<vector<string>> area, int _x, int _y, int matSize){
    for(int y = _y; y < _y + matSize; y++) for(int x = _x; x < _x + matSize; x++){
        if(area[y][x] != "-1") return false;
    }
    
    return true;
}

bool CheckMat(vector<vector<string>> park, int matSize){
    int parkWidth = park.size();
    int parkHeight = park[0].size();
    
    for(int y=0; y<=parkWidth-matSize; y++) for(int x=0; x<=parkHeight-matSize; x++) { 
        if(IsAvailable(park, x, y, matSize)) return true;
    }
    
    return false;
}

int solution(vector<int> mats, vector<vector<string>> park) {
    int answer = -1;    
    for(int matIndex = 0; matIndex < mats.size(); matIndex++){
        if(CheckMat(park, mats[matIndex])){
            if(answer < mats[matIndex]) answer = mats[matIndex];  
        }        
    }
    
    return answer;
}