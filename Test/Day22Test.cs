using System;
using NUnit.Framework;
using Solver;
using Solver.Algorithms;
using Solver.Model;

namespace Test
{
	public class Day22Test
	{
		private const string File = "day22.txt";
		private Day22Input _input;
		private Day22Solver _solver;

		[SetUp]
		public void SetUp()
		{
			_solver = new Day22Solver();
			_input = new Day22Input();
		}
		
		[Test]
		public void Example1_1()
		{
			var inputStr = new[]
						   {
							   "deal with increment 7",
							   "deal into new stack",
							   "deal into new stack"
						   };
			var input = _input.Parse(inputStr);

			var solution = _solver.Shuffle();

			CollectionAssert.AreEqual(new [] {0,3,6,9,2,5,8,1,4,7}, solution);
		}
		[Test]
		public void Example1_2()
		{
			var inputStr = new[]
						   {
							   "cut 6",
							   "deal with increment 7",
							   "deal into new stack"
						   };
			var input = _input.Parse(inputStr);

			var solution = _solver.Shuffle();

			CollectionAssert.AreEqual(new [] {3,0,7,4,1,8,5,2,9,6}, solution);
		}
		
		[Test]
		public void Example1_3()
		{
			var inputStr = new[]
						   {
							   "deal with increment 7",
							   "deal with increment 9",
							   "cut -2"
						   };
			var input = _input.Parse(inputStr);

			var solution = _solver.Shuffle();

			CollectionAssert.AreEqual(new[] { 6, 3, 0, 7, 4, 1, 8, 5, 2, 9 }, solution);
		}

		[Test]
		public void Example1_4()
		{
			var inputStr = new[]
						   {
							   "deal into new stack",
							   "cut -2",
							   "deal with increment 7",
							   "cut 8",
							   "cut -4",
							   "deal with increment 7",
							   "cut 3",
							   "deal with increment 9",
							   "deal with increment 3",
							   "cut -1"
						   };
			var input = _input.Parse(inputStr);

			var solution = _solver.Shuffle();

			CollectionAssert.AreEqual(new[] { 9, 2, 5, 8, 1, 4, 7, 0, 3, 6 }, solution);
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