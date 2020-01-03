using System.Collections.Generic;
using Xunit;

namespace InfoSum.Test
{
    public class OverlapCalculatorTests
    {
        [Theory]
        [MemberData(nameof(OverlapData))]
        public void CalculateReturnsCorrectValues(int[] dataset1, int[] dataset2, int expectedTotal, int expectedDistinct)
        {
            // Given
            var keyCounts1 = CreateKeyCounter(dataset1);
            var keyCounts2 = CreateKeyCounter(dataset2);
            var calculator = new OverlapCalculator<int>();

            // When
            var overlap = calculator.Calculate(keyCounts1, keyCounts2);

            // Then
            Assert.Equal(expectedTotal, overlap.TotalCount);
            Assert.Equal(expectedDistinct, overlap.DistinctCount);
        }

        public static IEnumerable<object[]> OverlapData()
        {
            yield return new object[] { new[] { 0, 1 }, new[] { 2, 3 }, 0, 0 }; // No overlap
            yield return new object[] { new[] { 1, 2 }, new[] { 2, 3 }, 1, 1 }; // Single overlap
            yield return new object[] { new[] { 1, 2, 2 }, new[] { 2, 3 }, 2, 1 }; // Duplicate in set 1
            yield return new object[] { new[] { 1, 2 }, new[] { 2, 2, 3 }, 2, 1 }; // Duplicate in set 2
            yield return new object[] { new[] { 1, 2, 2 }, new[] { 2, 2, 3 }, 4, 1 }; // Duplicate in both sets
            yield return new object[] { new[] { 1, 2, 2, 2 }, new[] { 2, 2, 3 }, 6, 1 }; // Triplicate in set 1, Duplicate in set 2
            yield return new object[] { new[] { 1, 2, 2, 2, 3, 3, 4, 4, 4 }, new[] { 2, 2, 3, 3, 3, 3, 4, 5 }, 17, 3 }; // Many!
        }

        private static KeyCounter<int> CreateKeyCounter(int[] dataset)
        {
            var keyCounter = new KeyCounter<int>("Arbitrary");
            foreach (var value in dataset)
                keyCounter.Count(value);
            return keyCounter;
        }
    }
}
