//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Literals
    {
        static Index<Literal<T>> literals<T>(ReadOnlySpan<T> src)
        {
            var count = src.Length;
            var dst = alloc<Literal<T>>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = new (skip(src,i).ToString(), skip(src,i));
            return dst;
        }

        static Index<Literal<T>> literals<T>(ReadOnlySpan<string> names, ReadOnlySpan<T> values)
        {
            var count = names.Length;
            Require.equal(count, values.Length);
            var literals = alloc<Literal<T>>(count);
            for(var i=0; i<count; i++)
                seek(literals,i) = new (skip(names,i), skip(values,i));
            return literals;
        }

        public static LiteralSeq<T> seq<T>(string name, ReadOnlySpan<string> names, ReadOnlySpan<T> values)
            where T : IEquatable<T>, IComparable<T>
                => new LiteralSeq<T>(name, literals(names, values));

        public static LiteralSeq<T> seq<T>(string name, ReadOnlySpan<T> src)
            where T : IEquatable<T>, IComparable<T>
                => new LiteralSeq<T>(name, literals(src));

        static string name<E>(Sym<E> sym, LiteralNameSource src)
            where E : unmanaged
            => src switch{
                LiteralNameSource.Expression => sym.Expr.Text,
                LiteralNameSource.Identifier => sym.Name,
                _ => sym.Name
            };

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