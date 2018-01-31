using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace TomExtensions.Collections
{
    public static class EnumerableExtensions
    {
      public static bool None<T>(this IEnumerable<T> self) => !self.Any();

      public static bool None<T>(this IEnumerable<T> self, Predicate<T> predicate) => 
        !self.Any(predicate);

      public static bool None<T>(this IEnumerable<T> self, Func<T, bool> func) =>
        !self.Any(new Predicate<T>(func));

    public static bool Any<T>(this IEnumerable<T> self, Predicate<T> predicate) =>
        self.Any((Func<T, bool>)(e => predicate(e)));

      public static IEnumerable<int> Range(int count) => 
        Enumerable.Range(0, count);
    
      public static IEnumerable<T> Generate<T>(Func<T> generator, int count)
      {
        for (var i = 0; i < count; i++)
        {
          yield return generator();
        }
      }
    }
}
