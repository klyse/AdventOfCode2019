using System;
using System.Collections.Generic;
using System.Linq;
using Solver.Base;

namespace Solver.Model
{
	public interface IShuffle
	{
		IEnumerable<int> Shuffle(IEnumerable<int> cards);
	}

	public class DealWithIncrementShuffle : IShuffle
	{
		public int Increment { get; set; }

		public IEnumerable<int> Shuffle(IEnumerable<int> cards)
		{
			var cardsArray = Enumerable.Repeat(-1, cards.Count()).ToArray();

			var q = new Queue<int>(cards);

			var index = 0;
			while (q.Any())
			{
				if (cardsArray[index] != -1)
					throw new Exception("Value already set!");
				cardsArray[index] = q.Dequeue();

				index += Increment;
				if (index >= cardsArray.Length)
				{
					var delta = index - cardsArray.Length;
					index = delta;
				}
			}

			if (cardsArray.Any(c => c == -1))
				throw new Exception("bad Stuff");

			return cardsArray.AsEnumerable();
		}
	}

	public class CutShuffle : IShuffle
	{
		public int Cut { get; set; }

		public IEnumerable<int> Shuffle(IEnumerable<int> cards)
		{
			IEnumerable<int> first;
			IEnumerable<int> second;
			if (Cut < 0)
			{
				first = cards.Reverse().Skip(Math.Abs(Cut)).Reverse();
				second = cards.Reverse().Take(Math.Abs(Cut)).Reverse();
			}
			else
			{
				first = cards.Take(Math.Abs(Cut));
				second = cards.Skip(Math.Abs(Cut));
			}

			return second.Concat(first);
		}
	}

	public class DealIntoNewStackShuffle : IShuffle
	{
		public IEnumerable<int> Shuffle(IEnumerable<int> cards)
		{
			return cards.Reverse();
		}
	}

	public class Day22Input : IInput<Day22Input>
	{
		public int NumberOfCards { get; set; }
		public IEnumerable<IShuffle> ShuffleRules { get; set; }
		public IEnumerable<int> Cards { get; set; }

		public Day22Input Parse(string[] values)
		{
			Cards = Enumerable.Range(0, NumberOfCards);
			var shuffleRules = new List<IShuffle>();

			foreach (var s in values)
				if (s.StartsWith("cut"))
					shuffleRules.Add(new CutShuffle
									 {
										 Cut = int.Parse(s.Split(' ').ElementAt(1))
									 });
				else if (s.StartsWith("deal with increment"))
					shuffleRules.Add(new DealWithIncrementShuffle
									 {
										 Increment = int.Parse(s.Split(' ').ElementAt(3))
									 });
				else if (s.StartsWith("deal into new stack"))
					shuffleRules.Add(new DealIntoNewStackShuffle());
				else
					throw new Exception("What happened??");

			ShuffleRules = shuffleRules;

			return this;
		}
	}
}