using System.Linq;

namespace InfoSum
{
    public class OverlapCalculator<TKeyType>
    {
        public ICountResult Calculate(KeyCounter<TKeyType> counter1, KeyCounter<TKeyType> counter2)
        {
            var countResult = new CountResult($"Overlap of <{counter1.Description}> and <{counter2.Description}>");

            countResult.DistinctCount = counter1.DistinctKeys.Intersect(counter2.DistinctKeys).Count();

            foreach (var key in counter1.DistinctKeys)
                countResult.TotalCount += counter1.GetCount(key) * counter2.GetCount(key);

            return countResult;
        }
    }
}
