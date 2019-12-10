using System.Linq;
using NeoMatrix;
using Solver.Base;

namespace Solver.Model
{
	public class SpaceUnit
	{
		public bool ContainsAsteroid { get; set; }
	}

	public class Day10Input : IInput<Day10Input>
	{
		public Matrix<SpaceUnit> Space { get; set; }

		public Day10Input Parse(string[] values)
		{
			var columns = values.First().Length;
			var rows = values.Length;

			Space = Matrix<SpaceUnit>.NewMatrix(rows, columns, (row, column) =>
															   {
																   var elem = values.ElementAt(row)[column];

																   return new SpaceUnit
																		  {
																			  ContainsAsteroid = elem == '#'
																		  };
															   });

			return this;
		}
	}
}