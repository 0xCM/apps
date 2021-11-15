//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
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

         static Classifier<K,T> create<K,T>()
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
            var classes = alloc<Class<K,T>>(count);
            for(var i=0u; i<count; i++)
                seek(classes,i) =new Class<K,T>(i, name, names[i], skip(symbols,i).Expr.Text, skip(kinds,i), values[i].Value);
            return new Classifier<K,T>(name, kinds, names, symbols, values, classes);
        }

         public static Classifier<K,T> classifier<K,T>()
            where K : unmanaged, Enum
            where T : unmanaged
        {
            return (Classifier<K,T>)Lookup.GetOrAdd(typeof(K), _ => create<K,T>());
        }
    }
}
