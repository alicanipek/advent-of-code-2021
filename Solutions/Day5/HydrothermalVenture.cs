using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2021.Solutions.Day5 {
	public class HydrothermalVenture {
		private int[,] vents = new int[1000, 1000];
		private List<List<int[]>> input = new List<List<int[]>>();

		public HydrothermalVenture() {
			var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Input/Day5/input.txt");
			foreach (var line in File.ReadAllLines(path)) {
				var str = line.Split("->");
				var firstInput = Array.ConvertAll(str[0].Trim().Split(','), int.Parse);
				var secondInput = Array.ConvertAll(str[1].Trim().Split(','), int.Parse);
				input.Add(new List<int[]> { firstInput, secondInput });
			}
		}

        // part 1
		public int CalculateOverlaps() {
			var count = 0;
			for (int i = 0; i < input.Count; i++) {
				if (input[i][0][0] != input[i][1][0] && input[i][0][1] != input[i][1][1]) continue;
				int lowerX = input[i][0][0] < input[i][1][0] ? input[i][0][0] : input[i][1][0];
				int upperX = input[i][0][0] < input[i][1][0] ? input[i][1][0] : input[i][0][0];
				int lowerY = input[i][0][1] < input[i][1][1] ? input[i][0][1] : input[i][1][1];
				int upperY = input[i][0][1] < input[i][1][1] ? input[i][1][1] : input[i][0][1];
				for (int j = lowerX; j <= upperX; j++) {
					for (int k = lowerY; k <= upperY; k++) {
						vents[k, j] += 1;
					}
				}
			}
			for (int j = 0; j < 1000; j++) {
				for (int k = 0; k < 1000; k++) {
					if (vents[j, k] > 1) count++;
				}
			}
			return count;
		}

        // part 2
		public int CalculateOverlapsWithDiagonal() {
			var count = 0;
			for (int i = 0; i < input.Count; i++) {
				if (input[i][0][0] != input[i][1][0] && input[i][0][1] != input[i][1][1]) {
					var xRange = GenerateRange(input[i][0][0], input[i][1][0]);
					var yRange = GenerateRange(input[i][0][1], input[i][1][1]);
					for (int k = 0; k < xRange.Length; k++) {
						vents[xRange[k], yRange[k]] += 1;
					}
				} else {

					int lowerX = input[i][0][0] < input[i][1][0] ? input[i][0][0] : input[i][1][0];
					int upperX = input[i][0][0] < input[i][1][0] ? input[i][1][0] : input[i][0][0];
					int lowerY = input[i][0][1] < input[i][1][1] ? input[i][0][1] : input[i][1][1];
					int upperY = input[i][0][1] < input[i][1][1] ? input[i][1][1] : input[i][0][1];
					for (int j = lowerX; j <= upperX; j++) {
						for (int k = lowerY; k <= upperY; k++) {
							vents[j, k] += 1;
						}
					}
				}
			}
			for (int j = 0; j < 1000; j++) {
				for (int k = 0; k < 1000; k++) {
					if (vents[j, k] > 1) count++;
				}
			}

			return count;
		}
        
		private int[] GenerateRange(int first, int second) {
			var start = first < second ? first : second;
            var count = Math.Abs(first-second) + 1;
            var x = Enumerable.Range(start, count);
			var range = first < second ? x : x.Reverse();
            return range.ToArray();
		}
	}
}