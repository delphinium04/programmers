using System;

public class Solution {
    public bool solution(string s) {
        bool answer = true;
        
        int c = 0;
        foreach(char bc in s){
            if(!answer) break;
            
            if(bc == '(') c++;
            else if(c >= 1) c--;
            else answer = false;                
        }
        
        if(c>0) answer = false;
        return answer;
    }
}