using System;
using System.Diagnostics;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class Day2Solver : ISolver<int, Day2Input>
	{
		public int Star1(Day2Input input)
		{
			var cursor = 0;
			while (true)
			{
				var command = input.Commands[cursor];

				if (command == 99)
					return input.Commands[0];

				var v1 = input.Commands[input.Commands[cursor + 1]];
				var v2 = input.Commands[input.Commands[cursor + 2]];
				var pos = input.Commands[cursor + 3];

				var val = 0;
				if (command == 1)
					val = v1 + v2;
				else if (command == 2)
					val = v1 * v2;
				else
					// something went wrong
					Debugger.Break();

				cursor += 4;

				input.Commands[pos] = val;
			}
		}

		public int Star2(Day2Input input)
		{
			throw new NotImplementedException();
		}
	}
}