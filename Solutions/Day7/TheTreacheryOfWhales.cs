using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions.Day7 {
	public class TheTreacheryOfWhales {
		private readonly int[] CrabPositions;
		public TheTreacheryOfWhales() {
			var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Input/Day7/input.txt");
			using (StreamReader reader = new StreamReader(path)) {
				string line = reader.ReadLine();
				CrabPositions = Array.ConvertAll(line.Split(','), int.Parse);
			}
		}
		public int CalculateOptimalPosition() {
			var biggest = CrabPositions.Max();
            var counts = new List<int>();
			for (int i = 0; i <= biggest; i++) {
                int count = 0;
                for(int j = 0; j < CrabPositions.Count(); j++){
                    count += Math.Abs(CrabPositions[j] - i);
                }
                counts.Add(count);
			}
            counts = counts.Where(x => x > 0).ToList();
            Console.WriteLine(counts.Min());
            return counts.IndexOf(counts.Min());
		}
		public int CalculateOptimalPosition2() {
			var biggest = CrabPositions.Max();
            var counts = new List<int>();
			for (int i = 0; i <= biggest; i++) {
                int count = 0;
                for(int j = 0; j < CrabPositions.Count(); j++){
                    var diff = Math.Abs(CrabPositions[j] - i);
                    count += (diff * (diff + 1)) / 2;
                }
                counts.Add(count);
			}
            counts = counts.Where(x => x > 0).ToList();
            Console.WriteLine(counts.Min());
            return counts.IndexOf(counts.Min());
		}
	}
}