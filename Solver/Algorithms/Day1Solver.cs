using System.Linq;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class Day1Solver : ISolver<int, Day1Input>
	{
		public int Star1(Day1Input input)
		{
			return input.Modules.Select(c => c / 3 - 2).Sum(c => c);
		}

		public int Star2(Day1Input input)
		{
			var fuel = input.Modules.Select(c =>
											{
												var calcFuel = c / 3 - 2;
												var addFuel = calcFuel;
												while (true)
												{
													addFuel = addFuel / 3 - 2;
													if (addFuel <= 0)
														break;
													calcFuel += addFuel;
												}

												return calcFuel;
											}).Sum(c => c);


			return fuel;
		}
	}
}