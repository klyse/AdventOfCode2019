using System;
using System.Linq;
using Solver.Base;

namespace Solver.Model
{
	public class Day7Input : IInput<Day7Input>, ICloneable
	{
		public int[] Commands { get; set; }

		public object Clone()
		{
			return new Day7Input
				   {
					   Commands = (int[])Commands.Clone()
				   };
		}

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