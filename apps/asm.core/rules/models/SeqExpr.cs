//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class SeqExpr : ISeqExpr<IExpr>
    {
        readonly Index<IExpr> Data;

        public SeqExpr(params IExpr[] terms)
        {
            Data = terms;
        }

        public uint N
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }


        public ReadOnlySpan<IExpr> Terms
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public string Format()
            => text.bracket(Data.Delimit().Format());

        public override string ToString()
            => Format();

        public static implicit operator SeqExpr(IExpr[] src)
            => new SeqExpr(src);
    }
}