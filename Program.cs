using System;
using AdventOfCode2021.Solutions.Day1;
using AdventOfCode2021.Solutions.Day2;
using AdventOfCode2021.Solutions.Day3;

namespace AdventOfCode2021 {
	class Program {
		static void Main(string[] args) {
			// Day 1
			// SonarSweep sonarSweep = new SonarSweep();
			// var count = sonarSweep.CalculateWindowIncreaseCount();

			// Day 2
			// Dive dive = new Dive();
			// var count = dive.CalculatePositionWithAim();
			// Console.WriteLine(count);

			BinaryDiagnostic binaryDiagnostic = new BinaryDiagnostic();
			var count = binaryDiagnostic.CalculateLifeSupportRating();
			Console.WriteLine(count);
		}
	}
}
