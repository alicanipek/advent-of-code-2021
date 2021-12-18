using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions {
	public class ExtendedPolymerization {
		private string polymerTemplate;
		private long[][] frequencyTable;
		private Dictionary<string, string> rules;
		public ExtendedPolymerization() {
			// zero initialize 26 x 26 frequency table
			var file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Input/Day14/input.txt");
			var lines = File.ReadAllLines(file);
			polymerTemplate = lines[0];

			frequencyTable = new long[26][];
			for (int i = 0; i < 26; i++) {
				frequencyTable[i] = new long[26];
			}

			var groups = polymerTemplate.SkipLast(1).Select((_, i) => polymerTemplate.Substring(i, 2)).ToList();
			foreach (var group in groups) {
				frequencyTable[group[0] - 'A'][group[1] - 'A']++;
			}
            
			rules = new Dictionary<string, string>();
			foreach (var line in lines.Skip(2)) {
				var rule = line.Split("->");
				rules.Add(rule[0].Trim(), rule[1].Trim());
			}
		}

		public void Polymerize() {

			long part1 = 0;
			long part2 = 0;

			for (int i = 0; i < 40; i++) {
				if (i == 10) {
					part1 = CalculateResult();
				}
				PairInsertion();
			}
			part2 = CalculateResult();

			System.Console.WriteLine($"Part 1: {part1}");
			System.Console.WriteLine($"Part 1: {part2}");
		}

		// Part 1
		private long CalculateResult() {

			long[] freq = new long[26];
			for (int i = 0; i < 26; i++) {
				for (int j = 0; j < 26; j++) {
					freq[i] += frequencyTable[j][i];
				}
			}
			long min = freq.Where(x => x > 0).Min();
			long max = freq.Max();
			return max - min;
		}
		private void PairInsertion() {
			var tempTable = new long[26][];
			for (int i = 0; i < 26; i++) {
				tempTable[i] = new long[26];
			}

			for (int i = 0; i < rules.Count(); i++) {
				var rule = rules.ElementAt(i);
				var ruleFirstChar = rule.Key[0] - 'A';
				var ruleSecondChar = rule.Key[1] - 'A';
				var n = frequencyTable[ruleFirstChar][ruleSecondChar];
				var value = rule.Value[0] - 'A';
				tempTable[ruleFirstChar][value] += n;
				tempTable[value][ruleSecondChar] += n;
			}
			frequencyTable = tempTable;
		}

		private void PrintFrequencyTable() {
			Console.Write("  ");
			for (int i = 0; i < 26; i++) {
				Console.Write("{0} ", (char)(i + 'A'));
			}
			Console.WriteLine();
			for (int i = 0; i < 26; i++) {
				Console.Write("{0} ", (char)(i + 'A'));
				for (int j = 0; j < 26; j++) {
					if (frequencyTable[i][j] > 0) {
						Console.Write("{0} ", frequencyTable[i][j]);
					} else {
						Console.Write(". ");
					}
				}
				Console.WriteLine();
			}
		}
	}
}