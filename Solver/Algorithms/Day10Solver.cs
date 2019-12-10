using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using NeoMatrix;
using Solver.Base;
using Solver.Model;
using Region = NeoMatrix.Region;

namespace Solver.Algorithms
{
	public class Observatory
	{
		public Matrix<SpaceUnit> Space { get; set; }
		public int TotalVisibleAsteroids { get; set; }
		public Point Location { get; set; }
	}

	public static class MatrixExtensions
	{
		public static Matrix<SpaceUnit> GetRectFillInvalid(this Matrix<SpaceUnit> mat, Region region)
		{
			var t = new Matrix<SpaceUnit>(region.Height, region.Width);

			var r = 0;
			var c = 0;
			for (var i = region.Top; i < region.Bottom; i++, r++, c = 0)
			for (var j = region.Left; j < region.Right; j++, c++)
				if (i >= 0 && i < mat.Columns &&
					j >= 0 && j < mat.Rows)
					t[r, c] = mat[i, j];
				else
					t[r, c] = new SpaceUnit
							  {
								  Position = new Point(-1, -1)
							  };

			return t;
		}
	}

	public class Day10Solver : ISolver<Observatory, Day10Input>
	{
		public Observatory Star1(Day10Input input)
		{
			var observatories = new List<Observatory>();
			for (var i = 0; i < input.Space.Rows; i++)
			for (var j = 0; j < input.Space.Columns; j++)
			{
				var inputClone = (Day10Input)input.Clone();
				var space = inputClone.Space;
				var me = space[i, j];
				if (!me.ContainsAsteroid)
					continue;

				var currentRange = 1;
				while (true)
				{
					var region = space.GetRectFillInvalid(Region.FromCenter(i, j, currentRange, currentRange));

					for (var i1 = 0; i1 < region.Rows; i1++)
					for (var j1 = 0; j1 < region.Columns; j1++)
					{
						var objective = region[i1, j1];

						if (objective.Position == new Point(-1, -1))
							continue;
						if (objective.Position.Y == i && objective.Position.X == j)
							continue; // self

						var vector = new Point(objective.Position.X - me.Position.X, objective.Position.Y - me.Position.Y);

						var relPoint = me.Position;
						while (true)
						{
							relPoint = new Point(relPoint.X + vector.X, relPoint.Y + vector.Y);

							if (relPoint.X < 0 || relPoint.X >= input.Space.Columns ||
								relPoint.Y < 0 || relPoint.Y >= input.Space.Rows)
								break;

							space[relPoint.Y, relPoint.X].Shadowed = true;
						}
					}

					currentRange += 2;
					if (currentRange > input.Space.Rows && currentRange > input.Space.Columns)
						break;
				}

				var observatory = new Observatory
								  {
									  Space = space,
									  Location = new Point(j, i),
									  TotalVisibleAsteroids = space.GetFlat().Count(c => c.IsVisible)
								  };
				observatories.Add(observatory);

				observatory.Space.ToBitmap(c => c.Position == observatory.Location ? 255 : c.IsVisible ? 100 : c.ContainsAsteroid ? 50 : 0).Save(Path.Combine(EnvironmentConstants.OutputPath, $"day10_{i},{j}.bmp"));
			}

			return observatories.OrderByDescending(c => c.TotalVisibleAsteroids).First();
		}

		public Observatory Star2(Day10Input input)
		{
			throw new NotImplementedException();
		}
	}
}