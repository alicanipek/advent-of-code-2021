using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AdventOfCode2021.Solutions {
	public class SonarSweep {
		private readonly List<int> Depths = new List<int>();

		public SonarSweep() {
			var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Input/Day01/input.txt");
			foreach (var str in File.ReadAllLines(path)) {
				Depths.Add(int.Parse(str));
			}
		}

		// Part 1
		public int CalculateIncreaseCount() {
			var count = 0;
			for (int i = 0; i < Depths.Count - 1; i++) {
				if (Depths[i + 1] > Depths[i]) {
					count++;
				}
			}
			return count;
		}

		// Part 2
		public int CalculateWindowIncreaseCount() {
			var count = 0;
			for (int i = 0; i < Depths.Count - 3; i++) {
				var firstWindow = Depths[i] + Depths[i + 1] + Depths[i + 2];
				var secondWindow = Depths[i + 1] + Depths[i + 2] + Depths[i + 3];
				if (secondWindow > firstWindow) {
					count++;
				}
			}
			return count;
		}
	}
}
