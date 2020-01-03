namespace InfoSum
{
    public class CountResult : ICountResult
    {
        public CountResult(string description) => Description = description;

        public string Description { get; }
        public int DistinctCount { get; set; }
        public int TotalCount { get; set; }
    }
}
