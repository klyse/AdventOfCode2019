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

			solution.Space.ToBitmap(c => c.ContainsAsteroid ? 100 : 0).Save(Path.Combine(EnvironmentConstants.OutputPath, "day10_1.bmp"));

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

			solution.Space.ToBitmap(c => c.ContainsAsteroid ? 100 : 0).Save(Path.Combine(EnvironmentConstants.OutputPath, "day10_2.bmp"));

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

			solution.Space.ToBitmap(c => c.ContainsAsteroid ? 100 : 0).Save(Path.Combine(EnvironmentConstants.OutputPath, "day10_3.bmp"));

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

			solution.Space.ToBitmap(c => c.ContainsAsteroid ? 100 : 0).Save(Path.Combine(EnvironmentConstants.OutputPath, "day10_4.bmp"));

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

			solution.Space.ToBitmap(c => c.ContainsAsteroid ? 100 : 0).Save(Path.Combine(EnvironmentConstants.OutputPath, "day10_5.bmp"));

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
			Assert.Pass();
			Assert.AreEqual(2494485073, solution);
		}

		//[Test]
		//[TestCase("", ExpectedResult = 0)]
		//public long Example2(string inp1)
		//{
		//	var inputStr = new[] { inp1 };
		//	var input = _input.Parse(inputStr);

		//	var solution = _solver.Star2(input);

		//	Console.WriteLine(solution);
		//	return solution;
		//}

		[Test]
		public void Star2()
		{
			var fileInput = File.Read();
			var input = _input.Parse(fileInput);
			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.Pass();
			Assert.AreEqual(44997, solution);
		}
	}
}