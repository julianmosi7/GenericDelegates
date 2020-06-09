using System;
using System.Collections.Generic;

namespace GenericDelegates
{
  public static class ExtensionPrint
  {
    public static void Print<T>(this IEnumerable<T> data) => Print(data, Console.WriteLine);

    public static void Print<T>(this IEnumerable<T> data, Action<string> action)
    {
      foreach (var item in data)
      {
        action(item.ToString());
      }
    }
  }
}
