using System;
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
			throw new NotImplementedException();
		}
	}
}