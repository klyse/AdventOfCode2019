using System;
using NUnit.Framework;
using Solver;
using Solver.Algorithms;
using Solver.Model;

namespace Test
{
	public class Day19Test
	{
		private const string File = "day19.txt";
		private Day19Input _input;
		private Day19Solver _solver;

		[SetUp]
		public void SetUp()
		{
			_solver = new Day19Solver();
			_input = new Day19Input();
		}

		[Test]
		public void Star1()
		{
			var fileInput = File.Read();
			var input = _input.Parse(fileInput);
			_input.GridSize = 50;
			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.AreEqual(166, solution);
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