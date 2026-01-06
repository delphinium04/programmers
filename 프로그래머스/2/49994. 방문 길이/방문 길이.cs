using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
	public struct Point
	{
		public int X;
		public int Y;
	}

	Dictionary<Point, HashSet<Point>> connect = new Dictionary<Point, HashSet<Point>>();

	public void Add(Point from, Point to)
	{
		if (!connect.ContainsKey(from))
		{
			HashSet<Point> s = new HashSet<Point>();
			connect.Add(from, s);
		}

		if (!connect.ContainsKey(to))
		{
			HashSet<Point> s = new HashSet<Point>();
			connect.Add(to, s);
		}

		connect[from].Add(to);
		connect[to].Add(from);
	}

	public int GetLine()
		=> connect.Values.Sum(h => h.Count) / 2;

	public int solution(string dirs)
	{
		Point p;
		p.X = 0;
		p.Y = 0;
		foreach (var dir in dirs)
		{
			Point t;
			t.X = p.X;
			t.Y = p.Y;

			if (dir == 'U') t.Y++;
			if (dir == 'D') t.Y--;
			if (dir == 'L') t.X--;
			if (dir == 'R') t.X++;

			if (!(-5 <= t.X && t.X <= 5) ||
			    !(-5 <= t.Y && t.Y <= 5)) continue;

			Add(p, t);
			p = t;
		}

		return GetLine();
	}
}