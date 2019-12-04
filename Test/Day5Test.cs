using System;
using NUnit.Framework;
using Solver;
using Solver.Algorithms;
using Solver.Model;

namespace Test
{
	public class Day5Test
	{
		private const string File = "day5.txt";
		private Day5Input _input;
		private Day5Solver _solver;

		[SetUp]
		public void SetUp()
		{
			_solver = new Day5Solver();
			_input = new Day5Input();
		}

		[Test]
		[TestCase("", ExpectedResult = 0)]
		public int Example1(string inp1)
		{
			var inputStr = new[] { inp1 };
			var input = _input.Parse(inputStr);

			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			return solution;
		}

		[Test]
		public void Star1()
		{
			var fileInput = File.Read();
			var input = _input.Parse(fileInput);

			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.AreEqual(1084, solution);
		}

		[Test]
		[TestCase("", ExpectedResult = 0)]
		public int Example2(string inp1)
		{
			var inputStr = new[] { inp1 };
			var input = _input.Parse(inputStr);

			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			return solution;
		}

		[Test]
		public void Star2()
		{
			var fileInput = File.Read();
			var input = _input.Parse(fileInput);

			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.AreEqual(9240, solution);
		}
	}
}