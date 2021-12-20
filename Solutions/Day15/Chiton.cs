using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2021.Solutions {
	public class Chiton {
		private List<List<int>> riskLevelMap = new List<List<int>>();
		private int[][] neighbours = new int[][] {
			new int[] {-1, 0},
			new int[] {1, 0},
			new int[] {0, -1},
			new int[] {0, 1}
		};
		public Chiton() {
			var file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Input/Day15/input.txt");
			foreach (var line in File.ReadAllLines(file)) {
				riskLevelMap.Add(line.Select(c => c - '0').ToList());
			}
		}

		public int Part1() {
			return MinPath();
		}

		public int Part2() {
			CalculateFullMap();
			return MinPath();
		}

		private int MinPath() {
			int[,] t = new int[riskLevelMap.Count(), riskLevelMap[0].Count()];
			for (int i = 0; i < riskLevelMap.Count(); i++) {
				for (int j = 0; j < riskLevelMap[i].Count(); j++) {
					t[i, j] = int.MaxValue;
				}
			}
			var queue = new Queue<(int, int)>();
			queue.Enqueue((0, 0));
			t[0, 0] = 0;
			while (queue.Count > 0) {
				var current = queue.Dequeue();
				for (int i = 0; i < neighbours.Count(); i++) {
					var newX = current.Item1 + neighbours[i][0];
					var newY = current.Item2 + neighbours[i][1];
					if (newX < t.GetLength(0) && newX >= 0) {
						if (newY < t.GetLength(1) && newY >= 0) {
							if (t[current.Item1, current.Item2] + riskLevelMap[newX][newY] < t[newX, newY]) {
								t[newX, newY] = t[current.Item1, current.Item2] + riskLevelMap[newX][newY];
								queue.Enqueue((newX, newY));
							}
						}
					}
				}
			}
			return t[riskLevelMap.Count() - 1, riskLevelMap[0].Count() - 1];
		}
		private void CalculateFullMap() {
			var row = riskLevelMap.Count();
			var col = riskLevelMap[0].Count();
			var newMap = new List<List<int>>();
			foreach (var list in riskLevelMap) {
				newMap.Add(list);
			}
			for (int i = 0; i < 4; i++) {
				for (int j = i * row; j < row + (i * row); j++) {
					var newLine = new List<int>();
					for (int k = 0; k < col; k++) {
						var newValue = newMap[j][k] == 9 ? 1 : newMap[j][k] + 1;
						newLine.Add(newValue);
					}
					newMap.Add(newLine);
				}
			}
			riskLevelMap = newMap;
			foreach (var list in riskLevelMap) {
				for (int i = 0; i < 4; i++) {
					for (int j = i * col; j < col + (i * col); j++) {
						list.Add(list[j] == 9 ? 1 : list[j] + 1);
					}
				}
			}
			var s = new List<string>();
			for (int i = 0; i < riskLevelMap.Count(); i++) {
				var line = "";
				for (int j = 0; j < riskLevelMap[0].Count(); j++) {
					line += riskLevelMap[i][j] + " ";
				}
				s.Add(line);
			}
		}
	}
}