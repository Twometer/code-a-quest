using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAQuest.Utils
{
    public static class DictionaryExtensions
    {
        public static KeyValuePair<TKey,TValue> Single<TKey, TValue>(this IDictionary<TKey, TValue> dict)
        {
            foreach (var d in dict)
                return d;
            throw new ArgumentException();
        }
    }
}
