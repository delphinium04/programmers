using System;
using System.Collections.Generic;

public class Solution {
    public string[] solution(string[] players, string[] callings) {      
        Dictionary<string, int> ranking = new Dictionary<string, int>();
        for(int i=0; i<players.Length; i++){
            ranking.Add(players[i], i);
        }        
        
        string[] answers = players;
        for(int i=0; i<callings.Length; i++){
            string lower = callings[i];
            int curRank = ranking[lower];
            string upper = answers[curRank-1];
            
            ranking[lower] = curRank-1;
            ranking[upper] = curRank;
            
            answers[curRank-1] = lower;
            answers[curRank] = upper;
        }
        
        return answers;
    }
}