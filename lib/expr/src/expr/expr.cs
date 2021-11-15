//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using Types;
    using Expr;

    using static Root;
    using static core;

    [ApiHost("expr.api")]
    public readonly partial struct expr
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static OpExprSpec spec(ExprScope scope, Label opname, IExpr[] operands)
            => new OpExprSpec(scope,opname,operands);

        [MethodImpl(Inline), Op]
        public static ExprSpec spec(ExprScope scope, IExpr[] operands, IExprComposer composer)
            => new ExprSpec(scope,operands,composer);

        [MethodImpl(Inline), Op]
        public static Var var(Label name, Type t, Func<IExpr> resolver)
            => new Var(name, t, resolver);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Var<T> var<T>(Label name, Func<T> resolver)
            => new Var<T>(name,resolver);

        /// <summary>
        /// Defines a scalar range expression
        /// </summary>
        /// <param name="min">The minimum scalar in the range</param>
        /// <param name="max">The maximum scalar in the range</param>
        /// <typeparam name="T">The scalar type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SeqRange<T> range<T>(Value<T> min, Value<T> max)
            => new SeqRange<T>(min, max);

        /// <summary>
        /// Creates a global scope
        /// </summary>
        /// <param name="name">The scope name</param>
        [MethodImpl(Inline), Op]
        public static ExprScope scope(Label name)
            => new ExprScope(Label.Empty, name);

        /// <summary>
        /// Creates a child scope
        /// </summary>
        /// <param name="name">The scope name</param>
        [MethodImpl(Inline), Op]
        public static ExprScope scope(Label parent, Label name)
            => new ExprScope(parent,name);

        /// <summary>
        /// Creates a <see cref='Constant{T}'/>
        /// </summary>
        /// <param name="name">The constant identifier</param>
        /// <typeparam name="T">The constant type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Constant<T> constant<T>(T value)
            => new Constant<T>(value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Value<T> value<T>(T src)
            => src;

        public static LiteralSeq<E> literals<E>()
            where E : unmanaged, Enum
        {
            var src = Symbols.index<E>();
            var symbols = src.View;
            var count = symbols.Length;
            var dst = alloc<Literal<E>>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var s = ref skip(symbols, i);
                seek(dst,i) = literal<E>(s.Expr.Text, s.Kind);
            }
            return new LiteralSeq<E>(typeof(E).Name, dst);
        }

        [MethodImpl(Inline), Op]
        public static Literal<bit> literal(in Label name, bit value)
            => literal<bit>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<bool> literal(in Label name, bool value)
            => literal<bool>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<byte> literal(in Label name, byte value)
            => literal<byte>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<ushort> literal(in Label name, ushort value)
            => literal<ushort>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<uint> literal(in Label name, uint value)
            => literal<uint>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<ulong> literal(in Label name, ulong value)
            => literal<ulong>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<sbyte> literal(in Label name, sbyte value)
            => literal<sbyte>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<short> literal(in Label name, short value)
            => literal<short>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<int> literal(in Label name, int value)
            => literal<int>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<long> literal(in Label name, long value)
            => literal<long>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<float> literal(in Label name, float value)
            => literal<float>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<double> literal(in Label name, double value)
            => literal<double>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<decimal> literal(in Label name, decimal value)
            => literal<decimal>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<char> literal(in Label name, char value)
            => literal<char>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<string> literal(in Label name, string value)
            => literal<string>(name, value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        static Literal<T> literal<T>(in Label name, Constant<T> value)
            => new Literal<T>(name, value);
   }
}