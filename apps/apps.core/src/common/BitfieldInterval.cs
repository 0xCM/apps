//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct BitfieldInterval : IComparable<BitfieldInterval>
    {
        /// <summary>
        /// The index of the first bit in the segment
        /// </summary>
        public readonly byte Min;

        /// <summary>
        /// The segment width
        /// </summary>
        public readonly byte Width;

        [MethodImpl(Inline)]
        public BitfieldInterval(byte offset, byte width)
        {
            Min = offset;
            Width = width;
        }

        /// <summary>
        /// The index of the last bit in the segment
        /// </summary>
        public readonly byte Max
        {
            [MethodImpl(Inline)]
            get => (byte)Bitfields.endpos(Min,Width);
        }

        public int CompareTo(BitfieldInterval src)
            => Min.CompareTo(src.Min);

        public string Format()
            => BitfieldMechanics.format(this);

        public override string ToString()
            => Format();
    }
}