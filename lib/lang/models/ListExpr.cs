//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class ListExpr : IExpr
    {

        readonly Index<ITerm> Data;

        public ListExpr(params ITerm[] terms)
        {
            Data = terms;
        }

        public ReadOnlySpan<ITerm> Terms
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public string Format()
            => text.bracket(Data.Delimit().Format());

        public override string ToString()
            => Format();

        public static implicit operator ListExpr(ITerm[] src)
            => new ListExpr(src);
    }
}