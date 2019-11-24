using System;
using NUnit.Framework;
using Solver;

namespace Test
{
	public class Solver1Test
	{
		[Test]
		[TestCase("data.in")]
		public void T1(string file)
		{
			var fileInput = file.Read();
			//var input = new TerrainInput1().Parse(fileInput);

			//var solution = new Solver1().Solve(input);

			file.Write(fileInput.ToString());
			Console.WriteLine(fileInput);
			Assert.Pass();
		}
	}
}