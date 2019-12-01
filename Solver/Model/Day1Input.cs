using System.Collections.Generic;
using System.Linq;
using Solver.Base;

namespace Solver.Model
{
	public class Day1Input : IInput<Day1Input>
	{
		public IEnumerable<int> Modules;

		public Day1Input Parse(string[] values)
		{
			Modules = values.Select(int.Parse);

			return this;
		}
	}
}