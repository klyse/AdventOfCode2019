using System;
using System.Collections.Generic;
using System.Linq;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class IntComputerV9
	{
		private long GetCommand(long command)
		{
			if (command > 10000)
				throw new Exception("Strange things happened");

			if (command > 100)
				return long.Parse(command.ToString().Substring(command.ToString().Length - 2));

			return command;
		}

		private IList<char> GetParams(long command)
		{
			var param = command.ToString().Reverse().Skip(2).ToList();
			if (param.Count < 1)
				param.Add('0');
			if (param.Count < 2)
				param.Add('0');

			return param;
		}

		private long GetIndexFromParam(char param, long myCursor)
		{
			if (param == '0')
				return GetValue(myCursor); // position mode
			if (param == '1')
				return myCursor; // value mode / immediate mode
			if (param == '2')
				return GetValue(RelativeBase - myCursor); // position mode

			throw new Exception("Strange things happened");
		}

		private long GetNeutralPosition(long pos)
		{
			var cPos = pos;

			if (cPos < 0)
				cPos = _lastAccessedField + pos;

			if (cPos > Commands.Length)
				Array.Resize(ref _commands, Commands.Length + 1000 + (int)(Commands.Length - cPos));

			_lastAccessedField = Math.Max(_lastAccessedField, cPos);

			return cPos;
		}

		private long GetValue(long pos)
		{
			var cPos = GetNeutralPosition(pos);
			return Commands[cPos];
		}

		private void SetValue(long pos, long val)
		{
			var cPos = GetNeutralPosition(pos);
			Commands[cPos] = val;
		}

		long _cursor;
		long _lastAccessedField;
		private long[] _commands;

		public long[] Commands
		{
			get => _commands;
			set
			{
				_commands = value;
				_lastAccessedField = _commands.Length;
			}
		}

		public long RelativeBase { get; set; }
		public IList<long> Output { get; set; }

		public long Run(long inputCommand)
		{
			_cursor = 0;
			Output = new List<long>();
			long output = -1;

			while (true)
			{
				var optoCode = GetValue(_cursor);

				var command = GetCommand(optoCode);

				if (command == 99)
					return output;

				var param = GetParams(optoCode);

				var a1 = GetIndexFromParam(param[0], _cursor + 1);

				// input
				if (command == 3)
				{
					SetValue(a1, inputCommand);
					_cursor += 2;
					continue;
				}

				// output
				if (command == 4)
				{
					output = GetValue(a1);
					Output.Add(output);
					_cursor += 2;
					continue;
				}

				// reset relative base
				if (command == 9)
				{
					RelativeBase += GetValue(a1);
					_cursor += 2;
					continue;
				}

				var a2 = GetIndexFromParam(param[1], _cursor + 2);
				var pos = GetValue(_cursor + 3);

				if (pos == _cursor)
					throw new Exception("Cursor is equal to position");

				// addition
				if (command == 1)
				{
					var val = GetValue(a2) + GetValue(a1);
					_cursor += 4;
					SetValue(pos, val);
					continue;
				}

				// multiplication
				if (command == 2)
				{
					var val = GetValue(a2) * GetValue(a1);
					_cursor += 4;
					SetValue(pos, val);
					continue;
				}

				// jump-if-true
				if (command == 5)
				{
					if (GetValue(a1) > 0)
						_cursor = GetValue(a2);
					else
						_cursor += 3;
					continue;
				}

				// jump-if-false
				if (command == 6)
				{
					if (GetValue(a1) == 0)
						_cursor = GetValue(a2);
					else
						_cursor += 3;
					continue;
				}

				// less than
				if (command == 7)
				{
					var val = 0;
					if (GetValue(a1) < GetValue(a2))
						val = 1;
					_cursor += 4;
					SetValue(pos, val);
					continue;
				}

				// equals
				if (command == 8)
				{
					var val = 0;
					if (GetValue(a1) == GetValue(a2))
						val = 1;
					_cursor += 4;
					SetValue(pos, val);

					continue;
				}

				throw new Exception("Strange things happened");
			}
		}
	}

	public class Day9Solver : ISolver<long, Day9Input>
	{
		public long Star1(Day9Input input)
		{
			var intComputer = new IntComputerV9();

			intComputer.Commands = input.Commands;
			var lastOut = intComputer.Run(input.Input);

			if (intComputer.Output.Count> 1)
				throw new Exception("Faulting error code");

			return lastOut;
		}

		public long Star2(Day9Input input)
		{
			throw new NotImplementedException();
		}
	}
}