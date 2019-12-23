using System;
using System.Linq;
using Solver.Base;

namespace Solver.Model
{
	public class Day16Input : IInput<Day16Input>
	{
		public int[] Numbers { get; set; }
		public int[] BasePattern { get; } = { 0, 1, 0, -1 };
		public int Iterations { get; set; }

		public Day16Input Parse(string[] values)
		{
			Numbers = values.First().ToCharArray().Select(c => int.Parse(c.ToString())).ToArray();
			return this;
		}
	}
}