using System;
using AdventOfCode2021.Solutions.Day1;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            SonarSweep sonarSweep = new SonarSweep();
            var count = sonarSweep.CalculateWindowIncreaseCount();
            Console.WriteLine(count);
        }
    }
}
