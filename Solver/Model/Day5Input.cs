using System.Linq;
using Solver.Base;

namespace Solver.Model
{
	public class Day5Input : IInput<Day5Input>
	{
		public int[] Commands { get; set; }

		public Day5Input Parse(string[] values)
		{
			Commands = values.First()
							 .Split(',')
							 .Select(int.Parse)
							 .ToArray();
			return this;
		}
	}
}