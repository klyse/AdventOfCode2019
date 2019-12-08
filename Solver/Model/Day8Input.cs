using System.Linq;
using Solver.Base;

namespace Solver.Model
{
	public class Day8Input : IInput<Day8Input>
	{
		public int[] Pixels { get; set; }
		public int Columns { get; set; }
		public int Rows { get; set; }

		public Day8Input Parse(string[] values)
		{
			Pixels = values.First().ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();
			Rows = int.Parse(values.ElementAt(1));
			Columns = int.Parse(values.ElementAt(2));

			return this;
		}
	}
}