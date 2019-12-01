using System;
using NUnit.Framework;
using Solver;
using Solver.Algorithms;
using Solver.Model;

namespace Test
{
	public class Solver1Test
	{
		[Test]
		public void Example1()
		{
			var inputStr = new[] { "12" };
			var input = new Day1().Parse(inputStr);

			var solution = new Solver1().Solve(input);

			Console.WriteLine(solution);
			Assert.AreEqual(2, solution);
		}

		[Test]
		public void Example2()
		{
			var inputStr = new[] { "14" };
			var input = new Day1().Parse(inputStr);

			var solution = new Solver1().Solve(input);

			Console.WriteLine(solution);
			Assert.AreEqual(2, solution);
		}

		[Test]
		[TestCase("day1.txt")]
		public void Star1(string file)
		{
			var fileInput = file.Read();
			var input = new Day1().Parse(fileInput);

			var solution = new Solver1().Solve(input);

			file.Write(solution.ToString());
			Console.WriteLine(solution);
			Assert.Pass();
		}
	}
}