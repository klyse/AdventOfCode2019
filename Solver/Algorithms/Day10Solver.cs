﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using NeoMatrix;
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

	public class Day10Solver
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

						if (!objective.ContainsAsteroid)
							continue;

						var vector = new Point(objective.Position.X - me.Position.X, objective.Position.Y - me.Position.Y);

						var lcm = LCM(vector.X, vector.Y);
						if (lcm is {} lcmV)
							vector = new Point(vector.X / lcmV, vector.Y / lcmV);


						if (vector.X == 0)
							vector.Y = vector.Y < 0 ? -1 : 1;

						if (vector.Y == 0)
							vector.X = vector.X < 0 ? -1 : 1;


						var relPoint = objective.Position;
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
					if (currentRange / 2 > input.Space.Rows && currentRange / 2 > input.Space.Columns)
						break;
				}

				var observatory = new Observatory
								  {
									  Space = space,
									  Location = new Point(j, i),
									  TotalVisibleAsteroids = space.GetFlat().Count(c => c.IsVisible) - 1
								  };
				observatories.Add(observatory);
			}

			return observatories.OrderByDescending(c => c.TotalVisibleAsteroids).First();
		}

		private static int LengthSquare(Point p1, Point p2)
		{
			var xDiff = p1.X - p2.X;
			var yDiff = p1.Y - p2.Y;
			return xDiff * xDiff + yDiff * yDiff;
		}

		private static double GetAngle(Point A, Point B, Point C)
		{
			// Square of lengths be a2, b2, c2 
			var a2 = LengthSquare(B, C);
			var b2 = LengthSquare(A, C);
			var c2 = LengthSquare(A, B);

			// length of sides be a, b, c 
			var a = (float)Math.Sqrt(a2);
			var b = (float)Math.Sqrt(b2);
			var c = (float)Math.Sqrt(c2);

			// From Cosine law 
			var alpha = (float)Math.Acos((b2 + c2 - a2) /
										 (2 * b * c));
			var betta = (float)Math.Acos((a2 + c2 - b2) /
										 (2 * a * c));
			var gamma = (float)Math.Acos((a2 + b2 - c2) /
										 (2 * a * b));

			// Converting to degree 
			alpha = (float)(alpha * 180 / Math.PI);
			betta = (float)(betta * 180 / Math.PI);
			gamma = (float)(gamma * 180 / Math.PI);

			return alpha;
		}

		public int Star2(Day10Input input)
		{
			var observatory = Star1(input);

			var maxX = (int)observatory.Space.Max(c => c.Position.X);

			var pt1 = observatory.Location;
			var pt3 = new Point(pt1.X + maxX + 100, pt1.Y);

			var positions = new List<SpaceUnitAngle>();

			foreach (var spaceUnit in observatory.Space.GetFlat().Where(c => c.IsVisible))
			{
				var sup = spaceUnit.Position;
				var pt2 = new Point(Math.Abs(sup.X), Math.Abs(sup.Y));
				var angle = GetAngle(pt1, pt2, pt3);
				var quad = -1;

				if (sup.X >= pt1.X && sup.Y < pt1.Y)
					quad = 0;
				else if (sup.X > pt1.X && sup.Y >= pt1.Y)
				{
					quad = 1;
					angle = -angle;
				}
				else if (sup.X <= pt1.X && sup.Y > pt1.Y)
				{
					quad = 2;
					angle = -angle;
				}
				else if (sup.X <= pt1.X && sup.Y <= pt1.Y)
					quad = 3;
				else
					throw new Exception("Missing param");

				positions.Add(new SpaceUnitAngle
							  {
								  SpaceUnit = spaceUnit,
								  Angle = angle,
								  Quadrant = quad
							  });
			}

			positions = positions.OrderBy(c => c.Quadrant)
								 .ThenByDescending(c => c.Angle)
								 .ToList();

			var p199 = positions[199];

			return p199.SpaceUnit.Position.X * 100 + p199.SpaceUnit.Position.Y;
		}

		private int? LCM(int a, int b)
		{
			a = Math.Abs(a);
			b = Math.Abs(b);

			if (a == 0 || b == 0)
				return null;

			var smallNr = Math.Max(a, b);
			while (true)
			{
				if (a % smallNr == 0 &&
					b % smallNr == 0)
					return smallNr;
				smallNr--;
			}
		}

		public class SpaceUnitAngle
		{
			public double Angle { get; set; }
			public int Quadrant { get; set; }
			public SpaceUnit SpaceUnit { get; set; }
		}
	}
}