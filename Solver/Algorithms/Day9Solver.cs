using System;
using System.Collections.Generic;
using System.Linq;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class IntComputerV9
	{
		private int GetCommand(int command)
		{
			if (command > 10000)
				throw new Exception("Strange things happened");

			if (command > 100)
				return int.Parse(command.ToString().Substring(command.ToString().Length - 2));

			return command;
		}

		private IList<char> GetParams(int command)
		{
			var param = command.ToString().Reverse().Skip(2).ToList();
			if (param.Count < 1)
				param.Add('0');
			if (param.Count < 2)
				param.Add('0');

			return param;
		}

		private int GetIndexFromParam(char param, int myCursor)
		{
			if (param == '0')
				return Commands[myCursor];
			if (param == '1')
				return myCursor;

			return -1;
		}

		int _cursor;
		public int[] Commands { get; set; }

		public int IntComputer(int inputCommand)
		{
			_cursor = 0;
			var output = -1;

			while (true)
			{
				var command = Commands[_cursor];

				var cleanCommand = GetCommand(command);

				if (cleanCommand == 99)
					return output;

				var param = GetParams(command);

				var a1 = GetIndexFromParam(param[0], _cursor + 1);

				// input
				if (cleanCommand == 3)
				{
					Commands[a1] = inputCommand;
					_cursor += 2;
					continue;
				}

				// output
				if (cleanCommand == 4)
				{
					output = Commands[a1];
					Console.WriteLine(output);
					_cursor += 2;
					continue;
				}

				var a2 = GetIndexFromParam(param[1], _cursor + 2);
				var pos = Commands[_cursor + 3];

				if (pos == _cursor)
					throw new Exception("Cursor is equal to position");

				if (pos < 0)
					pos = Commands.Length + pos;

				// addition
				if (cleanCommand == 1)
				{
					var val = Commands[a2] + Commands[a1];
					_cursor += 4;
					Commands[pos] = val;
					continue;
				}

				// multiplication
				if (cleanCommand == 2)
				{
					var val = Commands[a2] * Commands[a1];
					_cursor += 4;
					Commands[pos] = val;
					continue;
				}

				// jump-if-true
				if (cleanCommand == 5)
				{
					if (Commands[a1] > 0)
						_cursor = Commands[a2];
					else
						_cursor += 3;
					continue;
				}

				// jump-if-false
				if (cleanCommand == 6)
				{
					if (Commands[a1] == 0)
						_cursor = Commands[a2];
					else
						_cursor += 3;
					continue;
				}

				// less than
				if (cleanCommand == 7)
				{
					var val = 0;
					if (Commands[a1] < Commands[a2])
						val = 1;
					_cursor += 4;
					Commands[pos] = val;
					continue;
				}

				// equals
				if (cleanCommand == 8)
				{
					var val = 0;
					if (Commands[a1] == Commands[a2])
						val = 1;
					_cursor += 4;
					Commands[pos] = val;
					continue;
				}

				throw new Exception("Strange things happened");
			}
		}
	}

	public class Day9Solver : ISolver<int, Day9Input>
	{
		public int Star1(Day9Input input)
		{
			var intComputer = new IntComputerV9();

			intComputer.Commands = input.Commands;
			return intComputer.IntComputer(input.Input);
		}

		public int Star2(Day9Input input)
		{
			throw new NotImplementedException();
		}
	}
}