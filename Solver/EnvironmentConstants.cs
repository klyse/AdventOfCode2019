using System.IO;
using Solver.Base;

namespace Solver
{
	public static class EnvironmentConstants
	{
		// ReSharper disable PossibleNullReferenceException
		public static string DataPath => Path.Combine(new FileInfo(typeof(IInput<bool>).Assembly.Location).Directory.Parent.Parent.Parent.Parent.ToString(), "Environment");
		// ReSharper restore PossibleNullReferenceException

		public static string InputPath => Path.Combine(DataPath, "Input");
		public static string OutputPath => Path.Combine(DataPath, "Output");
	}
}