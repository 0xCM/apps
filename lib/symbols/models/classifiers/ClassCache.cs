//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Concurrent;

    using static core;

    internal class ClassCache
    {
        static ConcurrentDictionary<Type,IClassifier> Lookup;

        static ClassCache()
        {
            Lookup = new();
        }

         static ValueClassifier<K,T> create<K,T>()
            where K : unmanaged, Enum
            where T : unmanaged
        {
            Label name = typeof(K).Name;
            var index = Symbols.index<K>();
            var names = Symbols.names<K>();
            var kinds = index.Kinds.ToArray();
            var symbols = index.View.ToArray();
            var values = Symbols.values<K,T>();
            var count = index.Count;
            var classes = alloc<ValueClass<K,T>>(count);
            for(var i=0u; i<count; i++)
                seek(classes,i) =new ValueClass<K,T>(i, name, names[i], skip(symbols,i).Expr.Text, skip(kinds,i), values[i].Value);
            return new ValueClassifier<K,T>(name, kinds, names, symbols, values, classes);
        }

         public static ValueClassifier<K,T> classifier<K,T>()
            where K : unmanaged, Enum
            where T : unmanaged
        {
            return (ValueClassifier<K,T>)Lookup.GetOrAdd(typeof(K), _ => create<K,T>());
        }
    }
}
