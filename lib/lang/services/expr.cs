//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using Expr;

    using static Root;
    using static core;

    [ApiHost("expr.api")]
    public readonly struct expr
    {
        const NumericKind Closure = UnsignedInts;

        public static ExprContext context()
            => new ExprContext();

        [MethodImpl(Inline), Op]
        public static ExprVar var(VarSymbol name)
            => new ExprVar(name);

        /// <summary>
        /// Creates a global scope
        /// </summary>
        /// <param name="name">The scope name</param>
        [MethodImpl(Inline), Op]
        public static ExprScope scope(string name)
            => new ExprScope(EmptyString, name);

        /// <summary>
        /// Creates a child scope
        /// </summary>
        /// <param name="name">The scope name</param>
        [MethodImpl(Inline), Op]
        public static ExprScope scope(string parent, string name)
            => new ExprScope(parent,name);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Constant<T> constant<T>(T value)
            => new Constant<T>(value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static scalar<T> scalar<T>(T src, BitWidth content = default)
            where T : unmanaged, IEquatable<T>
                => new scalar<T>(src,content);

        [MethodImpl(Inline), Op]
        public static OpExprSpec spec(ExprScope scope, string opname, IExpr[] operands)
            => new OpExprSpec(scope,opname,operands);

        [MethodImpl(Inline), Op]
        public static ExprSpec spec(ExprScope scope, IExpr[] operands, IExprComposer composer)
            => new ExprSpec(scope,operands,composer);

        /// <summary>
        /// Defines a scalar range expression
        /// </summary>
        /// <param name="min">The minimum scalar in the range</param>
        /// <param name="max">The maximum scalar in the range</param>
        /// <typeparam name="T">The scalar type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SeqRange<T> range<T>(T min, T max)
            where T : IComparable<T>, IEquatable<T>
                => new SeqRange<T>(min, max);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Literal<T> literal<T>(string name, T value)
            => new Literal<T>(name, value);

        public static LiteralSeq<T> literals<T>(Identifier name, ReadOnlySpan<string> names, ReadOnlySpan<T> values)
            where T : IEquatable<T>, IComparable<T>
                => new LiteralSeq<T>(name, literals(names,values).Storage);

        static Index<Literal<T>> literals<T>(ReadOnlySpan<string> names, ReadOnlySpan<T> values)
        {
            var count = names.Length;
            Require.equal(count, values.Length);
            var literals = alloc<Literal<T>>(count);
            for(var i=0; i<count; i++)
                seek(literals,i) = new Literal<T>(skip(names,i), skip(values,i));
            return literals;
        }
   }
}