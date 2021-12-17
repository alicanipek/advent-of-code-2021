using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions {
	public class PassagePathing {
		private readonly Dictionary<string, List<string>> Paths;

		public PassagePathing() {
			Paths = new Dictionary<string, List<string>>();
			var file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Input/Day12/input.txt");
			foreach (var str in File.ReadAllLines(file)) {
				var path = str.Split('-');
				if (Paths.ContainsKey(path[0])) {
					Paths[path[0]].Add(path[1]);
				} else {
					Paths.Add(path[0], new List<string> { path[1] });
				}
				if (Paths.ContainsKey(path[1])) {
					Paths[path[1]].Add(path[0]);
				} else {
					Paths.Add(path[1], new List<string> { path[0] });
				}
			}
		}

        // Part 1
		public int CalculatePaths() {
			var count = 0;
			List<string> currentPath = new List<string>();
			currentPath.Add("start");
			FindPath(currentPath, "start", "end", ref count);
			return count;
		}

        // Part 2
		public int CalculatePathsRepeating() {
			var count = 0;
			List<string> currentPath = new List<string>();
			currentPath.Add("start");
			FindPathRepeating(currentPath, "start", "end", ref count);
			return count;
		}

		private void FindPath(List<string> currentPath, string current, string end, ref int count) {
			if (current == end) {
				foreach (var path in currentPath) {
					Console.Write(path + " ");
				};
				Console.Write("\n");
				count++;
				return;
			}
			foreach (var next in Paths[current]) {
				if (next.All(char.IsLower) && currentPath.Contains(next)) continue;
				else {
					currentPath.Add(next);
					FindPath(currentPath, next, end, ref count);
					currentPath.RemoveAt(currentPath.Count - 1);
				}
			}
		}

		private void FindPathRepeating(List<string> currentPath, string current, string end, ref int count) {
			if (current == end) {
				foreach (var path in currentPath) {
					Console.Write(path + " ");
				};
				Console.Write("\n");
				count++;
				return;
			}
			foreach (var next in Paths[current]) {
				if (next == "start"
				|| (next.All(char.IsLower) && IsNextSeenNTimes(currentPath, next, 2))
				|| (next.All(char.IsLower) && IsAnotherLowercasePointSeenTwoTimes(currentPath, next) && IsNextSeenNTimes(currentPath, next, 1))) {
					continue;
				} else {
					currentPath.Add(next);
					FindPathRepeating(currentPath, next, end, ref count);
					currentPath.RemoveAt(currentPath.Count - 1);
				}
			}
		}

		private bool IsNextSeenNTimes(List<string> currentPath, string next, int n) {
			return currentPath.Where(x => x == next).Count() == n;
		}

		private bool IsAnotherLowercasePointSeenTwoTimes(List<string> currentPath, string next) {
			return currentPath.GroupBy(x => x).Where(x => x.Key != next && x.Key.All(char.IsLower) && x.Count() >= 2).Count() > 0;
		}
	}
}