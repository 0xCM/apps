//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Bitfields;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct BitfieldSegModel<K>
        where K : unmanaged
    {
        /// <summary>
        /// The segment name
        /// </summary>
        public readonly text31 SegName;

        /// <summary>
        /// The index of the first bit in the segment
        /// </summary>
        public readonly byte MinIndex;

        /// <summary>
        /// The index of the last bit in the segment
        /// </summary>
        public readonly byte MaxIndex;

        /// <summary>
        /// The segment width
        /// </summary>
        public readonly byte SegWidth;

        /// <summary>
        /// The segment mask
        /// </summary>
        public readonly BitMask Mask;

        [MethodImpl(Inline)]
        public BitfieldSegModel(text31 name, byte min, byte max, BitMask mask)
        {
            SegName = name;
            MinIndex = min;
            MaxIndex = max;
            SegWidth = bits.segwidth(MinIndex,MaxIndex);
            Mask = mask;
        }

        public string Format()
            => api.format(this);


        public override string ToString()
            => Format();
    }
}