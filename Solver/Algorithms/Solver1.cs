using System.Linq;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class Solver1 : ISolver<Output1, TerrainInput1>
	{
		public Output1 Solve(TerrainInput1 input)
		{
			var o = new Output1
					{
						Min = input.Data.GetFlat().Min(),
						Max = input.Data.GetFlat().Max(),
						Avg = (int)input.Data.GetFlat().Average()
					};

			return o;
		}
	}
}