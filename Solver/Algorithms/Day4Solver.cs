using System;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class Day4Solver : ISolver<int, Day4Input>
	{
		public int Star1(Day4Input input)
		{
			var cnt = 0;
			for (var i = input.Min; i < input.Max; i++)
				if (ValidNumber1(i))
					cnt++;

			return cnt;
		}

		public int Star2(Day4Input input)
		{
			var cnt = 0;
			for (var i = input.Min; i < input.Max; i++)
				if (ValidNumber2(i))
					cnt++;

			return cnt;
		}

		public bool ValidNumber1(int nr)
		{
			var strNum = nr.ToString();
			var twoAreSame = false;
			for (var i = 0; i < strNum.Length - 1; i++)
			{
				if (strNum[i] > strNum[i + 1])
					return false;

				if (strNum[i] == strNum[i + 1])
					twoAreSame = true;
			}

			return twoAreSame;
		}

		public bool ValidNumber2(int nr)
		{
			var strNum = nr.ToString();
			var twoAreSame = false;
			for (var i = 0; i < strNum.Length - 1; i++)
			{
				if (strNum[i] > strNum[i + 1])
					return false;

				if (strNum[i] == strNum[i + 1])
				{
					var firstIndex = strNum.IndexOf($"{strNum[i]}{strNum[i]}", StringComparison.Ordinal);

					if (firstIndex + 2 > strNum.Length - 1)
						twoAreSame = true;
					else if (strNum[firstIndex + 2] != strNum[i])
						twoAreSame = true;
				}
			}

			return twoAreSame;
		}
	}
}