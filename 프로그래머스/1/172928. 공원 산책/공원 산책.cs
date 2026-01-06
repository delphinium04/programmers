using System;
using System.Linq;

public class Solution
{
	public int[] solution(string[] park, string[] routes)
	{
		int[] answer = new int[2];
		int height = park.Length;
		int width = park[0].Length;
		int sX = 0, sY = 0;

		for (int h = 0; h < height; h++)
		{
			for (int w = 0; w < width; w++)
			{
				if (park[h][w] == 'S')
				{
					sY = h;
					sX = w;
				}
			}
		}

		foreach (string r in routes)
		{
			if (r[0] == 'E' || r[0] == 'W')
			{
				int nX = sX + (r[2] - '0') * (r[0] == 'E' ? 1 : -1);
				if (nX >= width || nX < 0) continue; // Range
				if (Enumerable.Range(Math.Min(nX, sX), Math.Abs(sX - nX) + 1)
				    .Any(idx => park[sY][idx] == 'X')) continue;
				sX = nX;
			}
			else
			{
				int nY = sY + (r[2] - '0') * (r[0] == 'S' ? 1 : -1);
				if (nY >= height || nY < 0) continue; // Range
				if (Enumerable.Range(Math.Min(sY, nY), Math.Abs(sY - nY) + 1)
				    .Any(idx => park[idx][sX] == 'X')) continue;
				sY = nY;
			}
		}

		answer[0] = sY;
		answer[1] = sX;
		return answer;
	}
}