using System.Linq;
using Solver.Base;

namespace Solver.Model
{
	public class Day9Input : IInput<Day9Input>
	{
		public long[] Commands { get; set; }
		public long Input { get; set; }

		public Day9Input Parse(string[] values)
		{
			Commands = values.First()
							 .Split(',')
							 .Select(long.Parse)
							 .ToArray();

			return this;
		}
	}
}