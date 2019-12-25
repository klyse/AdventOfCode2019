using System.Linq;
using NeoMatrix;
using Solver.Base;

namespace Solver.Model
{
	public class Day24Input : IInput<Day24Input>
	{
		public Matrix<bool[]> Eris { get; set; }

		public Day24Input Parse(string[] values)
		{
			Eris = Matrix<bool[]>.NewMatrix(values.Length, values.First().Length, (row, column) => new[]
																								   {
																									   values[row][column] == '#',
																									   false
																								   });
			return this;
		}
	}
}