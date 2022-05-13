//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct BitfieldInterval<F> : IComparable<BitfieldInterval>
        where F : unmanaged
    {
        /// <summary>
        /// The index of the first bit in the segment
        /// </summary>
        public readonly uint Offset;

        /// <summary>
        /// The segment width
        /// </summary>
        public readonly byte Width;

        public readonly F Field;

        [MethodImpl(Inline)]
        public BitfieldInterval(uint offset, byte width, F field)
        {
            Field = field;
            Offset = offset;
            Width = width;
        }

        /// <summary>
        /// The index of the last bit in the segment
        /// </summary>
        public readonly byte Max
        {
            [MethodImpl(Inline)]
            get => (byte)Bitfields.endpos(Offset,Width);
        }

        public int CompareTo(BitfieldInterval src)
            => Offset.CompareTo(src.Offset);

        public string Format()
            => Bitfields.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BitfieldInterval(BitfieldInterval<F> src)
            => new BitfieldInterval(src.Offset,src.Width);
    }
}