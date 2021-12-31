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

    partial struct expr
    {
        public static LiteralSeq<T> literals<T>(Identifier name, ReadOnlySpan<string> names, ReadOnlySpan<T> values)
            where T : IEquatable<T>, IComparable<T>
                => new LiteralSeq<T>(name, literals(names,values).Storage);

        public static LiteralSeq<E> literals<E>(LiteralNameSource ns)
            where E : unmanaged, Enum, IComparable<E>, IEquatable<E>
        {
            var src = Symbols.index<E>();
            var symbols = src.View;
            var count = symbols.Length;
            var dst = alloc<Literal<E>>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var s = ref skip(symbols, i);
                seek(dst,i) = literal<E>(name(s,ns), s.Kind);
            }
            return new LiteralSeq<E>(typeof(E).Name, dst);
        }


        public static LiteralSeq<T> literals<T>(Identifier name, KeyedValue<string,T>[] src)
            where T : IEquatable<T>, IComparable<T>
        {
            var count = src.Length;
            var labels = src.Map(x => x.Key);
            var literals = alloc<Literal<T>>(count);
            for(var i=0; i<count; i++)
                seek(literals,i) = new Literal<T>(labels[i], skip(src,i).Value);
            return new LiteralSeq<T>(name,literals);
        }

        static Index<Literal<T>> literals<T>(ReadOnlySpan<string> names, ReadOnlySpan<T> values)
        {
            var count = names.Length;
            Require.equal(count, values.Length);
            var literals = alloc<Literal<T>>(count);
            for(var i=0; i<count; i++)
                seek(literals,i) = new Literal<T>(skip(names,i), skip(values,i));
            return literals;
        }

       static string name<E>(Sym<E> sym, LiteralNameSource src)
            where E : unmanaged
            => src switch{
                LiteralNameSource.Expression => sym.Expr.Text,
                LiteralNameSource.Identifier => sym.Name,
                _ => sym.Name
            };
    }
}