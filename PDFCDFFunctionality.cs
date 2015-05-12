namespace LinqpadHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class PDFCDFFunctionality
    {
        public static IEnumerable<PDFCDFData<TKey>> PDFCDF<T, TKey>(this IEnumerable<T> xs, Func<T, TKey> groupingFunction)
        {
            Dictionary<TKey, int> groupToCount = new Dictionary<TKey, int>();
            int totalCount = 0;
            foreach (T obj in xs)
            {
                TKey key = groupingFunction(obj);
                int num = 0;
                if (!groupToCount.TryGetValue(key, out num))
                    groupToCount[key] = 0;
                Dictionary<TKey, int> dictionary;
                TKey index;
                (dictionary = groupToCount)[index = key] = dictionary[index] + 1;
                ++totalCount;
            }

            List<TKey> sortedKeys = groupToCount.Keys.ToList();
            sortedKeys.Sort();
            double culmativeProbablity = 0.0;
            foreach (TKey index in sortedKeys)
            {
                int count = groupToCount[index];
                double probability = count / (double)totalCount;
                culmativeProbablity += probability;
                yield return new PDFCDFData<TKey>
                {
                    Key = index,
                    Count = count,
                    Probability = probability,
                    CulmativeProbabilty = culmativeProbablity
                };
            }
        }

        public class PDFCDFData<T>
        {
            public T Key;
            public double Probability;
            public double CulmativeProbabilty;
            public int Count;
        }
    }
}
