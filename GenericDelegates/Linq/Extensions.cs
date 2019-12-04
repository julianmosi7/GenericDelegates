using System;
using System.Collections.Generic;

namespace GenericDelegates.Linq
{
  public static class Extensions
  {

    public static List<T> Where<T>(this List<T> data, Predicate<T> filter)
    {
      //your code comes here
      return new List<T>();
    }

    public static List<S> Select<T, S>(this List<T> data, Func<T, S> projector)
    {
      //your code comes here
      return new List<S>();
    }


  }
}
