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
		public void Example1()
		{
			var inputStr = new[] { "12" };
			var input = new Day2Input().Parse(inputStr);

			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.AreEqual(2, solution);
		}

		[Test]
		public void Example2()
		{
			var inputStr = new[] { "14" };
			var input = new Day2Input().Parse(inputStr);

			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.AreEqual(2, solution);
		}

		[Test]
		public void Star1()
		{
			var fileInput = File.Read();
			var input = new Day2Input().Parse(fileInput);

			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.AreEqual(3212842, solution);
		}

		[Test]
		public void Example3()
		{
			var inputStr = new[] { "14" };
			var input = new Day2Input().Parse(inputStr);

			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.AreEqual(2, solution);
		}

		[Test]
		public void Example4()
		{
			var inputStr = new[] { "1969" };
			var input = new Day2Input().Parse(inputStr);

			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.AreEqual(966, solution);
		}

		[Test]
		public void Example5()
		{
			var inputStr = new[] { "100756" };
			var input = new Day2Input().Parse(inputStr);

			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.AreEqual(50346, solution);
		}

		[Test]
		public void Test1()
		{
			var inputStr = new[] { "100756", "1969" };
			var input = new Day2Input().Parse(inputStr);

			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.AreEqual(50346 + 966, solution);
		}

		[Test]
		public void Star2()
		{
			var fileInput = File.Read();
			var input = new Day2Input().Parse(fileInput);

			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.AreEqual(4816402, solution);
		}
	}
}