using System;
using NUnit.Framework;
using Solver;
using Solver.Algorithms;
using Solver.Model;

namespace Test
{
	public class Day24Test
	{
		private const string File = "day24.txt";
		private Day24Input _input;
		private Day24Solver _solver;

		[SetUp]
		public void SetUp()
		{
			_solver = new Day24Solver();
			_input = new Day24Input();
		}

		[Test]
		public void Example1()
		{
			var inputStr = new[]
						   {
							   "....#",
							   "#..#.",
							   "#..##",
							   "..#..",
							   "#...."
						   };

			var input = _input.Parse(inputStr);

			var solution = _solver.Star1(input);
			Assert.AreEqual(2129920, solution);
		}

		[Test]
		public void Star1()
		{
			var fileInput = File.Read();
			var input = _input.Parse(fileInput);
			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.Pass();
			Assert.AreEqual(2604, solution);
		}

		[Test]
		public void Star2()
		{
			var fileInput = File.Read();
			var input = _input.Parse(fileInput);

			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.Pass();
			Assert.AreEqual(9240, solution);
		}
	}
}