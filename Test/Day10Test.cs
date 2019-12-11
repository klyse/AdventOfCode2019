using System;
using System.Drawing;
using System.IO;
using NeoMatrix;
using NUnit.Framework;
using Solver;
using Solver.Algorithms;
using Solver.Model;

namespace Test
{
	public class Day10Test
	{
		private const string File = "day10.txt";
		private Day10Input _input;
		private Day10Solver _solver;

		[SetUp]
		public void SetUp()
		{
			_solver = new Day10Solver();
			_input = new Day10Input();
		}

		[Test]
		public void Example1_1()
		{
			var inputStr = new[]
						   {
							   ".#..#",
							   ".....",
							   "#####",
							   "....#",
							   "...##"
						   };
			var input = _input.Parse(inputStr);

			var solution = _solver.Star1(input);

			solution.Space.ToBitmap(c => c.Position == solution.Location ? 255 : c.IsVisible ? 100 : c.ContainsAsteroid ? 50 : 0).Save(Path.Combine(EnvironmentConstants.OutputPath, $"day10/1_{solution.Location.X},{solution.Location.Y}.bmp"));


			Assert.AreEqual(8, solution.TotalVisibleAsteroids);
			Assert.AreEqual(new Point(3, 4), solution.Location);
		}

		[Test]
		public void Example1_2()
		{
			var inputStr = new[]
						   {
							   "......#.#.",
							   "#..#.#....",
							   "..#######.",
							   ".#.#.###..",
							   ".#..#.....",
							   "..#....#.#",
							   "#..#....#.",
							   ".##.#..###",
							   "##...#..#.",
							   ".#....####"
						   };
			var input = _input.Parse(inputStr);

			var solution = _solver.Star1(input);

			solution.Space.ToBitmap(c => c.Position == solution.Location ? 255 : c.IsVisible ? 100 : c.ContainsAsteroid ? 50 : 0).Save(Path.Combine(EnvironmentConstants.OutputPath, $"day10/2_{solution.Location.X},{solution.Location.Y}.bmp"));

			Assert.AreEqual(33, solution.TotalVisibleAsteroids);
			Assert.AreEqual(new Point(5, 8), solution.Location);
		}

		[Test]
		public void Example1_3()
		{
			var inputStr = new[]
						   {
							   "#.#...#.#.",
							   ".###....#.",
							   ".#....#...",
							   "##.#.#.#.#",
							   "....#.#.#.",
							   ".##..###.#",
							   "..#...##..",
							   "..##....##",
							   "......#...",
							   ".####.###."
						   };
			var input = _input.Parse(inputStr);

			var solution = _solver.Star1(input);

			solution.Space.ToBitmap(c => c.Position == solution.Location ? 255 : c.IsVisible ? 100 : c.ContainsAsteroid ? 50 : 0).Save(Path.Combine(EnvironmentConstants.OutputPath, $"day10/3_{solution.Location.X},{solution.Location.Y}.bmp"));

			Assert.AreEqual(new Point(1, 2), solution.Location);
			Assert.AreEqual(35, solution.TotalVisibleAsteroids);
		}

		[Test]
		public void Example1_4()
		{
			var inputStr = new[]
						   {
							   ".#..#..###",
							   "####.###.#",
							   "....###.#.",
							   "..###.##.#",
							   "##.##.#.#.",
							   "....###..#",
							   "..#.#..#.#",
							   "#..#.#.###",
							   ".##...##.#",
							   ".....#.#.."
						   };
			var input = _input.Parse(inputStr);

			var solution = _solver.Star1(input);

			solution.Space.ToBitmap(c => c.Position == solution.Location ? 255 : c.IsVisible ? 100 : c.ContainsAsteroid ? 50 : 0).Save(Path.Combine(EnvironmentConstants.OutputPath, $"day10/4_{solution.Location.X},{solution.Location.Y}.bmp"));

			Assert.AreEqual(new Point(6, 3), solution.Location);
			Assert.AreEqual(41, solution.TotalVisibleAsteroids);
		}

		[Test]
		public void Example1_5()
		{
			var inputStr = new[]
						   {
							   ".#..##.###...#######",
							   "##.############..##.",
							   ".#.######.########.#",
							   ".###.#######.####.#.",
							   "#####.##.#.##.###.##",
							   "..#####..#.#########",
							   "####################",
							   "#.####....###.#.#.##",
							   "##.#################",
							   "#####.##.###..####..",
							   "..######..##.#######",
							   "####.##.####...##..#",
							   ".#####..#.######.###",
							   "##...#.##########...",
							   "#.##########.#######",
							   ".####.#.###.###.#.##",
							   "....##.##.###..#####",
							   ".#.#.###########.###",
							   "#.#.#.#####.####.###",
							   "###.##.####.##.#..##"
						   };
			var input = _input.Parse(inputStr);

			var solution = _solver.Star1(input);

			solution.Space.ToBitmap(c => c.Position == solution.Location ? 255 : c.IsVisible ? 100 : c.ContainsAsteroid ? 50 : 0).Save(Path.Combine(EnvironmentConstants.OutputPath, $"day10/5_{solution.Location.X},{solution.Location.Y}.bmp"));

			Assert.AreEqual(new Point(11, 13), solution.Location);
			Assert.AreEqual(210, solution.TotalVisibleAsteroids);
		}

		[Test]
		public void Star1()
		{
			var fileInput = File.Read();
			var input = _input.Parse(fileInput);
			var solution = _solver.Star1(input);

			Console.WriteLine(solution.TotalVisibleAsteroids);

			solution.Space.ToBitmap(c => c.Position == solution.Location ? 255 : c.IsVisible ? 100 : c.ContainsAsteroid ? 50 : 0).Save(Path.Combine(EnvironmentConstants.OutputPath, $"day10/star1_{solution.Location.X},{solution.Location.Y}.bmp"));

			Assert.AreEqual(269, solution.TotalVisibleAsteroids);
		}

