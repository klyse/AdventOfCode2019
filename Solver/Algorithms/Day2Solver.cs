using System;
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
					return -1;

				cursor += 4;

				input.Commands[pos] = val;
			}
		}

		public int Star2(Day2Input input)
		{
			for (var i = 0; i <= 99; i++)
			for (var j = 0; j <= 99; j++)
			{
				var command = (int[])input.Commands.Clone();
				command[1] = i;
				command[2] = j;

				var val = -1;
				try
				{
					val = Star1(new Day2Input
								{
									Commands = command
								});
				}
				catch (Exception)
				{
					Console.WriteLine("ex");
				}

				if (val == 19690720)
					return i * 100 + j;
			}

			throw new Exception("Not found");
		}
	}
}