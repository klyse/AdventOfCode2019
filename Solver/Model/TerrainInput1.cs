using System.Linq;
using NeoMatrix;
using Solver.Base;

namespace Solver.Model
{
	public class TerrainInput1 : IInput<TerrainInput1>
	{
		public Matrix<int> Data;

		public TerrainInput1 Parse(string[] values)
		{
			var val = values.First().Split(' ').Select(int.Parse).ToList();

			Data = new Matrix<int>(val[1], val[0]);

			var row = 0;
			foreach (var item in values.Skip(1))
			{
				var col = 0;
				foreach (var cell in item.Split(' ').Select(int.Parse))
				{
					Data[row, col] = cell;
					col++;
				}

				row++;
			}

			return this;
		}
	}
}