using System;
using NUnit.Framework;
using Solver;
using Solver.Algorithms;
using Solver.Model;

namespace Test
{
	public class Day11Test
	{
		private const string File = "day11.txt";
		private Day11Input _input;
		private Day11Solver _solver;

		[SetUp]
		public void SetUp()
		{
			_solver = new Day11Solver();
			_input = new Day11Input();
		}

		[Test]
		public void Star1()
		{
			var fileInput = File.Read();
			var input = _input.Parse(fileInput);
			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.AreEqual("2415", solution);
		}

		[Test]
		public void Star2()
		{
			var fileInput = File.Read();
			var input = _input.Parse(fileInput);
			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.AreEqual("2415", solution);
		}
	}
}