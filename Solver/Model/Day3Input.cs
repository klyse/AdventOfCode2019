using System;
using System.Collections.Generic;
using System.Linq;
using Solver.Base;

namespace Solver.Model
{
	public class Instruction
	{
		public int Count { get; set; }
		public char Direction { get; set; }
	}

	public class Day3Input : IInput<Day3Input>
	{
		public ICollection<Instruction> Line1 { get; set; }
		public ICollection<Instruction> Line2 { get; set; }

		public int MaxLeft { get; set; }
		public int MaxRight { get; set; }
		public int MaxUp { get; set; }
		public int MaxDown { get; set; }

		public Day3Input Parse(string[] values)
		{
			Line1 = values.First().Split(',').Select(c => new Instruction
														  {
															  Direction = c.First(),
															  Count = int.Parse(c.Substring(1))
														  }).ToList();
			Line2 = values.ElementAt(1).Split(',').Select(c => new Instruction
															   {
																   Direction = c.First(),
																   Count = int.Parse(c.Substring(1))
															   }).ToList();

			MaxLeft = Line1.Where(c => c.Direction == 'L').Sum(c => c.Count);
			MaxRight = Line1.Where(c => c.Direction == 'R').Sum(c => c.Count);
			MaxUp = Line1.Where(c => c.Direction == 'U').Sum(c => c.Count);
			MaxDown = Line1.Where(c => c.Direction == 'D').Sum(c => c.Count);

			MaxLeft = Math.Max(MaxLeft, Line2.Where(c => c.Direction == 'L').Sum(c => c.Count));
			MaxRight = Math.Max(MaxRight, Line2.Where(c => c.Direction == 'R').Sum(c => c.Count));
			MaxUp = Math.Max(MaxUp, Line2.Where(c => c.Direction == 'U').Sum(c => c.Count));
			MaxDown = Math.Max(MaxDown, Line2.Where(c => c.Direction == 'D').Sum(c => c.Count));

			return this;
		}
	}
}