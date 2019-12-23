using System;
using NUnit.Framework;
using Solver;
using Solver.Algorithms;
using Solver.Model;

namespace Test
{
	public class Day16Test
	{
		private const string File = "day16.txt";
		private Day16Input _input;
		private Day16Solver _solver;

		[SetUp]
		public void SetUp()
		{
			_solver = new Day16Solver();
			_input = new Day16Input();
		}

		[Test]
		[TestCase("12345678", ExpectedResult = "01029498")]
		public string Example1_1(string inp1)
		{
			var inputStr = new[] { inp1 };
			var input = _input.Parse(inputStr);
			input.Iterations = 4;

			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			return solution;
		}

		[Test]
		[TestCase("80871224585914546619083218645595", ExpectedResult = "24176176")]
		[TestCase("19617804207202209144916044189917", ExpectedResult = "73745418")]
		[TestCase("69317163492948606335995924319873", ExpectedResult = "52432133")]
		public string Example1_2(string inp1)
		{
			var inputStr = new[] { inp1 };
			var input = _input.Parse(inputStr);
			input.Iterations = 100;

			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			return solution;
		}

		[Test]
		public void Star1()
		{
			var fileInput = File.Read();
			var input = _input.Parse(fileInput);
			input.Iterations = 100;

			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.AreEqual("44098263", solution);
		}

		[Test]
		[TestCase("03036732577212944063491565474664", ExpectedResult = "84462026")]
		[TestCase("02935109699940807407585447034323", ExpectedResult = "78725270")]
		[TestCase("03081770884921959731165446850517", ExpectedResult = "53553731")]
		public string Example2(string inp1)
		{
			var inputStr = new[] { inp1 };
			var input = _input.Parse(inputStr);
			input.Iterations = 100;

			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			return solution;
		}

		[Test]
		public void Star2()
		{
			var fileInput = File.Read();
			var input = _input.Parse(fileInput);
			input.Iterations = 100;

			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.Pass();
			Assert.AreEqual(9240, solution);
		}
	}
}