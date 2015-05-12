namespace LinqPadHelpers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	
  public static class HistogramFunctionality
  {
	public static IEnumerable<HistogramFunctionality.HistogramData2<T>> HistogramZip<T>(this IEnumerable<HistogramFunctionality.HistogramData<T>> x1, IEnumerable<HistogramFunctionality.HistogramData<T>> x2)
	{
	  Dictionary<T, HistogramFunctionality.HistogramData2<T>> dictionary = new Dictionary<T, HistogramFunctionality.HistogramData2<T>>();
	  foreach (HistogramFunctionality.HistogramData<T> histogramData in x1)
	  {
		if (!dictionary.ContainsKey(histogramData.Key))
		  dictionary.Add(histogramData.Key, new HistogramFunctionality.HistogramData2<T>()
		  {
			Key = histogramData.Key
		  });
		dictionary[histogramData.Key].Count1 = histogramData.Count;
		dictionary[histogramData.Key].PercentLocalTotal1 = histogramData.PercentTotal;
	  }
	  foreach (HistogramFunctionality.HistogramData<T> histogramData in x2)
	  {
		if (!dictionary.ContainsKey(histogramData.Key))
		  dictionary.Add(histogramData.Key, new HistogramFunctionality.HistogramData2<T>()
		  {
			Key = histogramData.Key
		  });
		dictionary[histogramData.Key].Count2 = histogramData.Count;
		dictionary[histogramData.Key].PercentLocalTotal2 = histogramData.PercentTotal;
	  }
	  int globalCount = Enumerable.Sum<HistogramFunctionality.HistogramData2<T>>((IEnumerable<HistogramFunctionality.HistogramData2<T>>) dictionary.Values, (Func<HistogramFunctionality.HistogramData2<T>, int>) (r => r.Count1 + r.Count2));
	  return Enumerable.Select<HistogramFunctionality.HistogramData2<T>, HistogramFunctionality.HistogramData2<T>>((IEnumerable<HistogramFunctionality.HistogramData2<T>>) dictionary.Values, (Func<HistogramFunctionality.HistogramData2<T>, HistogramFunctionality.HistogramData2<T>>) (r => new HistogramFunctionality.HistogramData2<T>()
	  {
		Key = r.Key,
		PercentLocalTotal1 = r.PercentLocalTotal1,
		PercentLocalTotal2 = r.PercentLocalTotal2,
		Count1 = r.Count1,
		Count2 = r.Count2,
		PercentGlobalTotal1 = 100.0 * (double) r.Count1 / (double) globalCount,
		PercentGlobalTotal2 = 100.0 * (double) r.Count2 / (double) globalCount
	  }));
	}

    public static IEnumerable<HistogramFunctionality.HistogramData3<T>> HistogramZip<T>(this IEnumerable<HistogramFunctionality.HistogramData<T>> x1, IEnumerable<HistogramFunctionality.HistogramData<T>> x2, IEnumerable<HistogramFunctionality.HistogramData<T>> x3)
    {
      Dictionary<T, HistogramFunctionality.HistogramData3<T>> dictionary = new Dictionary<T, HistogramFunctionality.HistogramData3<T>>();
      foreach (HistogramFunctionality.HistogramData<T> histogramData in x1)
      {
        if (!dictionary.ContainsKey(histogramData.Key))
          dictionary.Add(histogramData.Key, new HistogramFunctionality.HistogramData3<T>()
          {
            Key = histogramData.Key
          });
        dictionary[histogramData.Key].Count1 = histogramData.Count;
        dictionary[histogramData.Key].PercentLocalTotal1 = histogramData.PercentTotal;
      }
      foreach (HistogramFunctionality.HistogramData<T> histogramData in x2)
      {
        if (!dictionary.ContainsKey(histogramData.Key))
          dictionary.Add(histogramData.Key, new HistogramFunctionality.HistogramData3<T>()
          {
            Key = histogramData.Key
          });
        dictionary[histogramData.Key].Count2 = histogramData.Count;
        dictionary[histogramData.Key].PercentLocalTotal2 = histogramData.PercentTotal;
      }
      foreach (HistogramFunctionality.HistogramData<T> histogramData in x3)
      {
        if (!dictionary.ContainsKey(histogramData.Key))
          dictionary.Add(histogramData.Key, new HistogramFunctionality.HistogramData3<T>()
          {
            Key = histogramData.Key
          });
        dictionary[histogramData.Key].Count3 = histogramData.Count;
        dictionary[histogramData.Key].PercentLocalTotal3 = histogramData.PercentTotal;
      }
      int globalCount = Enumerable.Sum<HistogramFunctionality.HistogramData3<T>>((IEnumerable<HistogramFunctionality.HistogramData3<T>>) dictionary.Values, (Func<HistogramFunctionality.HistogramData3<T>, int>) (r => r.Count1 + r.Count2 + r.Count3));
      return Enumerable.Select<HistogramFunctionality.HistogramData3<T>, HistogramFunctionality.HistogramData3<T>>((IEnumerable<HistogramFunctionality.HistogramData3<T>>) dictionary.Values, (Func<HistogramFunctionality.HistogramData3<T>, HistogramFunctionality.HistogramData3<T>>) (r => new HistogramFunctionality.HistogramData3<T>()
      {
        Key = r.Key,
        PercentLocalTotal1 = r.PercentLocalTotal1,
        PercentLocalTotal2 = r.PercentLocalTotal2,
        PercentLocalTotal3 = r.PercentLocalTotal3,
        Count1 = r.Count1,
        Count2 = r.Count2,
        Count3 = r.Count3,
        PercentGlobalTotal1 = (double) r.Count1 * 100.0 / (double) globalCount,
        PercentGlobalTotal2 = (double) r.Count2 * 100.0 / (double) globalCount,
        PercentGlobalTotal3 = (double) r.Count3 * 100.0 / (double) globalCount
      }));
    }

    public static IEnumerable<HistogramFunctionality.HistogramData5<T>> HistogramZip<T>(this IEnumerable<HistogramFunctionality.HistogramData<T>> x1, IEnumerable<HistogramFunctionality.HistogramData<T>> x2, IEnumerable<HistogramFunctionality.HistogramData<T>> x3, IEnumerable<HistogramFunctionality.HistogramData<T>> x4, IEnumerable<HistogramFunctionality.HistogramData<T>> x5)
    {
      Dictionary<T, HistogramFunctionality.HistogramData5<T>> dictionary = new Dictionary<T, HistogramFunctionality.HistogramData5<T>>();
      foreach (HistogramFunctionality.HistogramData<T> histogramData in x1)
      {
        if (!dictionary.ContainsKey(histogramData.Key))
          dictionary.Add(histogramData.Key, new HistogramFunctionality.HistogramData5<T>()
          {
            Key = histogramData.Key
          });
        dictionary[histogramData.Key].Count1 = histogramData.Count;
        dictionary[histogramData.Key].PercentLocalTotal1 = histogramData.PercentTotal;
      }
      foreach (HistogramFunctionality.HistogramData<T> histogramData in x2)
      {
        if (!dictionary.ContainsKey(histogramData.Key))
          dictionary.Add(histogramData.Key, new HistogramFunctionality.HistogramData5<T>()
          {
            Key = histogramData.Key
          });
        dictionary[histogramData.Key].Count2 = histogramData.Count;
        dictionary[histogramData.Key].PercentLocalTotal2 = histogramData.PercentTotal;
      }
      foreach (HistogramFunctionality.HistogramData<T> histogramData in x3)
      {
        if (!dictionary.ContainsKey(histogramData.Key))
          dictionary.Add(histogramData.Key, new HistogramFunctionality.HistogramData5<T>()
          {
            Key = histogramData.Key
          });
        dictionary[histogramData.Key].Count3 = histogramData.Count;
        dictionary[histogramData.Key].PercentLocalTotal3 = histogramData.PercentTotal;
      }
      foreach (HistogramFunctionality.HistogramData<T> histogramData in x4)
      {
        if (!dictionary.ContainsKey(histogramData.Key))
          dictionary.Add(histogramData.Key, new HistogramFunctionality.HistogramData5<T>()
          {
            Key = histogramData.Key
          });
        dictionary[histogramData.Key].Count4 = histogramData.Count;
        dictionary[histogramData.Key].PercentLocalTotal4 = histogramData.PercentTotal;
      }
      foreach (HistogramFunctionality.HistogramData<T> histogramData in x5)
      {
        if (!dictionary.ContainsKey(histogramData.Key))
          dictionary.Add(histogramData.Key, new HistogramFunctionality.HistogramData5<T>()
          {
            Key = histogramData.Key
          });
        dictionary[histogramData.Key].Count5 = histogramData.Count;
        dictionary[histogramData.Key].PercentLocalTotal5 = histogramData.PercentTotal;
      }
      int globalCount = Enumerable.Sum<HistogramFunctionality.HistogramData5<T>>((IEnumerable<HistogramFunctionality.HistogramData5<T>>) dictionary.Values, (Func<HistogramFunctionality.HistogramData5<T>, int>) (r => r.Count1 + r.Count2 + r.Count3));
      return Enumerable.Select<HistogramFunctionality.HistogramData5<T>, HistogramFunctionality.HistogramData5<T>>((IEnumerable<HistogramFunctionality.HistogramData5<T>>) dictionary.Values, (Func<HistogramFunctionality.HistogramData5<T>, HistogramFunctionality.HistogramData5<T>>) (r => new HistogramFunctionality.HistogramData5<T>()
      {
        Key = r.Key,
        PercentLocalTotal1 = r.PercentLocalTotal1,
        PercentLocalTotal2 = r.PercentLocalTotal2,
        PercentLocalTotal3 = r.PercentLocalTotal3,
        PercentLocalTotal4 = r.PercentLocalTotal4,
        PercentLocalTotal5 = r.PercentLocalTotal5,
        Count1 = r.Count1,
        Count2 = r.Count2,
        Count3 = r.Count3,
        Count4 = r.Count4,
        Count5 = r.Count5,
        PercentGlobalTotal1 = (double) r.Count1 * 100.0 / (double) globalCount,
        PercentGlobalTotal2 = (double) r.Count2 * 100.0 / (double) globalCount,
        PercentGlobalTotal3 = (double) r.Count3 * 100.0 / (double) globalCount,
        PercentGlobalTotal4 = (double) r.Count4 * 100.0 / (double) globalCount,
        PercentGlobalTotal5 = (double) r.Count5 * 100.0 / (double) globalCount
      }));
    }

    public static IEnumerable<HistogramFunctionality.HistogramData<TKey>> Histogram<T, TKey>(this IQueryable<IGrouping<TKey, T>> xs, int topK = 10)
    {
      List<IGrouping<TKey, T>> cacheToAvoidMultipleEnumerations = Enumerable.ToList<IGrouping<TKey, T>>((IEnumerable<IGrouping<TKey, T>>) Queryable.Take<IGrouping<TKey, T>>((IQueryable<IGrouping<TKey, T>>) Queryable.OrderByDescending<IGrouping<TKey, T>, int>((IQueryable<IGrouping<TKey, T>>) xs, (Expression<Func<IGrouping<TKey, T>, int>>) (x => Enumerable.Count<T>(x))), topK));
      int totalCountOfSamples = Enumerable.Sum<IGrouping<TKey, T>>((IEnumerable<IGrouping<TKey, T>>) cacheToAvoidMultipleEnumerations, (Func<IGrouping<TKey, T>, int>) (x => Enumerable.Count<T>((IEnumerable<T>) x)));
      foreach (IGrouping<TKey, T> grouping in cacheToAvoidMultipleEnumerations)
      {
        int countPerGroup = Enumerable.Count<T>((IEnumerable<T>) grouping);
        yield return new HistogramFunctionality.HistogramData<TKey>()
        {
          Key = grouping.Key,
          Count = countPerGroup,
          PercentTotal = (double) countPerGroup * 100.0 / (double) totalCountOfSamples
        };
      }
    }

    public static IEnumerable<HistogramFunctionality.HistogramData<TKey>> Histogram<T, TKey>(this IEnumerable<T> xs, Func<T, TKey> groupingFunction)
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
      foreach (TKey index in groupToCount.Keys)
        yield return new HistogramFunctionality.HistogramData<TKey>()
        {
          Key = index,
          Count = groupToCount[index],
          PercentTotal = (double) groupToCount[index] * 100.0 / (double) totalCount
        };
    }

    public class HistogramData<T>
    {
      public T Key;
      public int Count;
      public double PercentTotal;
    }

    public class HistogramData2<T>
    {
      public T Key;
      public int Count1;
      public double PercentLocalTotal1;
      public double PercentGlobalTotal1;
      public int Count2;
      public double PercentLocalTotal2;
      public double PercentGlobalTotal2;
    }

    public class HistogramData3<T>
    {
      public T Key;
      public int Count1;
      public double PercentLocalTotal1;
      public double PercentGlobalTotal1;
      public int Count2;
      public double PercentLocalTotal2;
      public double PercentGlobalTotal2;
      public int Count3;
      public double PercentLocalTotal3;
      public double PercentGlobalTotal3;
    }

    public class HistogramData5<T>
    {
      public T Key;
      public int Count1;
      public int Count2;
      public int Count3;
      public int Count4;
      public int Count5;
      public double PercentGlobalTotal1;
      public double PercentGlobalTotal2;
      public double PercentGlobalTotal3;
      public double PercentGlobalTotal4;
      public double PercentGlobalTotal5;
      public double PercentLocalTotal1;
      public double PercentLocalTotal2;
      public double PercentLocalTotal3;
      public double PercentLocalTotal4;
      public double PercentLocalTotal5;
    }
  }
}
