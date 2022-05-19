//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct BfInterval : IComparable<BfInterval>
    {
        /// <summary>
        /// The index of the first bit in the segment
        /// </summary>
        public readonly uint Offset;

        /// <summary>
        /// The segment width
        /// </summary>
        public readonly byte Width;

        [MethodImpl(Inline)]
        public BfInterval(uint offset, byte width)
        {
            Offset = offset;
            Width = width;
        }

        /// <summary>
        /// The index of the last bit in the segment
        /// </summary>
        public readonly byte MaxPos
        {
            [MethodImpl(Inline)]
            get => (byte)PolyBits.endpos(Offset,Width);
        }

        public int CompareTo(BfInterval src)
            => Offset.CompareTo(src.Offset);

        public string Format()
            => PolyBits.format(this);

        public override string ToString()
            => Format();
    }
}