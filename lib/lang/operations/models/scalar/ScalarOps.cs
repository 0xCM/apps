//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using Ops;
    using Ops.Scalar;

    using static Root;

    [ApiHost]
    public readonly struct ScalarOps
    {
        [Op]
        public static Sym<CmpPredKind> symbol(CmpPredKind kind)
            => Symbols.index<CmpPredKind>()[kind];

        [Op]
        public static CmpPredKind kind(SymExpr src)
            => Symbols.index<CmpPredKind>().Lookup(src, out var kind) ? kind : CmpPredKind.None;

        [MethodImpl(Inline)]
        public static Eq<T> eq<T>(T a, T b)
            where T : IScalarExpr
                => new Eq<T>(a,b);

        [MethodImpl(Inline)]
        public static Neq<T> neq<T>(T a, T b)
            where T : IScalarExpr
                => new Neq<T>(a,b);

        [MethodImpl(Inline)]
        public static Ge<T> ge<T>(T a, T b)
            where T : IScalarExpr
                => new Ge<T>(a,b);

        [MethodImpl(Inline)]
        public static Gt<T> gt<T>(T a, T b)
            where T : IScalarExpr
                => new Gt<T>(a,b);

        [MethodImpl(Inline)]
        public static Le<T> le<T>(T a, T b)
            where T : IScalarExpr
                => new Le<T>(a,b);

        [MethodImpl(Inline)]
        public static Lt<T> lt<T>(T a, T b)
            where T : IScalarExpr
                => new Lt<T>(a,b);

        [MethodImpl(Inline)]
        public static Ngt<T> ngt<T>(T a, T b)
            where T : IScalarExpr
                => new Ngt<T>(a,b);

        [MethodImpl(Inline)]
        public static Nlt<T> nlt<T>(T a, T b)
            where T : IScalarExpr
                => new Nlt<T>(a,b);
    }
}