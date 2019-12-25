using System.Linq;
using Solver.Base;

namespace Solver.Model
{
	public class Day19Input : IInput<Day19Input>
	{
		public long[] Commands { get; set; }
		public int GridSize { get; set; }

		public Day19Input Parse(string[] values)
		{
			Commands = values.First()
							 .Split(',')
							 .Select(long.Parse)
							 .ToArray();

			return this;
		}
	}
}