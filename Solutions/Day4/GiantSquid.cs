using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2021.Solutions {
	public class GiantSquid {
		private readonly int[] DrawnNumbers;
		private readonly List<List<int[]>> Boards = new List<List<int[]>>();
		public GiantSquid() {
			var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Input/Day4/input.txt");
			using (StreamReader reader = new StreamReader(path)) {
				string line1 = reader.ReadLine();
				DrawnNumbers = line1.Split(',').Select(int.Parse).ToArray();
				reader.ReadLine();
				string line;
				List<int[]> board = new List<int[]>();
				while ((line = reader.ReadLine()) != null) {
					if (line == "") {
						Boards.Add(board);
						board = new List<int[]>();
					} else {
						board.Add(Array.ConvertAll(line.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray(), int.Parse));
					}
				}
				Boards.Add(board);
			}
		}

		// Part 1
		public int Bingo() {
			var score = 0;
			foreach (var number in DrawnNumbers) {
				foreach (var board in Boards) {
					if (board.Any(x => x.Contains(number))) {
						var t = board.FindAll(x => x.Contains(number));
						foreach (var item in t) {
							item[item.ToList().IndexOf(number)] = -1;
						}
						if (CheckBoard(board)) {
							score = CalculateScore(board, number);
							return score;
						}
					}
				}
			}
			return score;
		}

		// Part 2
		public int BingoSquidWin() {
			var score = 0;
			bool[] hasWon = new bool[Boards.Count];
			foreach (var number in DrawnNumbers) {
				CheckBoards(Boards, hasWon);
				foreach (var board in Boards) {
					if (board.Any(x => x.Contains(number))) {
						var t = board.FindAll(x => x.Contains(number));
						foreach (var item in t) {
							item[item.ToList().IndexOf(number)] = -1;
						}
						if (CheckBoard(board) && hasWon.Where(x => !x).Count() == 1 && !hasWon[Boards.IndexOf(board)]) {
							score = CalculateScore(board, number);
							return score;
						}
					}
				}
			}
			return score;
		}


		private int CalculateScore(List<int[]> board, int number) {
			var boardScore = 0;
			board.ForEach(x => {
				boardScore += x.Where(y => y != -1).ToArray().Sum();
			});
			return boardScore * number;
		}

		private bool CheckBoard(List<int[]> board) {
			bool rowCheck = board.Any(x => x.All(y => y == -1));
			if (rowCheck) return rowCheck;
			bool colCheck = true;

			for (int i = 0; i < board.Count; i++) {
				colCheck = true;
				for (int j = 0; j < board[i].Length; j++) {
					if (board[j][i] != -1) {
						colCheck = false;
						break;
					}
				}
				if (colCheck) {
					break;
				}
			}
			return colCheck;
		}

		private void CheckBoards(List<List<int[]>> boards, bool[] hasWon) {
			foreach (var board in boards) {
				hasWon[boards.IndexOf(board)] = CheckBoard(board);
			}
		}
	}
}
