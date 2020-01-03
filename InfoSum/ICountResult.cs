namespace InfoSum
{
    public interface ICountResult
    {
        string Description { get; }
        int DistinctCount { get; }
        int TotalCount { get; }
    }
}
