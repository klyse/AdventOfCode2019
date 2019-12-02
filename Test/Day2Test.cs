using System;
using NUnit.Framework;
using Solver;
using Solver.Algorithms;
using Solver.Model;

namespace Test
{
	public class Day2Test
	{
		private const string File = "day2.txt";
		private Day2Solver _solver;

		[SetUp]
		public void SetUp()
		{
			_solver = new Day2Solver();
		}

		[Test]
		[TestCase("2,3,0,3,99", ExpectedResult = 2)]
		[TestCase("2,4,4,5,99,0", ExpectedResult = 2)]
		[TestCase("1,1,1,4,99,5,6,0,99", ExpectedResult = 30)]
		[TestCase("1,9,10,3,2,3,11,0,99,30,40,50", ExpectedResult = 3500)]
		public int Example1(string inp)
		{
			var inputStr = new[] { inp };
			var input = new Day2Input().Parse(inputStr);

			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			return solution;
		}

		[Test]
		public void Star1()
		{
			var fileInput = File.Read();
			var input = new Day2Input().Parse(fileInput);

			input.Commands[1] = 12;
			input.Commands[2] = 2;
			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.AreEqual(4090689, solution);
		}

		[Test]
		public void Star2()
		{
			var fileInput = File.Read();
			var input = new Day2Input().Parse(fileInput);

			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.Pass();
			Assert.AreEqual(7733, solution);
		}
	}
}