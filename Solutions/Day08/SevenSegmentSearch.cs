using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions {
	public class SevenSegmentSearch {
		private readonly List<string> OutputPatterns;
		public SevenSegmentSearch() {
			OutputPatterns = new List<string>();
			var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Input/Day08/input.txt");
			foreach (var str in File.ReadAllLines(path)) {
				OutputPatterns.Add(str.Split('|')[1].Trim());
			}
		}

		public int CountDigits() {
			var count = 0;
			var uniqueSegmentLengths = new int[4] { 2, 3, 4, 7 };
			foreach (var str in OutputPatterns) {
				count += str.Split(' ').Where(x => uniqueSegmentLengths.Contains(x.Length)).Count();
			}
            return count;
		}
	}
}