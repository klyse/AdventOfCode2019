using System;
using System.Linq;
using Solver.Base;

namespace Solver.Model
{
	public class Day9Input : IInput<Day9Input>
	{
		public int[] Commands { get; set; }
		public int Input { get; set; }

		public Day9Input Parse(string[] values)
		{
			Commands = values.First()
							 .Split(',')
							 .Select(int.Parse)
							 .ToArray();

			return this;
		}
	}
}