		private static int LengthSquare(Point p1, Point p2)
		{
			var xDiff = p1.X - p2.X;
			var yDiff = p1.Y - p2.Y;
			return xDiff * xDiff + yDiff * yDiff;
		}

		private static void PrintAngle(Point A, Point B, Point C)
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

			// printing all the angles 
			Console.WriteLine("alpha : " + alpha);
			Console.WriteLine("betta : " + betta);
			Console.WriteLine("gamma : " + gamma);

			Console.WriteLine("gamma + alpha : " + (gamma + alpha));
			Console.WriteLine("gamma + betta : " + (gamma + betta));
			Console.WriteLine("alpha + beta  : " + (alpha + betta));
			Console.WriteLine("alpha + gamma : " + (alpha + gamma));
			Console.WriteLine("beta + gamma  : " + (betta + gamma));
		}

		//.#....###24...#..
		//##...##.13#67..9#
		//##...#...5.8####.
		//..#.....X...###..
		//..#.#.....#....##
		[Test]
		[TestCase("1", 0, 2, 0, 100)]
		[TestCase("2", 1, 3, 0, 100)]
		[TestCase("3", 1, 2, 0, 100)]
		[TestCase("4", 2, 3, 0, 100)]
		[TestCase("5", 1, 1, 0, 100)]
		[TestCase("6", 3, 3, 0, 100)]
		[TestCase("7", 4, 3, 0, 100)]
		[TestCase("8", 3, 2, 0, 100)]
		[TestCase("9", 7, 3, 0, 100)]
		public void Example2_1(string num, int p2X, int p2Y, int p3X, int p3Y)
		{
			Console.WriteLine(num);
			PrintAngle(new Point(0, 0), new Point(p2X, p2Y), new Point(p3X, p3Y));
			Assert.Pass();
		}

		//.#....###.....#..
		//##...##...#.....#
		//##...#......1234.
		//..#.....X...5##..
		//..#.9.....8....76
		[TestCase("1", 4, 1, 0, 100)]
		[TestCase("2", 5, 1, 0, 100)]
		[TestCase("3", 6, 1, 0, 100)]
		[TestCase("4", 7, 1, 0, 100)]
		[TestCase("5", 4, 0, 0, 100)]

		//[TestCase("6", -1, 8, 0, 100)]
		//[TestCase("7", -1, 7, 0, 100)]
		//[TestCase("8", -1, 2, 0, 100)]
		//[TestCase("9", -1, -4, 0, 100)]
		[TestCase("6", 1, 8, 0, 100)]
		[TestCase("7", 1, 7, 0, 100)]
		[TestCase("8", 1, 2, 0, 100)]

		//[TestCase("9", -1, -4, 0, 100)]
		[TestCase("9", 1, 4, 0, 100)]
		public void Example2_2(string num, int p2X, int p2Y, int p3X, int p3Y)
		{
			Console.WriteLine(num);
			PrintAngle(new Point(0, 0), new Point(p2X, p2Y), new Point(p3X, p3Y));
			Assert.Pass();
		}

		//.8....###.....#..
		//56...9#...#.....#
		//34...7...........
		//..2.....X....##..
		//..1..............
		//[TestCase("1", -6, -1, 0, 100)]
		//[TestCase("2", -6, 0, 0,  100)]
		[TestCase("1", 6, 1, 0, 100)]
		[TestCase("2", 6, 0, 0, 100)]

		//[TestCase("3", -8, 1, 0,  100)]
		//[TestCase("4", -7, 1, 0,  100)]
		//[TestCase("5", -8, 2, 0,  100)]
		//[TestCase("6", -7, 2, 0,  100)]
		//[TestCase("7", -3, 1, 0,  100)]
		//[TestCase("8", -7, 3, 0,  100)]
		//[TestCase("9", -3, 2, 0,  100)]
		[TestCase("3", 8, 1, 0, 100)]
		[TestCase("4", 7, 1, 0, 100)]
		[TestCase("5", 8, 2, 0, 100)]
		[TestCase("6", 7, 2, 0, 100)]
		[TestCase("7", 3, 1, 0, 100)]
		[TestCase("8", 7, 3, 0, 100)]
		[TestCase("9", 3, 2, 0, 100)]
		public void Example2_3(string num, int p2X, int p2Y, int p3X, int p3Y)
		{
			Console.WriteLine(num);
			PrintAngle(new Point(0, 0), new Point(p2X, p2Y), new Point(p3X, p3Y));
			Assert.Pass();
		}

		[Test]
		public void Example2_4()
		{
			var inputStr = new[]
						   {
							   ".#..##.###...#######",
							   "##.############..##.",
							   ".#.######.########.#",
							   ".###.#######.####.#.",
							   "#####.##.#.##.###.##",
							   "..#####..#.#########",
							   "####################",
							   "#.####....###.#.#.##",
							   "##.#################",
							   "#####.##.###..####..",
							   "..######..##.#######",
							   "####.##.####...##..#",
							   ".#####..#.######.###",
							   "##...#.##########...",
							   "#.##########.#######",
							   ".####.#.###.###.#.##",
							   "....##.##.###..#####",
							   ".#.#.###########.###",
							   "#.#.#.#####.####.###",
							   "###.##.####.##.#..##"
						   };

			var input = _input.Parse(inputStr);
			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.AreEqual(802, solution);
		}

		[Test]
		public void Star2()
		{
			var fileInput = File.Read();
			var input = _input.Parse(fileInput);
			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.AreEqual(612, solution);
		}
	}
}