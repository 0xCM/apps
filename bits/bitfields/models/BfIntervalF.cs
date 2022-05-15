//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct BfInterval<F> : IComparable<BfInterval>
        where F : unmanaged
    {
        /// <summary>
        /// The field for which the interval is defined
        /// </summary>
        public readonly F Field;

        /// <summary>
        /// The index of the first bit in the segment
        /// </summary>
        public readonly uint Offset;

        /// <summary>
        /// The segment width
        /// </summary>
        public readonly byte Width;

        [MethodImpl(Inline)]
        public BfInterval(F field, uint offset, byte width)
        {
            Field = field;
            Offset = offset;
            Width = width;
        }

        /// <summary>
        /// The index of the last bit in the segment
        /// </summary>
        public readonly byte MaxPos
        {
            [MethodImpl(Inline)]
            get => (byte)Bitfields.endpos(Offset,Width);
        }

        public int CompareTo(BfInterval src)
            => Offset.CompareTo(src.Offset);

        public string Format()
            => Bitfields.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BfInterval(BfInterval<F> src)
            => new BfInterval(src.Offset,src.Width);
    }
}