using System.Linq;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class Solver1 : ISolver<int, Day1>
	{
		public int Solve(Day1 input)
		{
			return input.Data.GetFlat().Select(c => c / 3 - 2).Sum(c => c);
		}
	}
}