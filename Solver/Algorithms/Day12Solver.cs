using System;
using System.Linq;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class Day12Solver : ISolver<long, Day12Input>
	{
		public long Star1(Day12Input input)
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

		public long Star2(Day12Input input)
		{
			var startPos = input.Moons.Select(c => (Moon)c.Clone()).ToList();
			var hCode = HashCode.Combine(startPos[0], startPos[1], startPos[2], startPos[3]);

			long step = 0;
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
				if (step % 1000000 == 0)
				{
					Console.WriteLine($"{step / 1000000}M");
				}

				var curHCode = HashCode.Combine(input.Moons[0], input.Moons[1], input.Moons[2], input.Moons[3]);
				if (curHCode != hCode)
					continue;


				return step;
			}
		}
	}
}