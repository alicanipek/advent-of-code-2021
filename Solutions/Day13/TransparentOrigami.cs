using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions {
	public class TransparentOrigami {
		private HashSet<(int, int)> dots = new HashSet<(int, int)>();
		private List<Fold> folds = new List<Fold>();
		public TransparentOrigami() {
			var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Input/Day13/input.txt");
			using (StreamReader reader = new StreamReader(path)) {
				string line;
				while ((line = reader.ReadLine()) != "") {
					var indexes = Array.ConvertAll(line.Split(","), int.Parse);
					dots.Add((indexes[0], indexes[1]));
				}
				while ((line = reader.ReadLine()) != null) {
					var indexes = line.Split(" ");
					var coordinate = indexes[2].Split("=");
					folds.Add(new Fold {
						IsX = coordinate[0] == "x",
						Pos = int.Parse(coordinate[1])
					});
				}
			}
		}

		public int CountDotsAfterFirstFold() {
			var count = 0;
			var fold = folds.First();
			Fold(fold);
			int maxCol = dots.Select(c => c.Item1).Max() + 1;
			int maxRow = dots.Select(c => c.Item2).Max() + 1;

			for (int r = 0; r < maxRow; r++) {
				for (int c = 0; c < maxCol; c++)
					if(dots.Contains((c, r))){
                        count++;
                    }
			}
            return count;
		}

		public void PrintDotsAfterFold() {
			foreach (var fold in folds) {
				Fold(fold);
			}
			PrintGrid();
		}

		private void Fold(Fold fold) {
			var dotsToRemove = new List<(int, int)>();
			var newCoordinates = new HashSet<(int, int)>();
			if (fold.IsX) {
				dotsToRemove = dots.Where(x => x.Item1 > fold.Pos).ToList();
				foreach (var pt in dotsToRemove) {
					var newCol = fold.Pos - (pt.Item1 - fold.Pos);
					newCoordinates.Add((newCol, pt.Item2));
				}
			} else {
				dotsToRemove = dots.Where(p => p.Item2 > fold.Pos).ToList();
				foreach (var pt in dotsToRemove) {
					var newRow = fold.Pos - (pt.Item2 - fold.Pos);
					newCoordinates.Add((pt.Item1, newRow));
				}
			}

			dots = dots.Union(newCoordinates).ToHashSet();
			dots = dots.Except(dotsToRemove).ToHashSet();
		}
		private void PrintGrid() {
			int maxCol = dots.Select(c => c.Item1).Max() + 1;
			int maxRow = dots.Select(c => c.Item2).Max() + 1;

			for (int r = 0; r < maxRow; r++) {
				var s = "";
				for (int c = 0; c < maxCol; c++)
					s += dots.Contains((c, r)) ? '#' : '.';
				Console.WriteLine(s);
			}
			Console.WriteLine("");
		}
	}

	public class Fold {
		public int Pos { get; set; }
		public bool IsX { get; set; }
	}

}