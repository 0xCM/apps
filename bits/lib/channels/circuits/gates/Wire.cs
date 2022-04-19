//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr.Circuits
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Wire
    {
        public readonly byte Width;

        [MethodImpl(Inline)]
        public Wire(byte width)
        {
            Width = width;
        }

        [MethodImpl(Inline)]
        public static implicit operator Wire(uint width)
            => new Wire((byte)width);

        [MethodImpl(Inline)]
        public static implicit operator Wire(byte width)
            => new Wire(width);

        public string Format()
            => Width.ToString();

        public override string ToString()
            => Format();
    }
}