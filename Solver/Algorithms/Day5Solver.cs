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
			var inputArray = input.Commands;

			while (true)
			{
				var command = inputArray[cursor];

				var cleanCommand = command;
				if (command > 10000)
					Debugger.Break();

				if (command > 1000)
					cleanCommand = int.Parse(command.ToString().Substring(command.ToString().Length - 2));

				if (cleanCommand == 99)
					return output;

				if (cleanCommand == 3)
				{
					inputArray[inputArray[cursor + 1]] = inputCommand;
					cursor += 2;
					continue;
				}

				if (cleanCommand == 4)
				{
					output = inputArray[inputArray[cursor + 1]];
					Console.WriteLine(output);
					cursor += 2;
					continue;
				}

				var param = command.ToString().Reverse().Skip(2).ToList();
				if (param.Count < 1)
					param.Add('0');
				if (param.Count < 2)
					param.Add('0');

				//var reqPos1 = inputArray[cursor + 1];
				//var reqPos2 = inputArray[cursor + 2];
				//var maxPos = Math.Max(reqPos2, reqPos1);
				//if (maxPos > inputArray.Length)
				//{
				//	var delta = maxPos - inputArray.Length;
				//	Array.Resize(ref inputArray, inputArray.Length + delta);
				//}

				var v1 = param[0] == '0' ? inputArray[inputArray[cursor + 1]] : inputArray[cursor + 1];
				var v2 = param[1] == '0' ? inputArray[inputArray[cursor + 2]] : inputArray[cursor + 2];
				var pos = inputArray[cursor + 3];

				var val = 0;
				if (cleanCommand == 1)
					val = v1 + v2;
				else if (cleanCommand == 2)
					val = v1 * v2;
				else
					return -1;

				cursor += 4;

				if (pos < 0)
					pos = inputArray.Length + pos;

				inputArray[pos] = val;
			}
		}

		public int Star2(Day5Input input)
		{
			throw new NotImplementedException();
		}
	}
}