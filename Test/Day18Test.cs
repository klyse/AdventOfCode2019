using System;
using NUnit.Framework;
using Solver;
using Solver.Algorithms;
using Solver.Model;

namespace Test
{
	public class Day18Test
	{
		private const string File = "day18.txt";
		private Day18Input _input;
		private Day18Solver _solver;

		[SetUp]
		public void SetUp()
		{
			_solver = new Day18Solver();
			_input = new Day18Input();
		}

		[Test]
		public void Example1_1()
		{
			var inputStr = new[]
						   {
							   "#########",
							   "#b.A.@.a#",
							   "#########"
						   };
			var input = _input.Parse(inputStr);

			var solution = _solver.Star1(input);

			Assert.AreEqual(8, solution);
		}

		[Test]
		public void Example1_2()
		{
			var inputStr = new[]
						   {
							   "########################",
							   "#f.D.E.e.C.b.A.@.a.B.c.#",
							   "######################.#",
							   "#d.....................#",
							   "########################"
						   };
			var input = _input.Parse(inputStr);

			var solution = _solver.Star1(input);

			Assert.AreEqual(86, solution);
		}

		[Test]
		public void Example1_3()
		{
			var inputStr = new[]
						   {
							   "########################",
							   "#...............b.C.D.f#",
							   "#.######################",
							   "#.....@.a.B.c.d.A.e.F.g#",
							   "########################"
						   };
			var input = _input.Parse(inputStr);

			var solution = _solver.Star1(input);

			Assert.AreEqual(132, solution);
		}

		[Test]
		public void Example1_4()
		{
			var inputStr = new[]
						   {
							   "#################",
							   "#i.G..c...e..H.p#",
							   "########.########",
							   "#j.A..b...f..D.o#",
							   "########@########",
							   "#k.E..a...g..B.n#",
							   "########.########",
							   "#l.F..d...h..C.m#",
							   "#################"
						   };
			var input = _input.Parse(inputStr);

			var solution = _solver.Star1(input);

			Assert.AreEqual(136, solution);
		}

		[Test]
		public void Example1_5()
		{
			var inputStr = new[]
						   {
							   "########################",
							   "#@..............ac.GI.b#",
							   "###d#e#f################",
							   "###A#B#C################",
							   "###g#h#i################",
							   "########################"
						   };
			var input = _input.Parse(inputStr);

			var solution = _solver.Star1(input);

			Assert.AreEqual(2210736, solution);
		}

		[Test]
		public void Star1()
		{
			var fileInput = File.Read();
			var input = _input.Parse(fileInput);
			var solution = _solver.Star1(input);

			Console.WriteLine(solution);
			Assert.AreEqual(399063, solution);
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