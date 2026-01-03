// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace

using System.Collections.Generic;

public class Solution
{
	const char Blank = ' ';

	int[,] delta = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };

	char[,] Storage;
	int Height;
	int Width;

	void RemoveAll(char target)
	{
		for (int h = 0; h < Height; h++)
		{
			for (int w = 0; w < Width; w++)
			{
				if (Storage[h, w] == target)
				{
					Storage[h, w] = Blank;
				}
			}
		}
	}

	class Vector
	{
		public int X;
		public int Y;

		public Vector(int x, int y)
		{
			X = x;
			Y = y;
		}
	}

	void Remove(char target)
	{
		bool[,] visited = new bool[Height, Width];

		// 4면 테두리 시작
		Queue<Vector> queue = new Queue<Vector>();
		for (int x = 1; x < Width - 1; x++)
		{
			queue.Enqueue(new Vector(x, 0));
			queue.Enqueue(new Vector(x, Height - 1));
		}

		for (int y = 0; y < Height; y++)
		{
			queue.Enqueue(new Vector(0, y));
			queue.Enqueue(new Vector(Width - 1, y));
		}

		while (queue.Count > 0)
		{
			Stack<Vector> dfs = new Stack<Vector>();
			dfs.Push(queue.Dequeue());

			while (dfs.Count > 0)
			{
				Vector vector = dfs.Pop();
				if (visited[vector.Y, vector.X]) continue;
				visited[vector.Y, vector.X] = true;

				// 자기 자신인 경우 (테두리)
				if (Storage[vector.Y, vector.X] == target)
				{
					Storage[vector.Y, vector.X] = Blank;
					continue;
				}

				// 빈 칸인 경우 4방향 탐색 및 경로 추가
				if (Storage[vector.Y, vector.X] == Blank)
				{
					for (int di = 0; di < 4; di++)
					{
						Vector next = new Vector(vector.X + delta[di, 1], vector.Y + delta[di, 0]);
						if ((0 <= next.Y && next.Y < Height) && (0 <= next.X && next.X < Width))
						{
							if (Storage[next.Y, next.X] == Blank)
							{
								dfs.Push(next);
							}
							else if (Storage[next.Y, next.X] == target)
							{
								Storage[next.Y, next.X] = Blank;
								visited[next.Y, next.X] = true;
							}
						}
					}
				}

				// 이외: 진행 불가 또는 해당 칸이 target이 아님
			}
		}
	}

	public int solution(string[] storage, string[] requests)
	{
		int answer = 0;
		Height = storage.Length;
		Width = storage[0].Length;
		Storage = new char[Height, Width];

		for (int h = 0; h < storage.Length; h++)
		{
			for (int w = 0; w < storage[0].Length; w++)
			{
				Storage[h, w] = storage[h][w];
			}
		}

		for (int i = 0; i < requests.Length; i++)
		{
			if (requests[i].Length == 1)
			{
				Remove(requests[i][0]); // 지게차
			}
			else
			{
				RemoveAll(requests[i][0]); // 포크레인
			}
		}

		for (int h = 0; h < Height; h++)
		for (int w = 0; w < Width; w++)
			if (Storage[h, w] != Blank)
				answer++;

		return answer;
	}
}