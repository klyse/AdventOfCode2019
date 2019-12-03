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
		[TestCase("R8,U5,L5,D3", "U7,R6,D4,L4", ExpectedResult = 6)]
		[TestCase("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", ExpectedResult = 159)]
		[TestCase("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", ExpectedResult = 135)]
		public int Example1(string inp1, string inp2)
		{
			var inputStr = new[] { inp1, inp2 };
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
			Assert.AreEqual(1084, solution);
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