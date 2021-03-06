using System;
using NUnit.Framework;
using Solver.Algorithms;
using Solver.Model;

namespace Test
{
	public class Day4Test
	{
		private Day4Input _input;
		private Day4Solver _solver;

		[SetUp]
		public void SetUp()
		{
			_solver = new Day4Solver();
			_input = new Day4Input();
		}

		[Test]
		[TestCase(111111, ExpectedResult = true)]
		[TestCase(111123, ExpectedResult = true)]
		[TestCase(135679, ExpectedResult = false)]
		[TestCase(122345, ExpectedResult = true)]
		[TestCase(223450, ExpectedResult = false)]
		[TestCase(123789, ExpectedResult = false)]
		public bool Example1(int inp1)
		{
			var solution = _solver.ValidNumber1(inp1);

			Console.WriteLine(solution);
			return solution;
		}

		[Test]
		public void Star1()
		{
			var fileInput = new[] { "347312-805915" };
			var input = _input.Parse(fileInput);

			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.AreEqual(594, solution);
		}

		[Test]
		[TestCase(112233, ExpectedResult = true)]
		[TestCase(111122, ExpectedResult = true)]
		[TestCase(123444, ExpectedResult = false)]
		[TestCase(347777, ExpectedResult = false)]
		public bool Example2(int inp1)
		{
			var solution = _solver.ValidNumber2(inp1);

			Console.WriteLine(solution);
			return solution;
		}

		[Test]
		public void Star2()
		{
			var fileInput = new[] { "347312-805915" };
			var input = _input.Parse(fileInput);

			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.AreEqual(364, solution);
		}
	}
}