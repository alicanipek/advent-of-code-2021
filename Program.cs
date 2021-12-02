using System;
using AdventOfCode2021.Solutions.Day1;
using AdventOfCode2021.Solutions.Day2;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            // Day 1
            // SonarSweep sonarSweep = new SonarSweep();
            // var count = sonarSweep.CalculateWindowIncreaseCount();

            // Day 2
            Dive dive = new Dive();
            var count = dive.CalculatePositionWithAim();
            Console.WriteLine(count);
        }
    }
}
