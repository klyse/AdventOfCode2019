using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class WirePosition : IEqualityComparer<WirePosition>, IEquatable<WirePosition>
	{
		public Point Point { get; set; }
		public int Distance { get; set; }

		public bool Equals(WirePosition x, WirePosition y)
		{
			return GetHashCode(x) == GetHashCode(y);
		}

		public int GetHashCode(WirePosition obj)
		{
			return Point.GetHashCode();
		}

		public bool Equals(WirePosition other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Point.Equals(other.Point);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((WirePosition)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return Point.GetHashCode() * 397;
			}
		}
	}

	public class Day3Solver : ISolver<int, Day3Input>
	{
		public int Star1(Day3Input input)
		{
			var points1 = new List<Point>();
			var origin = new Point(input.MaxLeft + input.MaxRight, input.MaxUp + input.MaxDown); // avoid negative values
			var currentPos = origin;

			foreach (var i in input.Line1)
				for (var j = 0; j < i.Count; j++)
				{
					if (i.Direction == 'L')
						currentPos.X -= 1;
					else if (i.Direction == 'R')
						currentPos.X += 1;
					else if (i.Direction == 'U')
						currentPos.Y -= 1;
					else if (i.Direction == 'D')
						currentPos.Y += 1;

					points1.Add(currentPos);
				}

			currentPos = origin;
			var points2 = new List<Point>();

			foreach (var i in input.Line2)
				for (var j = 0; j < i.Count; j++)
				{
					if (i.Direction == 'L')
						currentPos.X -= 1;
					else if (i.Direction == 'R')
						currentPos.X += 1;
					else if (i.Direction == 'U')
						currentPos.Y -= 1;
					else if (i.Direction == 'D')
						currentPos.Y += 1;

					points2.Add(currentPos);
				}

			var interceptions = points1.Intersect(points2);

			var manhattanInterceptions = interceptions
										 .Select(c => Math.Abs(c.X - origin.X) + Math.Abs(c.Y - origin.Y))
										 .OrderBy(c => c);

			var closestInterception = manhattanInterceptions.First();
			return closestInterception;
		}

		public int Star2(Day3Input input)
		{
			var points1 = new List<WirePosition>();
			var origin = new Point(input.MaxLeft + input.MaxRight, input.MaxUp + input.MaxDown); // avoid negative values
			var currentPos = origin;
			var currentDist = 0;
			foreach (var i in input.Line1)
				for (var j = 0; j < i.Count; j++)
				{
					if (i.Direction == 'L')
						currentPos.X -= 1;
					else if (i.Direction == 'R')
						currentPos.X += 1;
					else if (i.Direction == 'U')
						currentPos.Y -= 1;
					else if (i.Direction == 'D')
						currentPos.Y += 1;

					currentDist += 1;
					points1.Add(new WirePosition
								{
									Point = currentPos,
									Distance = currentDist
								});
				}

			currentPos = origin;
			var points2 = new List<WirePosition>();
			currentDist = 0;

			foreach (var i in input.Line2)
				for (var j = 0; j < i.Count; j++)
				{
					if (i.Direction == 'L')
						currentPos.X -= 1;
					else if (i.Direction == 'R')
						currentPos.X += 1;
					else if (i.Direction == 'U')
						currentPos.Y -= 1;
					else if (i.Direction == 'D')
						currentPos.Y += 1;

					currentDist += 1;
					points2.Add(new WirePosition
								{
									Point = currentPos,
									Distance = currentDist
								});
				}

			var i1 = points2.Intersect(points1).OrderBy(c => c.Point.X).ThenBy(c => c.Point.Y).ToList();
			var i2 = points1.Intersect(points2).OrderBy(c => c.Point.X).ThenBy(c => c.Point.Y).ToList();

			var d1 = i1.GroupBy(c => c.Point)
					   .Select(c => c.Sum(r => 1))
					   .OrderByDescending(c => c);
			var d2 = i2.GroupBy(c => c.Point)
					   .Select(c => c.Sum(r => 1))
					   .OrderByDescending(c => c);

			if (d2.First() > 1 || d1.First() > 1)
			{
				Console.WriteLine("Duplicated crossings");
				Debugger.Break();
			}

			if (i1.Count != i2.Count)
			{
				Console.WriteLine("Count is not equal");
				Debugger.Break();
			}

			var smallestSum = int.MaxValue;
			var smallestIndex = -1;
			for (var i = 0; i < i1.Count; i++)
			{
				var dist = i1[i].Distance + i2[i].Distance;
				if (smallestSum > dist)
				{
					smallestSum = dist;
					smallestIndex = i;
				}
			}

			return i1[smallestIndex].Distance + i2[smallestIndex].Distance;
		}
	}
}