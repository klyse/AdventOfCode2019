using System;
using System.Linq;
using NeoMatrix;
using Solver.Base;

namespace Solver.Model
{
	public static class MatrixExtensions
	{
		public static bool GetAbove(this Matrix<bool[]> matrix, int source, int row, int column)
		{
			if (row <= 0)
				return false;

			return matrix.GetAbove(row, column)[source];
		}

		public static bool GetBelow(this Matrix<bool[]> matrix, int source, int row, int column)
		{
			if (row >= matrix.Rows - 1)
				return false;

			return matrix.GetBelow(row, column)[source];
		}

		public static bool GetLeft(this Matrix<bool[]> matrix, int source, int row, int column)
		{
			if (column <= 0)
				return false;

			return matrix.GetLeft(row, column)[source];
		}

		public static bool GetRight(this Matrix<bool[]> matrix, int source, int row, int column)
		{
			if (column >= matrix.Columns - 1)
				return false;

			return matrix.GetRight(row, column)[source];
		}
	}

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

		public void Print(int index)
		{
			Console.WriteLine("________");
			for (var j = 0; j < Eris.Rows; ++j)
			{
				for (var i = 0; i < Eris.Columns; ++i)
				{
					Console.Write(Eris[j, i][index] ? '#' : '.');
				}

				Console.WriteLine();
			}
		}

		public int Tick(int source, int destination)
		{
			Eris.ExecuteOnAll((bools, row, column) =>
							  {
								  var neighbors = 0;

								  if (Eris.GetAbove(source, row, column))
									  neighbors++;
								  if (Eris.GetBelow(source, row, column))
									  neighbors++;
								  if (Eris.GetLeft(source, row, column))
									  neighbors++;
								  if (Eris.GetRight(source, row, column))
									  neighbors++;

								  bools[destination] = bools[source];

								  if (bools[source] && neighbors != 1)
									  bools[destination] = false;

								  if (!bools[source] && (neighbors == 1 || neighbors == 2))
									  bools[destination] = true;
							  });
			return GetHashCode(destination);
		}

		public int GetHashCode(int inx)
		{
			unchecked
			{
				var hashCode = Eris.Rows;
				hashCode = (hashCode * 397) ^ Eris.Columns;

				Eris.ExecuteOnAll((bools, row, column) =>
								  {
									  if (bools[inx])
									  {
										  hashCode = (hashCode * 397) ^ column;
										  hashCode = (hashCode * 397) ^ row;
									  }
								  });
				return hashCode;
			}
		}
	}
}