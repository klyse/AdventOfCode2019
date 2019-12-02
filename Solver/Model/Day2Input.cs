using System.Linq;
using Solver.Base;

namespace Solver.Model
{
	public class Day2Input : IInput<Day2Input>
	{
		public int[] Commands { get; set; }

		public Day2Input Parse(string[] values)
		{
			Commands = values.First().Split(',').Select(int.Parse).ToArray();
			return this;
		}
	}
}