using System.Collections.Generic;
using System.Linq;
using Solver.Base;

namespace Solver.Model
{
	public class ChemicalDependency
	{
		public string Name { get; set; }
		public int Count { get; set; }
	}

	public class Chemical
	{
		public ICollection<ChemicalDependency> Dependencies { get; set; } = new List<ChemicalDependency>();
		public int ResultCount { get; set; }
		public string Name { get; set; }
	}

	public class Day14Input : IInput<Day14Input>
	{
		public ICollection<Chemical> Recipes { get; set; } = new List<Chemical>();

		public Day14Input Parse(string[] values)
		{
			//2 VPVL, 7 FWMGM, 2 CXFTF, 11 MNCFX => 1 STKFG

			foreach (var value in values)
			{
				var dependencies = value.Split('=').First();
				var dependenciesSplit = dependencies.Split(',');

				var chemical = new Chemical();
				Recipes.Add(chemical);

				var chemicalStr = value.Split('>').ElementAt(1).Trim();
				var splitChemicalStr = chemicalStr.Split(' ');
				chemical.Name = splitChemicalStr.ElementAt(1).Trim();
				chemical.ResultCount = int.Parse(splitChemicalStr.First().Trim());

				foreach (var dependency in dependenciesSplit)
				{
					var dependencySplit = dependency.Trim().Split(' ');
					chemical.Dependencies.Add(new ChemicalDependency
											  {
												  Count = int.Parse(dependencySplit.First().Trim()),
												  Name = dependencySplit.ElementAt(1).Trim()
											  });
				}
			}

			return this;
		}
	}
}