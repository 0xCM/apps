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

    [ApiHost("expr.api")]
    public readonly partial struct expr
    {
        const NumericKind Closure = UnsignedInts;

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
        public static SeqRange<T> range<T>(Value<T> min, Value<T> max)
            => new SeqRange<T>(min, max);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Value<T> value<T>(T src)
            => src;
   }
}