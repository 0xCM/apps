//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using XF = ExprPatterns;

    [ApiHost]
    public readonly struct Terms
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Constant<T> constant<T>(T value)
            => new Constant<T>(value);

        [MethodImpl(Inline), Op]
        public static ExprVar var(VarSymbol name)
            => new ExprVar(name);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NamedTerm<T> term<T>(Name name, T value, params ITerm[] terms)
            => new NamedTerm<T>(name,value,terms);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ResolvedVar<T> resolve<T>(IVar var, T value)
            => value;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ResolvedVar<T> resolve<T>(IVarSymbol var, T value)
            => value;

        internal static string format(in Var src, bool bind = true)
            => bind ? src.Resolve().Format() : string.Format(XF.UntypedVar, src);

        internal static string format<T>(in Var<T> src, bool bind = true)
            => bind ? src.Value.Format() : string.Format(XF.TypedVar, src);
    }
}