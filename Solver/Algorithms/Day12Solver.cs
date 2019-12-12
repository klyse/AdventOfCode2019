﻿using System;
using System.Linq;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class Day12Solver : ISolver<int, Day12Input>
	{
		public int Star1(Day12Input input)
		{
			for (var i = 0; i < input.Steps; ++i)
			{
				for (var m1 = 0; m1 < input.Moons.Count; m1++)
				for (var m2 = 0; m2 < input.Moons.Count; m2++)
				{
					if (m2 == m1)
						continue;

					input.Moons[m1].UpdateVelocity(input.Moons[m2].Position);
				}

				foreach (var moon in input.Moons) moon.Move();
			}

			var sum = input.Moons.Select(c => (Math.Abs(c.Position.X) + Math.Abs(c.Position.Y) + Math.Abs(c.Position.Z)) *
											  (Math.Abs(c.Vector.Y) + Math.Abs(c.Vector.X) + Math.Abs(c.Vector.Z))).Sum();

			return sum;
		}

		public int Star2(Day12Input input)
		{
			var startPos = input.Moons.Select(c => (Moon)c.Clone()).ToList();

			var step = 1;
			while (true)
			{
				for (var m1 = 0; m1 < input.Moons.Count; m1++)
				for (var m2 = 0; m2 < input.Moons.Count; m2++)
				{
					if (m2 == m1)
						continue;

					input.Moons[m1].UpdateVelocity(input.Moons[m2].Position);
				}

				foreach (var moon in input.Moons) moon.Move();

				step++;

				var firstFalse = false;
				for (var m = 0; m < input.Moons.Count; m++)
					if (!startPos[m].Position.Equals(input.Moons[m].Position))
					{
						firstFalse = true;
						break;
					}

				if (step % 1 == 0)
				{
					Console.Write($"{step};");
					for (var i = 0; i < input.Moons.Count; i++)
						//Console.WriteLine($"{step.ToString().PadLeft(8)}: {input.Moons[i]}");
						Console.Write($"{input.Moons[i]}");

					Console.WriteLine();
				}

				if (firstFalse)
					continue;

				return step;
			}
		}
	}
}