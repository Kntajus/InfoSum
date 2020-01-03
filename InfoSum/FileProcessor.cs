using System.Threading.Tasks;

namespace InfoSum
{
    public class FileProcessor
    {
        private readonly string _csvPath;

        public FileProcessor(string pathToCsv) => _csvPath = pathToCsv;

        public Task<KeyCounter<int>> GetKeyCounts() => Task.Run(Process);

        private KeyCounter<int> Process()
        {
            var keyCounter = new KeyCounter<int>(_csvPath);
            using var fileA = new ValueReader(_csvPath);
            foreach (var row in fileA.GetRows())
                if (row.udprn.HasValue)
                    keyCounter.Count(row.udprn.Value);

            return keyCounter;
        }
    }
}
