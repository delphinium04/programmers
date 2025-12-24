#include <string>
#include <vector>
#include <map>
#include <set>
#include <sstream>

using namespace std;

vector<int> solution(vector<string> id_list, vector<string> report, int k)
{
    vector<int> answer;
    map<string, int> reportMails;
    map<string, set<string>> maps; // Reported: (UserIds)

    for (int i = 0; i < id_list.size(); i++)
    {
        reportMails.emplace(id_list[i], 0);
    }

    for (int i = 0; i < report.size(); i++)
    {
        istringstream ss(report[i]);
        string reporter, reported;
        ss >> reporter >> reported;

        if (maps.find(reported) == maps.end())
        {
            set<string> reporterSet;
            reporterSet.emplace(reporter);
            maps.emplace(reported, reporterSet);
        }
        else
        {
            maps[reported].emplace(reporter);
        }
    }

    for (map<string, set<string>>::iterator i = maps.begin(); i != maps.end(); i++)
    {
        auto m = i->second;
        if (m.size() >= k)
        {
            for (set<string>::iterator setIt = m.begin(); setIt != m.end(); setIt++)
            {
                reportMails[*setIt] += 1;
            }
        }
    }

    for (int i = 0; i < id_list.size(); i++)
    {
        answer.emplace_back(reportMails[id_list[i]]);
    }

    return answer;
}