//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public readonly struct Named
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static NameList list(Name name, Name[] names)
            => (name,names);

        [MethodImpl(Inline), Op]
        public static NameList list(string name, string[] names)
            => (name,names.Select(x => (Name)x));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NamedValue<V> value<V>(string name, V value)
            => new NamedValue<V>(name,value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NamedValues<V> values<V>(NamedValue<V>[] src)
            => new NamedValues<V>(src);

        [MethodImpl(Inline)]
        public static NamedValue<K,V> value<K,V>(K name, V value)
            => new NamedValue<K,V>(name,value);
    }
}