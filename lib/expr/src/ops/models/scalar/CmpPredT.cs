//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    using System;
    using System.Runtime.CompilerServices;

    using RFM = ExprPatterns;

    using static Root;

    public readonly struct CmpPred<T> : ICmpPred<CmpPred<T>,T>
        where T : IExpr
    {
        public T A {get;}

        public T B {get;}

        public CmpPredKind Kind {get;}

        [MethodImpl(Inline)]
        public CmpPred(T a, T b, CmpPredKind kind)
        {
            A = a;
            B = b;
            Kind = kind;
        }

        public Label OpName => "cmp<{0}>";

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        public CmpPred<T> Make(T a0, T a1)
            => default;


        internal static string format(in CmpPred<T> src)
            => string.Format(RFM.PackedSlots3, src.A, symbol(src.Kind), src.B);


        internal static string symbol(CmpPredKind kind)
            => kind switch {
                CmpPredKind.EQ => CmpPredSymbols.EQ,
                CmpPredKind.NEQ => CmpPredSymbols.NEQ,
                CmpPredKind.GT => CmpPredSymbols.GT,
                CmpPredKind.GE => CmpPredSymbols.GE,
                CmpPredKind.LT => CmpPredSymbols.LT,
                CmpPredKind.LE => CmpPredSymbols.LE,
                _ => "?",
            };
    }
}