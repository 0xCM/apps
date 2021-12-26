//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct Seq
    {
        public static LiteralSeq<T> literal<T>(Identifier name, ReadOnlySpan<string> names, ReadOnlySpan<T> values)
            where T : IEquatable<T>, IComparable<T>
        {
            var count = names.Length;
            Require.equal(count, values.Length);
            var literals = alloc<Literal<T>>(count);
            for(var i=0; i<count; i++)
                seek(literals,i) = new Literal<T>(skip(names,i), skip(values,i));
            return new LiteralSeq<T>(name, literals);
        }

        public static LiteralSeq<T> literal<T>(Identifier name, KeyedValue<string,T>[] src)
            where T : IEquatable<T>, IComparable<T>
        {
            var count = src.Length;
            var labels = src.Map(x => x.Key);
            var literals = alloc<Literal<T>>(count);
            for(var i=0; i<count; i++)
                seek(literals,i) = new Literal<T>(labels[i], skip(src,i).Value);
            return new LiteralSeq<T>(name,literals);
        }
    }
}