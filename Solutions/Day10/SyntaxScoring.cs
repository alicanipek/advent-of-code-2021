using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
namespace AdventOfCode2021.Solutions.Day10 {
	public class SyntaxScoring {
		private readonly List<string> Chunks;
		public SyntaxScoring() {
			Chunks = new List<string>();
			var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Input/Day10/input.txt");
			foreach (var str in File.ReadAllLines(path)) {
				Chunks.Add(str);
			}
		}

		// Part 1
		public int GetCorruptedScore() {
			var score = 0;
			foreach (var c in Chunks) {
				Stack<char> myStack = new Stack<char>();
				foreach (var item in c) {
					if ("{([<".Contains(item)) myStack.Push(item);
					else if ((item == '}' && myStack.Peek() == '{')
						|| (item == ']' && myStack.Peek() == '[')
						|| (item == ')' && myStack.Peek() == '(')
						|| (item == '>' && myStack.Peek() == '<')) myStack.Pop();
					else {
						if (item == '}') score += 1197;
						else if (item == ']') score += 57;
						else if (item == ')') score += 3;
						else if (item == '>') score += 25137;
                        break;
					}
				}
			}
            return score;
		}

		// Part 2
        public long GetIncompleteScore() {
			var scores = new List<long>();
			foreach (var c in Chunks) {
				Stack<char> myStack = new Stack<char>();
                bool isCorrupted = false;
				foreach (var item in c) {
					if ("{([<".Contains(item)) myStack.Push(item);
					else if ((item == '}' && myStack.Peek() == '{')
						|| (item == ']' && myStack.Peek() == '[')
						|| (item == ')' && myStack.Peek() == '(')
						|| (item == '>' && myStack.Peek() == '<')) myStack.Pop();
					else {
                        isCorrupted = true;
                        break;
					}
				}
                if(!isCorrupted && myStack.Any()){
                    long score = 0;
                    while(myStack.Any()){
                        var p = myStack.Pop();
                        score *= 5;
                        if (p == '(') score += 1;
						else if (p == '[') score += 2;
						else if (p == '{') score += 3;
						else if (p == '<') score += 4;
                    }
                    scores.Add(score);
                }
			}
            scores.Sort();
            return scores[scores.Count()/2];
		}
	}
}