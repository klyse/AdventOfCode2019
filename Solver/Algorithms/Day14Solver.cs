using System;
using System.Collections.Generic;
using System.Linq;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class Day14Solver : ISolver<int, Day14Input>
	{
		private Day14Input day14In;

		private int oreCnt;
		private Dictionary<string, int> ProducedChemicals;

		public int Star1(Day14Input input)
		{
			day14In = input;

			ProducedChemicals = day14In.Recipes.ToDictionary(c => c.Name, c => 0);

			Make("FUEL");

			return oreCnt;
		}

		public int Star2(Day14Input input)
		{
			throw new NotImplementedException();
		}

		private void Need(string name, int count)
		{
			if (ProducedChemicals[name] >= count)
				ProducedChemicals[name] -= count;
			else
				while (true)
				{
					var madeCnt = Make(name);

					ProducedChemicals[name] += madeCnt;
					if (ProducedChemicals[name] >= count)
					{
						ProducedChemicals[name] -= count;
						break;
					}
				}
		}

		private int Make(string chemName)
		{
			var chemical = day14In.Recipes.First(c => c.Name == chemName);

			foreach (var chemicalDependency in chemical.Dependencies)
				if (chemicalDependency.Name == "ORE")
					oreCnt += chemicalDependency.Count;
				else
					Need(chemicalDependency.Name, chemicalDependency.Count);

			return chemical.ResultCount;
		}
	}
}