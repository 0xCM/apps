//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct BitfieldInterval : IComparable<BitfieldInterval>
    {
        /// <summary>
        /// The index of the first bit in the segment
        /// </summary>
        public readonly ushort Min;

        /// <summary>
        /// The segment width
        /// </summary>
        public readonly ushort Width;

        /// <summary>
        /// The index of the last bit in the segment
        /// </summary>
        public readonly ushort Max;

        readonly ushort Pad;

        [MethodImpl(Inline)]
        public BitfieldInterval(ushort offset, ushort width)
        {
            Min = offset;
            Width = width;
            Max = (ushort)Bitfields.endpos(Min,Width);
            Pad = 0;
        }

        public int CompareTo(BitfieldInterval src)
            => Min.CompareTo(src.Min);

        public string Format()
            => string.Format("[{0}:{1}]", Max, Min);

        public override string ToString()
            => Format();
    }
}