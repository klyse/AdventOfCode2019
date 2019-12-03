using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class Day3Solver : ISolver<int, Day3Input>
	{
		public int Star1(Day3Input input)
		{
			var points1 = new List<Point>();
			var origin = new Point(input.MaxLeft + input.MaxRight, input.MaxUp + input.MaxDown); // avoid negative values
			var currentPos = origin;

			foreach (var i in input.Line1)
			{
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
			}

			currentPos = origin;
			var points2 = new List<Point>();

			foreach (var i in input.Line2)
			{
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
			}

			var interceptions = points1.Intersect(points2).ToList();

			var manhattanInterceptions = interceptions
										 .Select(c => new
													  {
														  Dist = Math.Abs(c.X - origin.X) + Math.Abs(c.Y - origin.Y),
														  Point = c
													  })
										 .OrderBy(c => c.Dist)
										 .ToList();

			var closestInterception = manhattanInterceptions.First();
			return closestInterception.Dist;
		}

		public int Star2(Day3Input input)
		{
			throw new NotImplementedException();
		}
	}
}