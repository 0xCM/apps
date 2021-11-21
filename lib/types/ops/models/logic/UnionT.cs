//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Logic
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Union<T> : ISeqExpr<T>
        where T : IExpr
    {
        readonly Index<T> _Data;

        [MethodImpl(Inline)]
        public Union(Index<T> choices)
            => _Data = choices;

        public uint N
        {
            [MethodImpl(Inline)]
            get => _Data.Count;
        }

        public Label Name => "union<{0}>";

        public ReadOnlySpan<T> Terms
        {
            [MethodImpl(Inline)]
            get => _Data;
        }

        public string Format()
            => logic.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Union<T>(T[] src)
            => new Union<T>(src);
    }
}