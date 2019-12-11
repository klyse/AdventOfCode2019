using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class IntComputerV11
	{
		private long[] _commands;

		private long _cursor;
		private long _lastAccessedField;

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

		private long GetCommand(long command)
		{
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
			if (param.Count < 3)
				param.Add('0');

			return param;
		}

		private long GetAddressFromParam(char paramMode, long param)
		{
			if (paramMode == '0')
				return GetValue(param); // position mode
			if (paramMode == '1')
				return param; // value mode / immediate mode
			if (paramMode == '2')
				return GetValue(param) + RelativeBase; // relative base mode

			throw new Exception("Strange things happened");
		}

		private long GetNeutralPosition(long cursor)
		{
			if (cursor > Commands.Length)
				Array.Resize(ref _commands, Commands.Length + 1000 + (int)(cursor - Commands.Length));

			_lastAccessedField = Math.Max(_lastAccessedField, cursor);

			return cursor;
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

		public long? Run(long inputCommand)
		{
			//_cursor = 0;
			Output = new List<long>();
			long output = -1;

			while (true)
			{
				var opCode = GetValue(_cursor);

				var command = GetCommand(opCode);

				if (command == 99)
					return output;

				var param = GetParams(opCode);

				var a1 = GetAddressFromParam(param[0], _cursor + 1);

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
					if (Output.Count == 2)
						return null;

					continue;
				}

				// reset relative base
				if (command == 9)
				{
					RelativeBase += GetValue(a1);
					_cursor += 2;
					continue;
				}

				var a2 = GetAddressFromParam(param[1], _cursor + 2);

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

				var immediate = GetValue(_cursor + 3);
				var pos = param[2] == '2' ? immediate + RelativeBase : immediate;

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

	public class Day11Solver : ISolver<int, Day11Input>
	{
		public int Star1(Day11Input input)
		{
			var intComputer = new IntComputerV11();

			intComputer.Commands = input.Commands;

			var pos = new Point(0, 0);
			var currDir = 0;
			var positions = new Dictionary<Point, int>();
			var nrPoints = 0;
			var inputCommand = 0;
			while (true)
			{
				var lastOut = intComputer.Run(inputCommand);
				if (lastOut is {})
					return nrPoints;

				if (positions.ContainsKey(pos))
					positions[pos] = (int)intComputer.Output.First();
				else
				{
					positions.Add(pos, (int)intComputer.Output.First());
					nrPoints++;
				}

				// 90 deg left
				if (intComputer.Output.ElementAt(1) == 0)
					currDir = currDir - 1 < 0 ? 3 : currDir - 1;
				// 90 deg right
				else if (intComputer.Output.ElementAt(1) == 1)
					currDir = currDir + 1 > 3 ? 0 : currDir + 1;
				else
					throw new Exception("Wrong turn");

				// up
				if (currDir == 0)
					pos = new Point(pos.X, pos.Y + 1);
				// down
				else if (currDir == 2)
					pos = new Point(pos.X, pos.Y - 1);
				// right
				else if (currDir == 1)
					pos = new Point(pos.X + 1, pos.Y);
				// left
				else if (currDir == 3)
					pos = new Point(pos.X - 1, pos.Y);
				else
					throw new Exception("How did that direction come together??");

				if (positions.ContainsKey(pos))
					inputCommand = positions[pos];
				else
					inputCommand = 0;
			}
		}

		public int Star2(Day11Input input)
		{
			throw new NotImplementedException();
		}
	}
}