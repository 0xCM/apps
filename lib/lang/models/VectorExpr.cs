//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class VectorExpr : IExpr
    {

        readonly Index<ITerm> Data;

        public VectorExpr(params ITerm[] terms)
        {
            Data = terms;
        }

        public uint N
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ReadOnlySpan<ITerm> Terms
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public string Format()
            => string.Format("<{0}>",Data.Delimit().Format());

        public override string ToString()
            => Format();

        public static implicit operator VectorExpr(ITerm[] src)
            => new VectorExpr(src);
    }
}