using System.Linq;
using Solver.Base;

namespace Solver.Model
{
	public class Day11Input : IInput<Day11Input>
	{
		public long[] Commands { get; set; }

		public Day11Input Parse(string[] values)
		{
			Commands = values.First()
							 .Split(',')
							 .Select(long.Parse)
							 .ToArray();

			return this;
		}
	}
}