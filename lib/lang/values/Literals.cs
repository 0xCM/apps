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

    [ApiHost]
    public readonly struct Literals
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        public static Constant<T> constant<T>(T src)
            => src;

        [MethodImpl(Inline), Op]
        public static Literal<bit> literal(string name, bit value)
            => literal<bit>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<bool> literal(string name, bool value)
            => literal<bool>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<byte> literal(string name, byte value)
            => literal<byte>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<ushort> literal(string name, ushort value)
            => literal<ushort>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<uint> literal(string name, uint value)
            => literal<uint>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<ulong> literal(string name, ulong value)
            => literal<ulong>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<sbyte> literal(string name, sbyte value)
            => literal<sbyte>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<short> literal(string name, short value)
            => literal<short>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<int> literal(string name, int value)
            => literal<int>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<long> literal(string name, long value)
            => literal<long>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<float> literal(string name, float value)
            => literal<float>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<double> literal(string name, double value)
            => literal<double>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<decimal> literal(string name, decimal value)
            => literal<decimal>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<char> literal(string name, char value)
            => literal<char>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<string> literal(string name, string value)
            => literal<string>(name, value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        static Literal<T> literal<T>(string name, Constant<T> value)
            => new Literal<T>(name, value);

        public static Index<Literal<T>> from<T>(ReadOnlySpan<string> names, ReadOnlySpan<T> values)
        {
            var count = names.Length;
            Require.equal(count, values.Length);
            var literals = alloc<Literal<T>>(count);
            for(var i=0; i<count; i++)
                seek(literals,i) = new Literal<T>(skip(names,i), skip(values,i));
            return literals;
        }

        public static LiteralSeq<T> seq<T>(Identifier name, ReadOnlySpan<string> names, ReadOnlySpan<T> values)
            => new LiteralSeq<T>(name, from(names,values).Storage);

        public static Index<Literal<T>> from<T>(KeyedValue<string,T>[] src)
        {
            var count = src.Length;
            var labels = src.Map(x => x.Key);
            var literals = alloc<Literal<T>>(count);
            for(var i=0; i<count; i++)
                seek(literals,i) = new Literal<T>(labels[i], skip(src,i).Value);
            return literals;
        }

       static string name<E>(Sym<E> sym, LiteralNameSource src)
            where E : unmanaged
            => src switch{
                LiteralNameSource.Expression => sym.Expr.Text,
                LiteralNameSource.Identifier => sym.Name,
                _ => sym.Name
            };

        public static LiteralSeq<E> seq<E>(LiteralNameSource ns)
            where E : unmanaged, Enum
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
    }
}