using System.Linq;
using Solver.Base;

namespace Solver.Model
{
	public class Day4Input : IInput<Day4Input>
	{
		public int Min { get; set; }
		public int Max { get; set; }

		public Day4Input Parse(string[] values)
		{
			var strings = values.First().Split('-');
			Min = int.Parse(strings.First());
			Max = int.Parse(strings.ElementAt(1));
			return this;
		}
	}
}