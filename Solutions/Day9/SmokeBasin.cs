using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2021.Solutions.Day9 {
	public class SmokeBasin {
		private readonly List<List<int>> Caves = new List<List<int>>();
		public SmokeBasin() {
			var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Input/Day9/input.txt");
			foreach (var str in File.ReadAllLines(path)) {
				var cave = new List<int>();
				foreach (var c in str) {
					cave.Add(int.Parse(c.ToString()));
				}
				Caves.Add(cave);
			}
		}

		// Part 1
		public int CalculateRiskLevel() {
			var level = 0;
			for (int i = 0; i < Caves.Count; i++) {
				for (int j = 0; j < Caves[i].Count(); j++) {
					var small = IsSmall(i, j);
					if (small) {
						level += 1 + Caves[i][j];
					}
				}
			}
			return level;
		}

		// Part 2
		public int CalculateBasinLevel() {
			var basinLevels = new List<int>();
			var seen = new bool[Caves.Count, Caves[0].Count];
			for (int i = 0; i < Caves.Count; i++) {
				for (int j = 0; j < Caves[i].Count(); j++) {
					var small = IsSmall(i, j);
					if (small) {
						var count = 1;
						seen[i, j] = true;
						Count(i, j, ref count, ref seen);

						basinLevels.Add(count);
					}
				}
			}
			basinLevels.Sort((a,b) => b - a);
			return basinLevels[0] * basinLevels[1] * basinLevels[2];
		}

		private bool IsSmall(int i, int j) {
			var small = true;
			// left
			if ((j > 0) && (Caves[i][j - 1] <= Caves[i][j])) small = false;
			// right
			if (small && ((j < Caves[i].Count - 1) && (Caves[i][j + 1] <= Caves[i][j]))) small = false;
			// top
			if (small && ((i > 0) && (Caves[i - 1][j] <= Caves[i][j]))) small = false;
			// bottom
			if (small && ((i < Caves.Count - 1) && (Caves[i + 1][j] <= Caves[i][j]))) small = false;
			return small;
		}
		private void Count(int i, int j, ref int count, ref bool[,] seen) {
			if (Caves[i][j] == 9) return;
			// left
			if ((j > 0) && !seen[i, j - 1] && Caves[i][j - 1] != 9 &&  (Caves[i][j - 1] > Caves[i][j])) {
				count++;
				seen[i, j - 1] = true;
				Count(i, j - 1, ref count, ref seen);
			};
			// right
			if ((j < Caves[i].Count - 1) && !seen[i, j + 1] && Caves[i][j + 1] != 9 && (Caves[i][j + 1] > Caves[i][j])) {
				count++;
				seen[i, j + 1] = true;
				Count(i, j + 1, ref count, ref seen);
			};
			// top
			if ((i > 0) && !seen[i - 1, j] && Caves[i - 1][j] != 9 && (Caves[i - 1][j] > Caves[i][j])) {
				count++;
				seen[i - 1, j] = true;
				Count(i - 1, j, ref count, ref seen);
			};
			// bottom
			if ((i < Caves.Count - 1) && !seen[i + 1, j] && Caves[i + 1][j]  != 9 && (Caves[i + 1][j] > Caves[i][j])) {
				count++;
				seen[i + 1, j] = true;
				Count(i + 1, j, ref count, ref seen);
			};
		}
	}
}