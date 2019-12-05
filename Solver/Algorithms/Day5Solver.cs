using System;
using System.Diagnostics;
using System.Linq;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class Day5Solver : ISolver<int, Day5Input>
	{
		public int Star1(Day5Input input)
		{
			var cursor = 0;
			var output = -1;

			while (true)
			{
				var command = input.Commands[cursor];

				var cleanCommand = command;
				if (command > 10000)
					Debugger.Break();

				if (command > 100)
					cleanCommand = int.Parse(command.ToString().Substring(command.ToString().Length - 2));

				if (cleanCommand == 99)
					return output;


				var param = command.ToString().Reverse().Skip(2).ToList();
				if (param.Count < 1)
					param.Add('0');
				if (param.Count < 2)
					param.Add('0');

				var v1 = param[0] == '0' ? input.Commands[input.Commands[cursor + 1]] : input.Commands[cursor + 1];

				if (cleanCommand == 3)
				{
					var addr1 = param[0] == '0' ? input.Commands[cursor + 1] : cursor + 1;

					input.Commands[addr1] = input.Input;
					cursor += 2;
					continue;
				}

				if (cleanCommand == 4)
				{
					output = v1;
					Console.WriteLine(output);
					cursor += 2;
					continue;
				}

				var v2 = param[1] == '0' ? input.Commands[input.Commands[cursor + 2]] : input.Commands[cursor + 2];
				var pos = input.Commands[cursor + 3];

				var val = 0;
				if (cleanCommand == 1)
					val = v1 + v2;
				else if (cleanCommand == 2)
					val = v1 * v2;
				else
					return -1;

				cursor += 4;

				if (pos < 0)
					pos = input.Commands.Length + pos;

				input.Commands[pos] = val;
			}
		}

		public int Star2(Day5Input input)
		{
			var cursor = 0;
			var output = -1;

			while (true)
			{
				var command = input.Commands[cursor];

				var cleanCommand = command;
				if (command > 10000)
					Debugger.Break();

				if (command > 100)
					cleanCommand = int.Parse(command.ToString().Substring(command.ToString().Length - 2));

				if (cleanCommand == 99)
					return output;


				var param = command.ToString().Reverse().Skip(2).ToList();
				if (param.Count < 1)
					param.Add('0');
				if (param.Count < 2)
					param.Add('0');

				var v1 = param[0] == '0' ? input.Commands[input.Commands[cursor + 1]] : input.Commands[cursor + 1];

				if (cleanCommand == 3)
				{
					var addr1 = param[0] == '0' ? input.Commands[cursor + 1] : cursor + 1;

					input.Commands[addr1] = input.Input;
					cursor += 2;
					continue;
				}

				if (cleanCommand == 4)
				{
					output = v1;
					Console.WriteLine(output);
					cursor += 2;
					continue;
				}

				var v2 = param[1] == '0' ? input.Commands[input.Commands[cursor + 2]] : input.Commands[cursor + 2];
				var pos = input.Commands[cursor + 3];

				if (pos == cursor)
					throw new Exception("Cursor is equal to position");

				var val = 0;
				if (cleanCommand == 1)
				{
					val = v1 + v2;
					cursor += 4;
				}
				else if (cleanCommand == 2)
				{
					val = v1 * v2;
					cursor += 4;
				}
				// jump-if-true
				else if (cleanCommand == 5)
				{
					if (v1 > 0)
						cursor = v2;
					else
						cursor += 3;
					continue;
				}
				// jump-if-false
				else if (cleanCommand == 6)
				{
					if (v1 == 0)
						cursor = v2;
					else
						cursor += 3;
					continue;
				}
				// less than
				else if (cleanCommand == 7)
				{
					if (v1 < v2)
						val = 1;
					else
						val = 0;
					cursor += 4;
				}
				// equals
				else if (cleanCommand == 8)
				{
					if (v1 == v2)
						val = 1;
					else
						val = 0;
					cursor += 4;
				}
				else
					throw new Exception("Strange things happened");


				if (pos < 0)
					pos = input.Commands.Length + pos;

				input.Commands[pos] = val;
			}
		}
	}
}