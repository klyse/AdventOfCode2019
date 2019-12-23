using System;
using System.Linq;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class Day16Solver : ISolver<string, Day16Input>
	{
		public int[,] CalculatePattern(Day16Input input)
		{
			var pattern = new int[input.Numbers.Length, input.Numbers.Length];
			for (var i = 0; i < input.Numbers.Length; ++i)
			{
				var cnt = 0;
				var p = 0;
				bool first = true;
				do
				{
					for (var r = 0; r <= i; r++)
					{
						pattern[i, cnt] = input.BasePattern[p % 4];
						if (!first)
							cnt++;
						first = false;
						if (cnt >= input.Numbers.Length)
							break;
					}

					p++;
				} while (cnt < input.Numbers.Length);
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
			var pattern = CalculatePattern(input);

			var numbers = input.Numbers;
			for (var i = 0; i < input.Iterations; i++)
				numbers = Iterate(numbers, pattern);

			return new string(string.Join(string.Empty,numbers).Take(8).ToArray());
		}

		public string Star2(Day16Input input)
		{
			throw new NotImplementedException();
		}
	}
}