using System.Linq;
using Solver.Base;

namespace Solver.Model
{
	public class Day7Input : IInput<Day7Input>
	{
		public int[] Commands { get; set; }

		public Day7Input Parse(string[] values)
		{
			Commands = values.First()
							 .Split(',')
							 .Select(int.Parse)
							 .ToArray();
			return this;
		}
	}
}