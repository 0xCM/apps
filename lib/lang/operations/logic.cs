//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    using System;
    using System.Runtime.CompilerServices;

    using Logic;

    using static Root;

    [ApiHost]
    public readonly struct logic
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static Xor xor(IBooleanExpr a, IBooleanExpr b)
            => new Xor(a,b);

        [MethodImpl(Inline)]
        public static Not not(IBooleanExpr a)
            => new Not(a);

        [MethodImpl(Inline), Op]
        public static Impl impl(IBooleanExpr @if, IBooleanExpr then)
            => new Impl(@if, then);

        [MethodImpl(Inline), Op]
        public static And and(IBooleanExpr a, IBooleanExpr b)
            => new And(a,b);

        [MethodImpl(Inline), Op]
        public static Or or(IBooleanExpr a, IBooleanExpr b)
            => new Or(a,b);

        [MethodImpl(Inline), Op]
        public Product<IBooleanExpr> product(params IBooleanExpr[] src)
            => new Product<IBooleanExpr>(src);

        [MethodImpl(Inline), Op]
        public Sum<IBooleanExpr> sum(params IBooleanExpr[] src)
            => new Sum<IBooleanExpr>(src);

        [MethodImpl(Inline)]
        public static Union untype<T>(Union<T> src)
            where T : IBooleanExpr
                => new Union(src.Terms.MapArray(x => (IBooleanExpr)x));
    }
}