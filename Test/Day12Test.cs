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
		public void Example1_1()
		{
			var inputStr = new[]
						   {
							   "<x=-1, y=0, z=2>",
							   "<x=2, y=-10, z=-7>",
							   "<x=4, y=-8, z=8>",
							   "<x=3, y=5, z=-1>"
						   };
			var input = _input.Parse(inputStr);
			input.Steps = 10;

			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.AreEqual(179, solution);
		}

		[Test]
		public void Example1_2()
		{
			var inputStr = new[]
						   {
							   "<x=-8, y=-10, z=0>",
							   "<x=5, y=5, z=10>",
							   "<x=2, y=-7, z=3>",
							   "<x=9, y=-8, z=-3>"
						   };
			var input = _input.Parse(inputStr);
			input.Steps = 100;

			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.AreEqual(1940, solution);
		}

		[Test]
		public void Star1()
		{
			var fileInput = File.Read();
			var input = _input.Parse(fileInput);
			input.Steps = 1000;
			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.AreEqual(7687, solution);
		}


		[Test]
		public void Example2_1()
		{
			var inputStr = new[]
						   {
							   "<x=-1, y=0, z=2>",
							   "<x=2, y=-10, z=-7>",
							   "<x=4, y=-8, z=8>",
							   "<x=3, y=5, z=-1>"
						   };
			var input = _input.Parse(inputStr);

			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.AreEqual(2772, solution);
		}

		[Test]
		public void Example2_2()
		{
			var inputStr = new[]
						   {
							   "<x=-8, y=-10, z=0>",
							   "<x=5, y=5, z=10>",
							   "<x=2, y=-7, z=3>",
							   "<x=9, y=-8, z=-3>"
						   };
			var input = _input.Parse(inputStr);

			var solution = _solver.Star2(input);

			Console.WriteLine(solution);
			Assert.AreEqual(4686774924, solution);
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