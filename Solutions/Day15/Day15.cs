using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2021.Solutions {
	public class Day15 {
		private readonly string[] _input;
		private static Node[,] _grid;

		public Day15() {
			_input = System.IO.File.ReadAllLines(
					@"/Users/ipek/Projects/AdventOfCode2021/Input/Day15/input.txt");
		}

		public void Run() {
			var time = DateTime.UtcNow;
			_grid = new Node[_input.Length, _input[0].Length];
			for (var i = 0; i < _input.Length; i++) {
				for (var j = 0; j < _input[i].Length; j++) {
					var weight = int.Parse(_input[i].ToCharArray()[j].ToString());
					_grid[i, j] = new Node(j, i, weight);
				}
			}

			var expandedGrid = new Node[_grid.GetLength(0) * 5, _grid.GetLength(1) * 5];
			for (var i = 0; i < _input.Length; i++) {
				for (var j = 0; j < _input[i].Length; j++) {
					var gridSizeX = _input[i].Length;
					var gridSizeY = _input.Length;
					for (var k = 0; k < 5; k++) {
						var newX = j + k * gridSizeX;
						for (var l = 0; l < 5; l++) {
							var input = int.Parse(_input[i][j].ToString());
							input += k;
							input += l;
							if (input > 9) {
								input -= 9;
							}

							var newY = i + l * gridSizeY;
							expandedGrid[newY, newX] = new Node(newX, newY, input);
						}
					}
				}
			}

			Console.Write(("15.1: "));
			Tasks();
			_grid = expandedGrid;
			Console.Write(("15.2: "));
			Tasks();
		}

		private static void Tasks() {
			var timer = DateTime.UtcNow;
			var queue = new Queue<(int, int)>();
			_grid[0, 0].InQueue = true;
			queue.Enqueue((0, 0));
			while (queue.TryDequeue(out var coords)) {
				var n = _grid[coords.Item1, coords.Item2];
				n.Visited = true;
				n.InQueue = false;
				FindNeighbours(n).ForEach(x => {
					if (x.Visited || x.InQueue) {
						if (x.Distance > x.Weight + n.Distance) {
							x.Distance = x.Weight + n.Distance;
						}
						if (n.Distance <= n.Weight + x.Distance) return;
						n.Distance = n.Weight + x.Distance;
					} else {
						x.Distance = x.Weight + n.Distance;
						x.InQueue = true;
						queue.Enqueue((x.Y, x.X));
					}
				});
			}

			var s = new List<string>();
			for (int i = 0; i < _grid.GetLength(0); i++) {
				var line = "";
				for (int j = 0; j < _grid.GetLength(1); j++) {

					line += $"{_grid[i, j].Distance}".PadLeft(4) + " ";
				}
				s.Add(line);
			}
			File.AppendAllLines(@"/Users/ipek/Projects/AdventOfCode2021/Solutions/Day15/output2.txt", s);

			var finalNode = _grid[_grid.GetUpperBound(0), _grid.GetUpperBound(1)];
			Console.WriteLine($"{(DateTime.UtcNow - timer).TotalMilliseconds}ms");
			Console.WriteLine(finalNode.Distance + " : " + (DateTime.UtcNow - timer));
		}

		private static List<Node> FindNeighbours(Node node) {
			var neighbours = new List<Node>();

			if (node.X < _grid.GetLength(1) - 1) {
				neighbours.Add(_grid[node.Y, node.X + 1]);
			}

			if (node.Y < _grid.GetLength(0) - 1) {
				neighbours.Add(_grid[node.Y + 1, node.X]);
			}

			return neighbours;
		}
	}

	internal class Node {
		public int Distance;
		public readonly int Y;
		public readonly int X;
		public readonly int Weight;
		public bool InQueue;
		public bool Visited;

		public Node(int x, int y, int weight) {
			X = x;
			Y = y;
			Weight = weight;
			Distance = 0;
			InQueue = false;
			Visited = false;
		}
	}
}