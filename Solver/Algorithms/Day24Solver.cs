using System;
using System.Collections.Generic;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class Day24Solver : ISolver<long, Day24Input>
	{
		public long Star1(Day24Input input)
		{
			var layouts = new HashSet<int>();
			var source = 0;
			var destination = 1;
			layouts.Add(input.GetHashCode(source));
			input.Print(source);

			while (true)
			{
				var hashCode = input.Tick(source, destination);
				if (layouts.Contains(hashCode))
					break;

				layouts.Add(hashCode);

				// switch field
				var tmp = destination;
				destination = source;
				source = tmp;
			}

			input.Print(destination);
			long total = 0;
			input.Eris.ExecuteOnAll((bools, row, column) =>
									{
										if (bools[destination])
										{
											long power = (int)Math.Pow(2, column + row * input.Eris.Columns);
											total += power;
										}
									});
			return total;
		}

		public long Star2(Day24Input input)
		{
			throw new NotImplementedException();
		}
	}
}