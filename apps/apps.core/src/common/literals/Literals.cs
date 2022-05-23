//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct Literals
    {
        const NumericKind Closure = UnsignedInts;

        // public static ItemList<Constant<T>> items<T>(string name, ReadOnlySpan<T> src)
        //     => new (name, src.Mapi((i,x) => new ListItem<Constant<T>>((uint)i,x)));

        public static ItemList<Constant<T>> items<T>(string name, T[] src)
            => new (name, src.Mapi((i,x) => new ListItem<Constant<T>>((uint)i,x)));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Literal<T> define<T>(Identifier name, T value)
            => new Literal<T>(name, value);

        public static LiteralSeq<T> seq<T>(Identifier name, ReadOnlySpan<string> names, ReadOnlySpan<T> values)
            where T : IEquatable<T>, IComparable<T>
                => new LiteralSeq<T>(name, literals(names,values).Storage);

        public static LiteralSeq<T> seq<T>(Identifier name, ReadOnlySpan<Identifier> names, ReadOnlySpan<T> values)
            where T : IEquatable<T>, IComparable<T>
                => new LiteralSeq<T>(name, literals(names,values).Storage);

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

        public static string format<T>(LiteralSeq<T> src)
            where T : IEquatable<T>, IComparable<T>
        {
            var dst = text.buffer();
            var w = core.width<T>();
            var count = src.Count;
            var margin = 0u;
            dst.AppendLineFormat("{1}:seq<uint{0}> = {{", w, src.Name);
            margin +=4;
            for(var i=0; i<count; i++)
                dst.IndentLine(margin, src[i].Format());
            margin -=4;
            dst.IndentLine(margin, "}");
            return dst.Emit();
        }

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

        static Index<Literal<T>> literals<T>(ReadOnlySpan<string> names, ReadOnlySpan<T> values)
        {
            var count = names.Length;
            Require.equal(count, values.Length);
            var literals = alloc<Literal<T>>(count);
            for(var i=0; i<count; i++)
                seek(literals,i) = new Literal<T>(skip(names,i), skip(values,i));
            return literals;
        }

        static Index<Literal<T>> literals<T>(ReadOnlySpan<Identifier> names, ReadOnlySpan<T> values)
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