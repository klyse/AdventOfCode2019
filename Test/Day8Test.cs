using System;
using NUnit.Framework;
using Solver;
using Solver.Algorithms;
using Solver.Model;

namespace Test
{
	public class Day8Test
	{
		private const string File = "day8.txt";
		private Day8Input _input;
		private Day8Solver _solver;

		[SetUp]
		public void SetUp()
		{
			_solver = new Day8Solver();
			_input = new Day8Input();
		}

		[Test]
		[TestCase("123456789012")]
		public void Example1(string inp1)
		{
			var inputStr = new[] { inp1, "2", "3" };
			var input = _input.Parse(inputStr);

			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.Pass();
		}

		[Test]
		public void Star1()
		{
			var fileInput = File.Read();
			var input = _input.Parse(new[] { fileInput[0], "6", "25" });
			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.AreEqual("1620", solution);
		}

		[Test]
		public void Star2()
		{
			var fileInput = File.Read();
			var input = _input.Parse(new[] { fileInput[0], "6", "25" });

			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.AreEqual("BCYEF", solution);
		}
	}
}