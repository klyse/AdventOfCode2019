﻿using System;
using System.Collections.Generic;
using System.Linq;
using Solver.Base;
using Solver.Model;

namespace Solver.Algorithms
{
	public class Day22Solver : ISolver<int, Day22Input>
	{
		public int Star1(Day22Input input)
		{
			var cards = Shuffle(input);

			return Array.FindIndex(cards.ToArray(), c => c == 2019);
		}

		public int Star2(Day22Input input)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<int> Shuffle(Day22Input input)
		{
			var cards = input.Cards;
			foreach (var inputShuffleRule in input.ShuffleRules) cards = inputShuffleRule.Shuffle(cards);

			return cards;
		}
	}
}