﻿using System;
using System.Collections.Generic;
using System.Linq;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public static class PermuteExtensions
	{
		public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> sequence)
		{
			if (sequence == null) yield break;

			var list = sequence.ToList();

			if (!list.Any())
				yield return Enumerable.Empty<T>();
			else
			{
				var startingElementIndex = 0;

				foreach (var startingElement in list)
				{
					var index = startingElementIndex;
					var remainingItems = list.Where((e, i) => i != index);

					foreach (var permutationOfRemainder in remainingItems.Permute()) yield return startingElement.Concat(permutationOfRemainder);

					startingElementIndex++;
				}
			}
		}

		private static IEnumerable<T> Concat<T>(this T firstElement, IEnumerable<T> secondSequence)
		{
			yield return firstElement;
			if (secondSequence == null) yield break;

			foreach (var item in secondSequence) yield return item;
		}
	}

	public class Day7Solver : ISolver<int, Day7Input>
	{
		public int Star1(Day7Input input)
		{
			var biggestOut = 0;
			var sequence = new List<int> { 0, 1, 2, 3, 4 };

			var permutations = sequence.Permute().ToList();

			foreach (var permutation in permutations)
			{
				var lastOut = 0;
				foreach (var i1 in permutation)
				{
					var queue = new Queue<int>();
					queue.Enqueue(i1);
					queue.Enqueue(lastOut);
					lastOut = IntcodeComputer1((Day7Input)input.Clone(), queue);
					biggestOut = Math.Max(biggestOut, lastOut);
				}
			}

			return biggestOut;
		}

		public int Star2(Day7Input input)
		{
			var biggestOut = 0;
			var sequence = new List<int> { 5, 6, 7, 8, 9 };

			var permutations = sequence.Permute();

			foreach (var permutation in permutations)
			{
				var inpClone = new[]
							   {
								   new IntComputer
								   {
									   Input = (Day7Input)input.Clone()
								   },
								   new IntComputer
								   {
									   Input = (Day7Input)input.Clone()
								   },
								   new IntComputer
								   {
									   Input = (Day7Input)input.Clone()
								   },
								   new IntComputer
								   {
									   Input = (Day7Input)input.Clone()
								   },
								   new IntComputer
								   {
									   Input = (Day7Input)input.Clone()
								   }
							   };

				var lastOut = 0;
				while (true)
				{
					var final = false;
					foreach (var phase in permutation)
					{
						var queue = new List<int>();
						queue.Add(phase);
						queue.Add(lastOut);

						final = inpClone[phase - 5].IntcodeComputer2(queue);
						lastOut = inpClone[phase - 5].Output;
					}

					if (final)
						break;
				}


				biggestOut = Math.Max(biggestOut, lastOut);
			}

			return biggestOut;
		}

		public int IntcodeComputer1(Day7Input input, Queue<int> inputQueue)
		{
			var cursor = 0;
			var output = -1;

			while (true)
			{
				var command = input.Commands[cursor];

				var cleanCommand = command;
				if (command > 10000)
					throw new Exception("Strange things happened");

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

					input.Commands[addr1] = inputQueue.Dequeue();
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

				int val;
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

	public class IntComputer
	{
		public int InputPos { get; set; }
		public int Cursor { get; set; }
		public Day7Input Input { get; set; }
		public int Output { get; set; }

		public bool IntcodeComputer2(List<int> inputQueue)
		{
			while (true)
			{
				var command = Input.Commands[Cursor];

				var cleanCommand = command;
				if (command > 10000)
					throw new Exception("Strange things happened");

				if (command > 100)
					cleanCommand = int.Parse(command.ToString().Substring(command.ToString().Length - 2));

				if (cleanCommand == 99)
					return true;


				var param = command.ToString().Reverse().Skip(2).ToList();
				if (param.Count < 1)
					param.Add('0');
				if (param.Count < 2)
					param.Add('0');

				var v1 = param[0] == '0' ? Input.Commands[Input.Commands[Cursor + 1]] : Input.Commands[Cursor + 1];

				if (cleanCommand == 3)
				{
					var addr1 = param[0] == '0' ? Input.Commands[Cursor + 1] : Cursor + 1;

					Input.Commands[addr1] = inputQueue[InputPos];
					InputPos = 1;
					Cursor += 2;
					continue;
				}

				if (cleanCommand == 4)
				{
					Output = v1;
					Cursor += 2;
					return false;
				}

				var v2 = param[1] == '0' ? Input.Commands[Input.Commands[Cursor + 2]] : Input.Commands[Cursor + 2];
				var pos = Input.Commands[Cursor + 3];

				if (pos == Cursor)
					throw new Exception("Cursor is equal to position");

				int val;
				if (cleanCommand == 1)
				{
					val = v1 + v2;
					Cursor += 4;
				}
				else if (cleanCommand == 2)
				{
					val = v1 * v2;
					Cursor += 4;
				}
				// jump-if-true
				else if (cleanCommand == 5)
				{
					if (v1 > 0)
						Cursor = v2;
					else
						Cursor += 3;
					continue;
				}
				// jump-if-false
				else if (cleanCommand == 6)
				{
					if (v1 == 0)
						Cursor = v2;
					else
						Cursor += 3;
					continue;
				}
				// less than
				else if (cleanCommand == 7)
				{
					if (v1 < v2)
						val = 1;
					else
						val = 0;
					Cursor += 4;
				}
				// equals
				else if (cleanCommand == 8)
				{
					if (v1 == v2)
						val = 1;
					else
						val = 0;
					Cursor += 4;
				}
				else
					throw new Exception("Strange things happened");


				if (pos < 0)
					pos = Input.Commands.Length + pos;

				Input.Commands[pos] = val;
			}
		}
	}
}