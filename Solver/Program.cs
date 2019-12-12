using System;
using Solver.Algorithms;
using Solver.Model;

namespace Solver
{
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine("Advent Of Code 2019");

			Console.WriteLine("by: Klyse");

			Console.WriteLine();
			Console.WriteLine("--------------------------");

			var inputStr = new[]
						   {
							   "<x=-8, y=-10, z=0>",
							   "<x=5, y=5, z=10>",
							   "<x=2, y=-7, z=3>",
							   "<x=9, y=-8, z=-3>"
						   };

			var input = new Day12Input();
			var solver = new Day12Solver();

			var inputV = input.Parse(inputStr);

			var solution = solver.Star2(inputV);

			Console.WriteLine(solution);

			Console.ReadLine();
		}
	}
}