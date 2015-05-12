namespace LinqpadHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class PercentileFunctionality
    {
        public static readonly List<float> PercentilesOfInterest = Enumerable.Range(0, 20).Select(x =>(float) x * 5).ToList();

        static PercentileFunctionality()
        {
            PercentilesOfInterest.AddRange(Enumerable.Range(96, 4).Select(r => (float)r));
        }

        public static IEnumerable<PercentileData<TPercentile>> Percentile<T, TPercentile>(this IEnumerable<T> xs, Func<T, TPercentile> percentileFunction)
        {
            var sortedxs = xs.Select(percentileFunction).ToList();
            sortedxs.Sort();
            
            var indexableSortedXs = sortedxs.ToArray();
            var countxs = sortedxs.Count;
            foreach (var num in PercentilesOfInterest)
            {
                int rank = (int) ((num*countxs)/100.0);
                yield return new PercentileData<TPercentile>
                {
                    Percentile = num,
                    Value = indexableSortedXs[rank]
                };
            }
        }

        public static IEnumerable<PercentileData2<T>> PercentileZip<T>(this IEnumerable<PercentileData<T>> x1, IEnumerable<PercentileData<T>> x2)
        {
            return x1.Zip(x2, (x, y) => new PercentileData2<T>
            {
                Percentile = x.Percentile,
                Value1 = x.Value,
                Value2 = y.Value
            });
        }

        public static IEnumerable<PercentileData3<T>> PercentileZip<T>(this IEnumerable<PercentileData<T>> x1, IEnumerable<PercentileData<T>> x2, IEnumerable<PercentileData<T>> x3)
        {
            return PercentileZip(x1, x2).Zip(x3, (x, y) => new PercentileData3<T>
            {
                Percentile = x.Percentile,
                Value1 = x.Value1,
                Value2 = x.Value2,
                Value3 = y.Value
            });
        }

        public static IEnumerable<PercentileData4<T>> PercentileZip<T>(this IEnumerable<PercentileData<T>> x1, IEnumerable<PercentileData<T>> x2, IEnumerable<PercentileData<T>> x3, IEnumerable<PercentileData<T>> x4)
        {
            return PercentileZip(x1, x2, x3).Zip(x4, (x, y) => new PercentileData4<T>
            {
                Percentile = x.Percentile,
                Value1 = x.Value1,
                Value2 = x.Value2,
                Value3 = x.Value3,
                Value4 = y.Value
            });
        }

        public static IEnumerable<PercentileData5<T>> PercentileZip<T>(this IEnumerable<PercentileData<T>> x1, IEnumerable<PercentileData<T>> x2, IEnumerable<PercentileData<T>> x3, IEnumerable<PercentileData<T>> x4, IEnumerable<PercentileData<T>> x5)
        {
            return PercentileZip(x1, x2, x3, x4).Zip(x5, (x, y) => new PercentileData5<T>
            {
                Percentile = x.Percentile,
                Value1 = x.Value1,
                Value2 = x.Value2,
                Value3 = x.Value3,
                Value4 = x.Value4,
                Value5 = y.Value
            });
        }

        public class PercentileData<T>
        {
            public float Percentile;
            public T Value;

            public override string ToString()
            {
                return Value.ToString();
            }
        }

        public class PercentileData2<T>
        {
            public float Percentile;
            public T Value1;
            public T Value2;
        }

        public class PercentileData3<T>
        {
            public float Percentile;
            public T Value1;
            public T Value2;
            public T Value3;
        }

        public class PercentileData4<T>
        {
            public float Percentile;
            public T Value1;
            public T Value2;
            public T Value3;
            public T Value4;
        }

        public class PercentileData5<T>
        {
            public float Percentile;
            public T Value1;
            public T Value2;
            public T Value3;
            public T Value4;
            public T Value5;
        }
    }
}
