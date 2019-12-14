using System;
using System.Collections.Generic;
using System.Linq;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class Day14Solver : ISolver<int, Day14Input>
	{
		private Day14Input _day14In;
		private long _oreCnt;
		private Dictionary<string, int> _producedChemicals;

		public int Star1(Day14Input input)
		{
			_day14In = input;

			_producedChemicals = _day14In.Recipes.ToDictionary(c => c.Name, c => 0);

			Make("FUEL");

			return (int)_oreCnt;
		}

		public int Star2(Day14Input input)
		{
			throw new NotImplementedException();
		}

		private void Need(string name, int count)
		{
			if (_producedChemicals[name] >= count)
				_producedChemicals[name] -= count;
			else
				while (true)
				{
					var madeCnt = Make(name);

					_producedChemicals[name] += madeCnt;
					if (_producedChemicals[name] >= count)
					{
						_producedChemicals[name] -= count;
						break;
					}
				}
		}

		private int Make(string chemName)
		{
			var chemical = _day14In.Recipes.First(c => c.Name == chemName);

			foreach (var chemicalDependency in chemical.Dependencies)
				if (chemicalDependency.Name == "ORE")
					_oreCnt += chemicalDependency.Count;
				else
					Need(chemicalDependency.Name, chemicalDependency.Count);

			return chemical.ResultCount;
		}
	}
}