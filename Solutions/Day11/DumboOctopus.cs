using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;


namespace AdventOfCode2021.Solutions {
	public class DumboOctopus {
		private readonly List<List<int>> EnergyLevels = new List<List<int>>();
		private readonly int[,] Directions;
		public DumboOctopus() {
			var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Input/Day11/input.txt");
			foreach (var str in File.ReadAllLines(path)) {
				var level = new List<int>();
				foreach (var c in str) {
					level.Add(int.Parse(c.ToString()));
				}
				EnergyLevels.Add(level);
			}
			Directions = new int[8, 2]{
				{ -1, -1 },
				{ -1,  0 },
				{ -1,  1 },
				{  0, -1 },
				{  0,  1 },
				{  1, -1 },
				{  1,  0 },
				{  1,  1 }
			};
		}
        // Part 1
		public int CountFlashes() {
			int count = 0;
			for (int i = 0; i < 100; i++) {
				var flashed = new bool[100, 100];
				for (int j = 0; j < EnergyLevels.Count(); j++) {
					for (int k = 0; k < EnergyLevels[0].Count(); k++) {
						EnergyLevels[j][k] = (flashed[j, k] && EnergyLevels[j][k] == 0) || (EnergyLevels[j][k] + 1 > 9) ? 0 : EnergyLevels[j][k] + 1;

						if (EnergyLevels[j][k] == 0) {
							DFS(j, k, flashed, ref count);
						}
					}
				}
			}
			return count;
		}

        // Part 2
		public int CalculateSimultaneousFlash() {
			int index = 0;
			int count = 0;
			while(Sum() != 0) {
                index++;
				var flashed = new bool[100, 100];
				for (int j = 0; j < EnergyLevels.Count(); j++) {
					for (int k = 0; k < EnergyLevels[0].Count(); k++) {
						EnergyLevels[j][k] = (flashed[j, k] && EnergyLevels[j][k] == 0) || (EnergyLevels[j][k] + 1 > 9) ? 0 : EnergyLevels[j][k] + 1;

						if (EnergyLevels[j][k] == 0) {
							DFS(j, k, flashed, ref count);
						}
					}
				}
			}
            return index;
		}

		private void DFS(int row0, int col0, bool[,] flashed, ref int count) {
			if (flashed[row0, col0]) return;
			count++;
			flashed[row0, col0] = true;
			for (int m = 0; m < 8; m++) {
				var row = row0 + Directions[m, 0];
				var col = col0 + Directions[m, 1];
				if (row < 0 || row >= EnergyLevels.Count() || col < 0 || col >= EnergyLevels[0].Count()) continue;

				EnergyLevels[row][col] = (flashed[row, col] && EnergyLevels[row][col] == 0) || (EnergyLevels[row][col] + 1 > 9) ? 0 : EnergyLevels[row][col] + 1;
				if (!flashed[row, col] && EnergyLevels[row][col] == 0) {
					DFS(row, col, flashed, ref count);
				}
			}
		}

		private int Sum() {
            var sum = 0;
			for (int j = 0; j < EnergyLevels.Count(); j++) {
				for (int k = 0; k < EnergyLevels[0].Count(); k++) {
                    sum += 	EnergyLevels[j][k];
				}
			}
            return sum;
		}
        
		private void Print() {
			for (int j = 0; j < EnergyLevels.Count(); j++) {
				for (int k = 0; k < EnergyLevels[0].Count(); k++) {
					System.Console.Write(EnergyLevels[j][k]);
				}
				System.Console.Write("\n");
			}
		}
	}
}