using System;
using NUnit.Framework;
using Solver;
using Solver.Algorithms;
using Solver.Model;

namespace Test
{
	public class Day3Test
	{
		private const string File = "day3.txt";
		private Day3Solver _solver;

		[SetUp]
		public void SetUp()
		{
			_solver = new Day3Solver();
		}

		[Test]
		[TestCase("", ExpectedResult = 2)]
		public int Example1(string inp)
		{
			var inputStr = new[] { inp };
			var input = new Day3Input().Parse(inputStr);

			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			return solution;
		}

		[Test]
		public void Star1()
		{
			var fileInput = File.Read();
			var input = new Day3Input().Parse(fileInput);

			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.AreEqual(4090689, solution);
		}

		[Test]
		public void Star2()
		{
			var fileInput = File.Read();
			var input = new Day3Input().Parse(fileInput);

			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.Pass();
			Assert.AreEqual(7733, solution);
		}
	}
}