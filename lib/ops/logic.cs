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
        public static Xor xor(IExpr a, IExpr b)
            => new Xor(a,b);

        [MethodImpl(Inline)]
        public static Not not(IVar a)
            => new Not(a);

        [MethodImpl(Inline), Op]
        public static Impl impl(IExpr @if, IExpr then)
            => new Impl(@if, then);

        [MethodImpl(Inline), Op]
        public static And and(IExpr a, IExpr b)
            => new And(a,b);

        [MethodImpl(Inline), Op]
        public static Or or(IExpr a, IExpr b)
            => new Or(a,b);

        [MethodImpl(Inline), Op]
        public Product<IExpr> product(params IExpr[] src)
            => new Product<IExpr>(src);

        [MethodImpl(Inline), Op]
        public Sum<IExpr> sum(params IExpr[] src)
            => new Sum<IExpr>(src);

        [MethodImpl(Inline)]
        public static Union untype<T>(Union<T> src)
            where T : IExpr
                => new Union(src.Terms.MapArray(x => (IExpr)x));
    }
}