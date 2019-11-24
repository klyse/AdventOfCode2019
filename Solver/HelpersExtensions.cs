using System.Collections.Generic;
using System.IO;

namespace Solver
{
	public static class HelpersExtensions
	{
		public static string[] Read(this string fileName)
		{
			var readAllLines = File.ReadAllLines(Path.Combine(EnvironmentConstants.InputPath, fileName));
			return readAllLines;
		}

		public static void Write(this string fileName, string[] lines)
		{
			var filePath = Path.Combine(EnvironmentConstants.OutputPath, fileName.Replace(".in", ".out"));
			if (!Directory.Exists(EnvironmentConstants.OutputPath))
				Directory.CreateDirectory(EnvironmentConstants.OutputPath);
			File.WriteAllLines(filePath, lines);
		}

		public static void Write(this string fileName, string line)
		{
			Write(fileName, new List<string> { line }.ToArray());
		}
	}
}