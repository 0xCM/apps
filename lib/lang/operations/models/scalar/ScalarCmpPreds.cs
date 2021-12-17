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

    using RFM = ExprPatterns;

    public readonly struct ScalarCmpPreds
    {
        internal static string format<T>(in ScalarCmpPred<T> src)
            where T : IScalarExpr
                => string.Format(RFM.PackedSlots3, src.Left, symbol(src.Kind), src.Right);

        internal static string format(in ScalarCmpPred src)
            => string.Format(RFM.PackedSlots3, src.Left, symbol(src.Kind), src.Right);

        [Op]
        public static Sym<CmpPredKind> symbol(CmpPredKind kind)
            => Symbols.index<CmpPredKind>()[kind];

        [Op]
        public static CmpPredKind kind(SymExpr src)
            => Symbols.index<CmpPredKind>().Lookup(src, out var kind) ? kind : CmpPredKind.None;

        public static Outcome parse(ScalarType type, string src, out ScalarCmpPred dst)
        {
            dst = default;
            return true;
        }

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