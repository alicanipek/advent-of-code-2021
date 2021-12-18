using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions {
	public class LanternFish {
		private readonly int[] LanternFishes;
		public LanternFish() {
			var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Input/Day06/input.txt");
			using (StreamReader reader = new StreamReader(path)) {
				string line = reader.ReadLine();
				LanternFishes = Array.ConvertAll(line.Split(','), int.Parse);
			}
		}

		public int CountLanternFishes() {
			List<List<int>> f = new List<List<int>>();
			foreach (var item in LanternFishes) {
				var t = new List<int> { item + 1 };
				f.Add(t);
			}
			var fishCount = 0;
			var loopCount = 80 / 7;
			while (loopCount >= 0) {
				List<List<int>> newList = new List<List<int>>();
				foreach (var item in f) {
					List<int> elementsToBeAdded = new List<int>();
					foreach (var i in item) {
						if (i <= 80) fishCount++;
						elementsToBeAdded.Add(i + 7);
						elementsToBeAdded.Add(i + 9);
					}
					newList.Add(elementsToBeAdded);
				}
				f = newList;
				loopCount--;
			}
			return fishCount + LanternFishes.Count();
		}
	}
}