using System.Linq;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class Solver1Star2 : ISolver<int, Day1>
	{
		public int Solve(Day1 input)
		{
			var fuel = input.Data.GetFlat().Select(c =>
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