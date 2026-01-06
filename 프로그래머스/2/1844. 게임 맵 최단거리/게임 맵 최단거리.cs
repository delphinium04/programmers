using System;
using System.Collections.Generic;

class Solution
{
	struct Point
	{
		public int X;
		public int Y;
	}

	int[] dx = { -1, 1, 0, 0 };
	int[] dy = { 0, 0, -1, 1 };


	public int solution(int[,] maps)
	{
		int answer = -1;
		int HEIGHT = maps.GetLength(0);
		int WIDTH = maps.GetLength(1);

		bool[,] visited = new bool[HEIGHT, WIDTH];
		Queue<Point> saved = new Queue<Point>();
		saved.Enqueue(new Point());
		bool found = false;

		for (int tried = 1; tried <= maps.Length; tried++)
		{
			if (saved.Count == 0) break;

			Queue<Point> bfs = new Queue<Point>(saved);
			saved.Clear();
			while (bfs.Count > 0)
			{
				Point n = bfs.Dequeue();
				if (visited[n.Y, n.X] ||
				    maps[n.Y, n.X] == 0) continue;

				visited[n.Y, n.X] = true;
				if (n.X == WIDTH - 1 && n.Y == HEIGHT - 1)
				{
					found = true;
					break;
				}

				for (int d = 0; d < 4; d++)
				{
					int nx = n.X + dx[d];
					int ny = n.Y + dy[d];
					if (!(0 <= nx && nx < WIDTH) ||
					    !(0 <= ny && ny < HEIGHT))
						continue;
					Point tp;
					tp.X = nx;
					tp.Y = ny;
					saved.Enqueue(tp);
				}
			}

			if (found)
			{
				answer = tried;
				break;
			}
		}

		return answer;
	}
}