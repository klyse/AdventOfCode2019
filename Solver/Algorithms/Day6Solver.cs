using System;
using System.Collections.Generic;
using System.Linq;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class Day6Solver : ISolver<int, Day6Input>
	{
		public int Star1(Day6Input input)
		{
			var totalCnt = 0;
			foreach (var orbit in input.Orbits)
			{
				var currentOrbit = orbit;
				while (true)
				{
					currentOrbit = input.Orbits.FirstOrDefault(c => c.Child == currentOrbit.Parent);

					if (currentOrbit is null)
					{
						totalCnt++;
						break;
					}

					totalCnt++;
				}
			}

			return totalCnt;
		}

		public int Star2(Day6Input input)
		{
			var totalCnt = 0;
			var mePassedStars = new List<string>();
			var santaPassedStars = new List<string>();

			var me = input.Orbits.First(c => c.Child == "YOU");
			mePassedStars.Add(me.Parent);
			var currentOrbit = me;
			while (true)
			{
				currentOrbit = input.Orbits.FirstOrDefault(c => c.Child == currentOrbit.Parent);

				if (currentOrbit is null) break;

				mePassedStars.Add(currentOrbit.Parent);
			}

			var santa = input.Orbits.First(c => c.Child == "SAN");
			santaPassedStars.Add(santa.Parent);
			currentOrbit = santa;
			while (true)
			{
				currentOrbit = input.Orbits.FirstOrDefault(c => c.Child == currentOrbit.Parent);

				if (currentOrbit is null) break;

				santaPassedStars.Add(currentOrbit.Parent);
			}

			for (var i = 0; i < mePassedStars.Count; i++)
			for (var j = 0; j < santaPassedStars.Count; j++)
				if (mePassedStars[i] == santaPassedStars[j])
					return i + j;

			throw new Exception("Strange things happened!");
		}
	}
}