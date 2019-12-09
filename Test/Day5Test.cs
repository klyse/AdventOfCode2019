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
		public void Star1()
		{
			var fileInput = File.Read();
			var input = _input.Parse(fileInput);
			input.Input = 1;
			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.AreEqual(9938601, solution);
		}

		[Test]
		[TestCase("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", 12, ExpectedResult = 1)]
		[TestCase("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", 1123, ExpectedResult = 1)]
		[TestCase("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", 0, ExpectedResult = 0)]
		[TestCase("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", 0, ExpectedResult = 0)]
		[TestCase("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", 6, ExpectedResult = 999)]
		[TestCase("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", 8, ExpectedResult = 1000)]
		[TestCase("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", 9, ExpectedResult = 1001)]
		public int Example2(string inp1, int inputCommand)
		{
			var inputStr = new[] { inp1 };
			var input = _input.Parse(inputStr);
			input.Input = inputCommand;

			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			return solution;
		}

		[Test]
		public void Star2()
		{
			var fileInput = File.Read();
			var input = _input.Parse(fileInput);

			input.Input = 5;

			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.AreEqual(4283952, solution);
		}
	}
}