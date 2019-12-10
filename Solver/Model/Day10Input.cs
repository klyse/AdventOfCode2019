using System;
using System.Drawing;
using System.Linq;
using NeoMatrix;
using Solver.Base;

namespace Solver.Model
{
	public class SpaceUnit : ICloneable
	{
		public bool ContainsAsteroid { get; set; }
		public bool Shadowed { get; set; }
		public bool IsVisible => ContainsAsteroid && !Shadowed;

		public Point Position { get; set; }

		public object Clone()
		{
			return new SpaceUnit
				   {
					   ContainsAsteroid = ContainsAsteroid,
					   Position = Position
				   };
		}
	}

	public class Day10Input : IInput<Day10Input>, ICloneable
	{
		public Matrix<SpaceUnit> Space { get; set; }

		public object Clone()
		{
			var mat = Matrix<SpaceUnit>.NewMatrix(Space.Rows, Space.Columns, (row, column) => (SpaceUnit)Space[row, column].Clone());

			return new Day10Input
				   {
					   Space = mat
				   };
		}

		public Day10Input Parse(string[] values)
		{
			var columns = values.First().Length;
			var rows = values.Length;

			Space = Matrix<SpaceUnit>.NewMatrix(rows, columns, (row, column) =>
															   {
																   var elem = values.ElementAt(row)[column];

																   return new SpaceUnit
																		  {
																			  ContainsAsteroid = elem == '#',
																			  Position = new Point(column, row)
																		  };
															   });

			return this;
		}
	}
}