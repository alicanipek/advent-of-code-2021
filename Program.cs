using System;
using AdventOfCode2021.Solutions.Day1;
using AdventOfCode2021.Solutions.Day10;
using AdventOfCode2021.Solutions.Day11;
using AdventOfCode2021.Solutions.Day12;
using AdventOfCode2021.Solutions.Day2;
using AdventOfCode2021.Solutions.Day3;
using AdventOfCode2021.Solutions.Day4;
using AdventOfCode2021.Solutions.Day5;
using AdventOfCode2021.Solutions.Day6;
using AdventOfCode2021.Solutions.Day7;
using AdventOfCode2021.Solutions.Day8;
using AdventOfCode2021.Solutions.Day9;

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
			// HydrothermalVenture hydrothermalVenture = new HydrothermalVenture();
			// var count = hydrothermalVenture.CalculateOverlapsWithDiagonal();
			// Console.Write(count);

			// Day 6
			// LanternFish lanternfish = new LanternFish();
			// var count = lanternfish.CountLanternFishes();
			// Console.WriteLine(count);

			// Day 7
			// TheTreacheryOfWhales theTreacheryOfWhales = new TheTreacheryOfWhales();
			// var count = theTreacheryOfWhales.CalculateOptimalPosition2();
			// System.Console.WriteLine(count);

			// Day 8
			// SevenSegmentSearch sevenSegmentSearch = new SevenSegmentSearch();
			// var count = sevenSegmentSearch.CountDigits();
			// System.Console.WriteLine(count);

			// Day 9
			// SmokeBasin smokeBasin = new SmokeBasin();
			// var count = smokeBasin.CalculateBasinLevel();
			// System.Console.WriteLine(count);

			// Day 10
			// SyntaxScoring syntaxScoring = new SyntaxScoring();
			// var score = syntaxScoring.GetIncompleteScore();
			// System.Console.WriteLine(score);

			// Day 11
			// DumboOctopus dumboOctopus = new DumboOctopus();
			// var count = dumboOctopus.CalculateSimultaneousFlash();
			// System.Console.WriteLine(count);

			// Day 12
			PassagePathing passagePathing = new PassagePathing();
			var count = passagePathing.CalculatePathsRepeating();
			System.Console.WriteLine(count);
		}
	}
}
