using System;
using System.Collections.Generic;
using System.Linq;
using Solver.Base;

namespace Solver.Model
{
	public class Moon : ICloneable
	{
		public Point3 Position { get; set; }
		public Point3 Vector { get; set; }

		public void UpdateVelocity(Point3 moon)
		{
			if (moon.X != Position.X)
				Vector.X += moon.X > Position.X ? 1 : -1;
			if (moon.Y != Position.Y)
				Vector.Y += moon.Y > Position.Y ? 1 : -1;
			if (moon.Z != Position.Z)
				Vector.Z += moon.Z > Position.Z ? 1 : -1;
		}

		public void Move()
		{
			Position.X += Vector.X;
			Position.Y += Vector.Y;
			Position.Z += Vector.Z;
		}

		public object Clone()
		{
			return new Moon
				   {
					   Position = (Point3)Position.Clone(),
					   Vector = (Point3)Vector.Clone()
				   };
		}

		public override int GetHashCode()
		{
			// ReSharper disable NonReadonlyMemberInGetHashCode
			return HashCode.Combine(Position, Vector);
			// ReSharper restore NonReadonlyMemberInGetHashCode
		}
	}

	public class Day12Input : IInput<Day12Input>
	{
		public int Steps { get; set; }
		public IList<Moon> Moons { get; set; }

		public Day12Input Parse(string[] values)
		{
			Moons = values.Select(c =>
								  {
									  var split = c.Split('=');
									  return new Moon
											 {
												 Position = new Point3(int.Parse(split.ElementAt(1).Split(',').First()),
																	   int.Parse(split.ElementAt(2).Split(',').First()),
																	   int.Parse(split.ElementAt(3).Split('>').First())
																	  ),
												 Vector = new Point3(0, 0, 0)
											 };
								  })
						  .ToList();
			return this;
		}
	}

	public class Point3 : IEquatable<Point3>, ICloneable
	{
		public int X { get; set; }
		public int Y { get; set; }
		public int Z { get; set; }

		public Point3(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public override string ToString()
		{
			//return $"x={X.ToString().PadLeft(4)} y={Y.ToString().PadLeft(4)} z={Z.ToString().PadLeft(4)}";
			return $"{X};{Y};{Z};";
		}

		public object Clone()
		{
			return new Point3(X, Y, Z);
		}

		public bool Equals(Point3 other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return X == other.X && Y == other.Y && Z == other.Z;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Point3)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = X;
				hashCode = (hashCode * 397) ^ Y;
				hashCode = (hashCode * 397) ^ Z;
				return hashCode;
			}
		}
	}
}