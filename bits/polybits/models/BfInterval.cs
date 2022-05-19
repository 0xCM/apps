//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = PolyBits;

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct BfInterval : IComparable<BfInterval>
    {
        /// <summary>
        /// The index of the first bit in the segment
        /// </summary>
        [Render(8)]
        public readonly uint Offset;

        /// <summary>
        /// The segment width
        /// </summary>
        [Render(8)]
        public readonly byte Width;

        [MethodImpl(Inline)]
        public BfInterval(uint offset, byte width)
        {
            Offset = offset;
            Width = width;
        }

        public BfSegExpr Expr
        {
            [MethodImpl(Inline)]
            get => api.expr(this);
        }

        /// <summary>
        /// The index of the last bit in the segment
        /// </summary>
        public readonly byte MaxPos
        {
            [MethodImpl(Inline)]
            get => (byte)api.endpos(Offset,Width);
        }

        [MethodImpl(Inline)]
        public int CompareTo(BfInterval src)
            => Offset.CompareTo(src.Offset);

        public string Format()
            => Expr.Format();

        public override string ToString()
            => Format();
    }
}