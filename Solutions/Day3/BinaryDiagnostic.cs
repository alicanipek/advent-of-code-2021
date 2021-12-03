using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2021.Solutions.Day3 {
	public class BinaryDiagnostic {
		private readonly string[] Diagnostics;
		public BinaryDiagnostic() {
			var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Input/Day3/input.txt");
			Diagnostics = File.ReadAllLines(path);
		}

		public int CalculatePowerConsumption() {
			var gammaRate = "";
			var epsilonRate = "";
			for (int i = 0; i < Diagnostics[0].Length; i++) {
				int zeroCount = 0;
				int oneCount = 0;
				for (int j = 0; j < Diagnostics.Length; j++) {
					if (Diagnostics[j][i] == '0') {
						zeroCount++;
					} else {
						oneCount++;
					}
				}
				gammaRate += zeroCount > oneCount ? "0" : "1";
				epsilonRate += zeroCount > oneCount ? "1" : "0";
			}
			return ToDecimal(gammaRate) * ToDecimal(epsilonRate);
		}

		public int CalculateLifeSupportRating() {
			var oxygen = Diagnostics.ToList();
			var carbon = Diagnostics.ToList();

			for (int i = 0; i < Diagnostics[0].Length; i++) {
				int zeroCount = 0;
				int oneCount = 0;
				if (oxygen.Count == 1) break;

				for (int j = 0; j < oxygen.Count; j++) {
					if (oxygen[j][i] == '0') {
						zeroCount++;
					} else {
						oneCount++;
					}
				}
				var f = oneCount >= zeroCount ? '1' : '0';
				oxygen = oxygen.Where(x => x[i] == f).ToList();
			}
			for (int i = 0; i < Diagnostics[0].Length; i++) {
				int zeroCount = 0;
				int oneCount = 0;
				if (carbon.Count == 1) break;

				for (int j = 0; j < carbon.Count; j++) {
					if (carbon[j][i] == '0') {
						zeroCount++;
					} else {
						oneCount++;
					}
				}
				var f = zeroCount <= oneCount ? '0' : '1';
				carbon = carbon.Where(x => x[i] == f).ToList();
			}

			return ToDecimal(oxygen) * ToDecimal(carbon);

		}

		public int ToDecimal(List<string> binary) => Convert.ToInt32(String.Join("", binary), 2);
		public int ToDecimal(string binary) => Convert.ToInt32(binary, 2);
	}
}

