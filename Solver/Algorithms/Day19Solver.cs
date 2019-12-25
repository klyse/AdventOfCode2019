using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NeoMatrix;
using Solver.Base;
using Solver.Model;
using Region = NeoMatrix.Region;

namespace Solver.Algorithms
{
	public class IntComputerV19
	{
		private long[] _commands;

		private long _cursor;
		private int _inputCounter;

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

		public long? Run(long[] inputCommand)
		{
			_cursor = 0;
			_inputCounter = 0;
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
					SetValue(a1, inputCommand[_inputCounter]);
					_inputCounter++;
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

	public class Day19Solver : ISolver<int, Day19Input>
	{
		public int Star1(Day19Input input)
		{
			var computer = new IntComputerV19();

			var totalCnt = 0;
			for (int i = 0; i < input.GridSize; i++)
			for (int j = 0; j < input.GridSize; j++)
			{
				computer.Commands = input.Commands;
				if (computer.Run(new long[] { i, j }) == 1)
					totalCnt++;
			}

			return totalCnt;
		}

		public int Star2(Day19Input input)
		{
			var mat = new Matrix<bool>(input.GridSize, input.GridSize);

			var gridSizeToFind = 99;

			var tuples = new List<Tuple<int, int>>();
			for (var i = 350; i < input.GridSize; ++i)
			for (var j = 900; j < input.GridSize; ++j)
				tuples.Add(new Tuple<int, int>(i, j));

			Parallel.ForEach(tuples, tuple =>
									 {
										 var computer = new IntComputerV19();
										 computer.Commands = input.Commands;
										 var (x, y) = tuple;
										 mat[x, y] = computer.Run(new long[] { x, y }) == 1;
									 });

			mat.ToBitmap(c => c ? 1 : 0).Save(Path.Combine(EnvironmentConstants.OutputPath, "day19.bmp"));

			for (var row = 0; row <= mat.Rows - gridSizeToFind - 1; ++row)
			for (var col = 0; col <= mat.Columns - gridSizeToFind - 1; ++col)
			{
				if (!mat[row, col + gridSizeToFind] ||
					!mat[row + gridSizeToFind, col]) continue;

				mat.ToBitmap((r, c, v) =>
							 {
								 if (c == col && r == row)
									 return Color.FromArgb(100, Color.Green);

								 if (c == col || r == row ||
									 c == col + gridSizeToFind || r == row + gridSizeToFind)
									 return Color.FromArgb(100, Color.Red);

								 if (v)
									 return Color.Black;
								 return Color.White;
							 }).Save(Path.Combine(EnvironmentConstants.OutputPath, $"day19-highlighted-{col},{row}.bmp"));

				return row * 10000 + col; // row / column is switched... idk why...
			}

			throw new Exception("Not Found");
		}
	}
}