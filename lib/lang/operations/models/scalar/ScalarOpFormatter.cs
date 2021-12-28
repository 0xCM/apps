//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Ops;

    using RFM = ExprPatterns;

    readonly struct ScalarOpFormatter
    {
        public static string format<T>(in ScalarCmpPred<T> src)
            where T : IScalarExpr
                => string.Format(RFM.PackedSlots3, src.Left, ScalarOps.symbol(src.Kind), src.Right);

        public static string format(in ScalarCmpPred src)
            => string.Format(RFM.PackedSlots3, src.Left, ScalarOps.symbol(src.Kind), src.Right);
    }
}