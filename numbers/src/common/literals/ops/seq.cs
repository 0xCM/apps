//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Literals
    {
        public static LiteralSeq<T> seq<T>(string name, ReadOnlySpan<string> names, ReadOnlySpan<T> values)
            where T : IEquatable<T>, IComparable<T>
                => new LiteralSeq<T>(name, literals(names, values));

        public static LiteralSeq<T> seq<T>(string name, ReadOnlySpan<T> src)
            where T : IEquatable<T>, IComparable<T>
                => new LiteralSeq<T>(name, literals(src));

        public static LiteralSeq<E> seq<E>(string name, LiteralNameSource ns)
            where E : unmanaged, Enum, IComparable<E>, IEquatable<E>
        {
            var src = Symbols.index<E>();
            var count = src.Count;
            var dst = alloc<Literal<E>>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = literal<E>(Literals.name(src[i], ns), src[i].Kind);
            return new LiteralSeq<E>(name, dst);
        }
    }
}