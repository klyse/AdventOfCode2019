namespace Solver.Model
{
	public class Output1
	{
		public int Min { get; set; }
		public int Max { get; set; }
		public int Avg { get; set; }

		public override string ToString()
		{
			return $"{Min} {Max} {Avg}";
		}
	}
}