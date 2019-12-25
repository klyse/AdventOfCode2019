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
			while (true)
			{
				iterations++;
				Make("FUEL");

				if (_producedChemicals.All(c => c.Value == 0))
				{
					return (int)((1e12 / _oreCnt) * iterations);
				}
			}
		}

		private void Need(ChemicalDependency dep)
		{
			if (_producedChemicals[dep.Name] >= dep.Count)
				_producedChemicals[dep.Name] -= dep.Count;
			else
				while (true)
				{
					var madeCnt = Make(dep.Name);

					_producedChemicals[dep.Name] += madeCnt;
					if (_producedChemicals[dep.Name] >= dep.Count)
					{
						_producedChemicals[dep.Name] -= dep.Count;
						break;
					}
				}
		}

		private int Make(string chemName)
		{
			var chemical = _recipes[chemName];

			foreach (var chemicalDependency in chemical.Dependencies)
				if (chemicalDependency.Name == "ORE")
					_oreCnt += chemicalDependency.Count;
				else
					Need(chemicalDependency);

			return chemical.ResultCount;
		}
	}
}