using System;
using System.Linq;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class Day16Solver : ISolver<string, Day16Input>
	{
		public int[,] CalculatePattern(int[] numbers, int[] basePattern)
		{
			var pattern = new int[numbers.Length, numbers.Length];
			for (var i = 0; i < numbers.Length; ++i)
			{
				var cnt = 0;
				var p = 0;
				bool first = true;
				do
				{
					for (var r = 0; r <= i; r++)
					{
						pattern[i, cnt] = basePattern[p % 4];
						if (!first)
							cnt++;
						first = false;
						if (cnt >= numbers.Length)
							break;
					}

					p++;
				} while (cnt < numbers.Length);
			}

			return pattern;
		}

		public int[] Iterate(int[] numbers, int[,] pattern)
		{
			var newInput = new int[numbers.Length];
			for (var i = 0; i < numbers.Length; i++)
			{
				var res = 0;
				for (var j = 0; j < numbers.Length; j++)
				{
					res += pattern[i, j] * numbers[j];
				}

				newInput[i] = Math.Abs(res % 10);
			}

			return newInput;
		}

		public string Star1(Day16Input input)
		{
			var pattern = CalculatePattern(input.Numbers, input.BasePattern);

			var numbers = input.Numbers;
			for (var i = 0; i < input.Iterations; i++)
				numbers = Iterate(numbers, pattern);

			return new string(string.Join(string.Empty, numbers).Take(8).ToArray());
		}

		public string Star2(Day16Input input)
		{
			var numbers = input.Numbers;
			var pattern = CalculatePattern(numbers, input.BasePattern);

			for (var i = 0; i < input.Iterations; i++)
				numbers = Iterate(numbers, pattern);

			
			var extNums = new int[input.Numbers.Length * 10000];
			for (int i = 0; i < 10000; i++)
			{
				numbers.CopyTo(extNums, i * input.Numbers.Length);
			}

			var numString = string.Join(string.Empty, extNums);
			var offset = int.Parse(string.Join(string.Empty, numString.Take(7)));

			return new string(numString.Skip(offset).Take(8).ToArray());
		}
	}
}