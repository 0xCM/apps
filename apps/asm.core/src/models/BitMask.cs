//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using System.Runtime.CompilerServices;

    using static Root;

    using api = BitPatterns;

    public struct BitMask
    {
        internal readonly byte Width;

        internal ulong Value;

        [MethodImpl(Inline)]
        internal BitMask(byte width, ulong value)
        {
            Width = width;
            Value = value;
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static BitMask operator ~(BitMask src)
            => api.invert(ref src);

        public static BitMask Empty => default;
    }
}