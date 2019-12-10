using System;
using System.Drawing;
using NeoMatrix;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class Observatory
	{
		public Matrix<SpaceUnit> Space { get; set; }
		public int TotalVisibleAsteroids { get; set; }
		public Point Location { get; set; }
	}
	public class Day10Solver : ISolver<Observatory, Day10Input>
	{
		public Observatory Star1(Day10Input input)
		{
			return new Observatory
				   {
					   Space = input.Space
				   };
		}

		public Observatory Star2(Day10Input input)
		{
			throw new NotImplementedException();
		}
	}
}