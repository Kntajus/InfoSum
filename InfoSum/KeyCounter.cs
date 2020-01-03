using System.Collections.Generic;

namespace InfoSum
{
    public class KeyCounter<TKeyType> : ICountResult
    {
        private readonly Dictionary<TKeyType, int> _keyCounts = new Dictionary<TKeyType, int>();

        public KeyCounter(string description) => Description = description;

        public string Description { get; }
        public int DistinctCount => _keyCounts.Keys.Count;
        public int TotalCount { get; private set; }
        public IEnumerable<TKeyType> DistinctKeys => _keyCounts.Keys;

        public void Count(TKeyType value)
        {
            TotalCount++;
            _keyCounts[value] = GetCount(value) + 1;
        }

        public int GetCount(TKeyType value) => _keyCounts.ContainsKey(value) ? _keyCounts[value] : 0;
    }
}
