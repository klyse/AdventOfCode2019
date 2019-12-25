using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class Day14Solver : ISolver<int, Day14Input>
	{
		private long _oreCnt;
		private Dictionary<string, long> _producedChemicals;
		Dictionary<string, Chemical> _recipes;

		public int Star1(Day14Input input)
		{
			_recipes = input.Recipes.ToDictionary(c => c.Name, c => c);

			_producedChemicals = input.Recipes.ToDictionary(c => c.Name, c => (long)0);

			Make("FUEL");

			return (int)_oreCnt;
		}

		public int Star2(Day14Input input)
		{
			_recipes = input.Recipes.ToDictionary(c => c.Name, c => c);
			_producedChemicals = input.Recipes.ToDictionary(c => c.Name, c => (long)0);

			var iterations = 0;
			var maxOre = 1e12;

			var fuelCnt = Make("FUEL");
			while (true)
			{
				var step = (int)(maxOre / _oreCnt);
				fuelCnt += Make("FUEL", step);

				if (_oreCnt > maxOre)
					Debugger.Break();
			}
		}

		private void Need(ChemicalDependency dep, int count)
		{
			if (_producedChemicals[dep.Name] >= dep.Count * count)
				_producedChemicals[dep.Name] -= dep.Count * count;
			else
				while (true)
				{
					var cnt = Math.Ceiling(count / (double)dep.Count);
					var madeCnt = Make(dep.Name, (int)cnt);

					_producedChemicals[dep.Name] += madeCnt;
					if (_producedChemicals[dep.Name] >= dep.Count * count)
					{
						_producedChemicals[dep.Name] -= dep.Count * count;
						break;
					}
				}
		}

		private int Make(string chemName, int count = 1)
		{
			var chemical = _recipes[chemName];

			foreach (var chemicalDependency in chemical.Dependencies)
				if (chemicalDependency.Name == "ORE")
					_oreCnt += chemicalDependency.Count * count;
				else
					Need(chemicalDependency, count);

			return chemical.ResultCount * count;
		}
	}
}