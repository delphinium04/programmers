using System;
using System.Linq;

public class Solution
{
	public bool CanSolve(int[] diffs, int[] times, long limit, int userLevel)
	{
		long time = 0;
		for (int i = 0; i < diffs.Length; i++)
		{
			if (diffs[i] <= userLevel)
				time += times[i];
			else
				time += (times[i] + times[i - 1])
                * (diffs[i] - userLevel) + times[i];
			if (time > limit)
			{
				return false;
			}
		}

		return true;
	}

	public int solution(int[] diffs, int[] times, long limit)
	{
		int maxLevel = diffs.Max(); // diffs 중 최대 가능값: 포함
		int minLevel = 1; // diffs 중 최소 가능값: 제외

		int currentLevel = (maxLevel + minLevel + 1) / 2;
		while (minLevel < maxLevel)
		{
			if (CanSolve(diffs, times, limit, currentLevel))
				maxLevel = currentLevel;
			else
				minLevel = currentLevel + 1;
			currentLevel = (maxLevel + minLevel) / 2;
		}

		return currentLevel;
	}
}