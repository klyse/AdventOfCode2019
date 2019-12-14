using System.Linq;
using Solver.Base;

namespace Solver.Model
{
	public class Day13Input : IInput<Day13Input>
	{
		public long[] Commands { get; set; }

		public Day13Input Parse(string[] values)
		{
			Commands = values.First()
							 .Split(',')
							 .Select(long.Parse)
							 .ToArray();

			return this;
		}
	}
}