using System.Linq;
using NeoMatrix;
using Solver.Base;

namespace Solver.Model
{
	public class Day1 : IInput<Day1>
	{
		public Matrix<int> Data;

		public Day1 Parse(string[] values)
		{
			var row = -1;
			Data = Matrix<int>.NewMatrix(values.Length, 1, () =>
														   {
															   row++;
															   return int.Parse(values[row]);
														   });

			return this;
		}
	}
}