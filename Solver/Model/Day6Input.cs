using System.Collections.Generic;
using System.Linq;
using Solver.Base;

namespace Solver.Model
{
	public class Orbit
	{
		public string Parent { get; set; }
		public string Child { get; set; }
	}

	public class Day6Input : IInput<Day6Input>
	{
		public ICollection<Orbit> Orbits { get; set; }

		public Day6Input Parse(string[] values)
		{
			Orbits = new List<Orbit>();
			foreach (var value in values)
				Orbits.Add(new Orbit
						   {
							   Parent = value.Split(')').ElementAt(0),
							   Child = value.Split(')').ElementAt(1)
						   });

			return this;
		}
	}
}