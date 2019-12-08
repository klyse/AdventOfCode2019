using System;
using System.Collections.Generic;
using System.Linq;
using NeoMatrix;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class Day8Solver : ISolver<int, Day8Input>
	{
		public int Star1(Day8Input input)
		{
			var layers = input.Pixels.Length / (input.Columns * input.Rows);

			var matCol = new List<Matrix<int>>();

			var index = 0;
			for (var layer = 0; layer < layers; layer++)
			{
				matCol.Add(new Matrix<int>(input.Rows, input.Columns));
				for (var i = 0; i < input.Rows; i++)
				for (var j = 0; j < input.Columns; j++)
				{
					matCol[layer][i, j] = input.Pixels[index];
					index++;
				}
			}

			var min0 = int.MaxValue;
			var minLayerIndex = -1;
			for (var layer = 0; layer < layers; layer++)
			{
				var m = matCol[layer].GetFlat().Count(c => c == 0);
				if (m < min0)
				{
					min0 = m;
					minLayerIndex = layer;
				}
			}

			var checkSum = matCol[minLayerIndex].GetFlat().Count(c => c == 1) * matCol[minLayerIndex].GetFlat().Count(c => c == 2);

			return checkSum;
		}

		public int Star2(Day8Input input)
		{
			throw new NotImplementedException();
		}
	}
}