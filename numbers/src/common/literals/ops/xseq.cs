//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public partial class Literals
    {
        public static LiteralSeq<T> seq<T>(Identifier name, KeyedValue<Identifier,T>[] src)
            where T : IEquatable<T>, IComparable<T>
        {
            var count = src.Length;
            var labels = src.Map(x => x.Key);
            var literals = alloc<Literal<T>>(count);
            for(var i=0; i<count; i++)
                seek(literals,i) = new Literal<T>(labels[i], skip(src,i).Value);
            return new LiteralSeq<T>(name,literals);
        }

        public static LiteralSeq<T> seq<T>(Identifier name, ReadOnlySpan<string> names, ReadOnlySpan<T> values)
            where T : IEquatable<T>, IComparable<T>
                => new LiteralSeq<T>(name, define(names,values).Storage);

        public static LiteralSeq<T> seq<T>(Identifier name, ReadOnlySpan<Identifier> names, ReadOnlySpan<T> values)
            where T : IEquatable<T>, IComparable<T>
                => new LiteralSeq<T>(name, define(names,values).Storage);

        public static LiteralSeq<E> seq<E>(LiteralNameSource ns)
            where E : unmanaged, Enum, IComparable<E>, IEquatable<E>
        {
            var src = Symbols.index<E>();
            var symbols = src.View;
            var count = symbols.Length;
            var dst = alloc<Literal<E>>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var s = ref skip(symbols, i);
                seek(dst,i) = define<E>(name(s, ns), s.Kind);
            }
            return new LiteralSeq<E>(typeof(E).Name, dst);
        }
    }
}