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
			var inputCommand = 1;
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

					input.Commands[addr1] = inputCommand;
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

				//var reqPos1 = input.Commands[cursor + 1];
				//var reqPos2 = input.Commands[cursor + 2];
				//var maxPos = Math.Max(reqPos2, reqPos1);
				//if (maxPos > input.Commands.Length)
				//{
				//	var delta = maxPos - input.Commands.Length;
				//	Array.Resize(ref input.Commands, input.Commands.Length + delta);
				//}


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
			throw new NotImplementedException();
		}
	}
}