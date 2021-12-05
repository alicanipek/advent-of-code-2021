using System;
using AdventOfCode2021.Solutions.Day1;
using AdventOfCode2021.Solutions.Day2;
using AdventOfCode2021.Solutions.Day3;
using AdventOfCode2021.Solutions.Day4;
using AdventOfCode2021.Solutions.Day5;
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

			// Day 3
			// BinaryDiagnostic binaryDiagnostic = new BinaryDiagnostic();
			// var count = binaryDiagnostic.CalculateLifeSupportRating();
			// Console.WriteLine(count);

			// Day 4
			// GiantSquid giantSquid = new GiantSquid();
			// var score = giantSquid.BingoSquidWin();
			// System.Console.WriteLine(score);

			// Day 5
			HydrothermalVenture hydrothermalVenture = new HydrothermalVenture();
			var count = hydrothermalVenture.CalculateOverlapsWithDiagonal();
			Console.Write(count);
		}
	}
}
