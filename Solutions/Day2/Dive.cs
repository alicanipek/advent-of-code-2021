using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AdventOfCode2021.Solutions {
	public class Dive {
		private readonly List<Command> Commands = new List<Command>();
		public Dive() {
			var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Input/Day2/input.txt");
			foreach (var str in File.ReadAllLines(path)) {
				var line = str.Split(' ');
				var command = new Command {
					Direction = line[0],
					Step = int.Parse(line[1])
				};
				Commands.Add(command);
			}
		}

		// Part 1
		public int CalculatePosition() {
			int horizontal = 0;
			int depth = 0;
			foreach (var command in Commands) {
				switch (command.Direction) {
					case "forward":
						horizontal += command.Step;
						break;
					case "up":
						depth -= command.Step;
						break;
					case "down":
						depth += command.Step;
						break;
					default:
						break;
				}
			}
			return depth * horizontal;
		}

		// Part 2
		public int CalculatePositionWithAim() {
			int horizontal = 0;
			int depth = 0;
			int aim = 0;
			foreach (var command in Commands) {
				switch (command.Direction) {
					case "forward":
						horizontal += command.Step;
						depth += command.Step * aim;
						break;
					case "up":
						aim -= command.Step;
						break;
					case "down":
						aim += command.Step;
						break;
					default:
						break;
				}
			}
			return depth * horizontal;
		}
	}
}

