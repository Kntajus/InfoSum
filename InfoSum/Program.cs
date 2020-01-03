using System;
using System.Threading.Tasks;

namespace InfoSum
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter paths to files, or just hit Return to accept the default value specified in brackets.");
            var file1 = GetPathFromInput("Data\\A_f.csv");
            var file2 = GetPathFromInput("Data\\B_f.csv");

            var process1 = new FileProcessor(file1).GetKeyCounts();
            var process2 = new FileProcessor(file2).GetKeyCounts();
            Task.WaitAll(process1, process2);

            var keyCounts1 = process1.Result;
            var keyCounts2 = process2.Result;

            var overlapCalculator = new OverlapCalculator<int>();
            var overlap = overlapCalculator.Calculate(keyCounts1, keyCounts2);

            WriteResults(keyCounts1);
            WriteResults(keyCounts2);
            WriteResults(overlap);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static string GetPathFromInput(string defaultPath)
        {
            Console.Write($"Enter file path [{defaultPath}] : ");
            var input = Console.ReadLine();
            return input.Length == 0 ? defaultPath : input;
        }

        private static void WriteResults(ICountResult countResult)
        {
            Console.WriteLine();
            Console.WriteLine("Results for: " + countResult.Description);
            Console.WriteLine("Total count: " + countResult.TotalCount);
            Console.WriteLine("Distinct count: " + countResult.DistinctCount);
        }
    }
}
