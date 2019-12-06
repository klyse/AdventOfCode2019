using System;
using NUnit.Framework;
using Solver;
using Solver.Algorithms;
using Solver.Model;

namespace Test
{
	public class Day6Test
	{
		private const string File = "day6.txt";
		private Day6Input _input;
		private Day6Solver _solver;

		[SetUp]
		public void SetUp()
		{
			_solver = new Day6Solver();
			_input = new Day6Input();
		}

		[Test]
		public void Example1()
		{
			var inputStr = new[]
						   {
							   "COM)B",
							   "B)C",
							   "C)D",
							   "D)E",
							   "E)F",
							   "B)G",
							   "G)H",
							   "D)I",
							   "E)J",
							   "J)K",
							   "K)L"
						   };
			var input = _input.Parse(inputStr);

			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.AreEqual(42, solution);
		}

		[Test]
		public void Star1()
		{
			var fileInput = File.Read();
			var input = _input.Parse(fileInput);
			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.Pass();
			Assert.AreEqual(9938601, solution);
		}

		[Test]
		public void Example2()
		{
			var inputStr = new[]
						   {
							   "COM)B",
							   "B)C",
							   "C)D",
							   "D)E",
							   "E)F",
							   "B)G",
							   "G)H",
							   "D)I",
							   "E)J",
							   "J)K",
							   "K)L",
							   "K)YOU",
							   "I)SAN"
						   };
			var input = _input.Parse(inputStr);

			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.AreEqual(4, solution);
		}

		[Test]
		public void Star2()
		{
			var fileInput = File.Read();
			var input = _input.Parse(fileInput);
			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.AreEqual(475, solution);
		}
	}
}