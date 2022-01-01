//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class SeqExpr<T> : ISeqExpr<T>
        where T : IExpr
    {
        readonly Index<T> Data;

        public SeqExpr(params T[] terms)
        {
            Data = terms;
        }

        public uint N
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ReadOnlySpan<T> Terms
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

        [MethodImpl(Inline)]
        public static implicit operator SeqExpr<T>(T[] src)
            => new SeqExpr<T>(src);
    }
}