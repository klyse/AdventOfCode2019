using System;
using NUnit.Framework;
using Solver;
using Solver.Algorithms;
using Solver.Model;

namespace Test
{
	public class Day12Test
	{
		private const string File = "day12.txt";
		private Day12Input _input;
		private Day12Solver _solver;

		[SetUp]
		public void SetUp()
		{
			_solver = new Day12Solver();
			_input = new Day12Input();
		}

		[Test]
		[TestCase("")]
		public void Example1(string inp1)
		{
			var inputStr = new[] { inp1 };
			var input = _input.Parse(inputStr);

			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.Pass();
		}

		[Test]
		public void Star1()
		{
			var fileInput = File.Read();
			var input = _input.Parse(fileInput);
			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.Pass();
			Assert.AreEqual("1620", solution);
		}

		[Test]
		public void Star2()
		{
			var fileInput = File.Read();
			var input = _input.Parse(fileInput);

			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.Pass();
			Assert.AreEqual("BCYEF", solution);
		}
	}
}