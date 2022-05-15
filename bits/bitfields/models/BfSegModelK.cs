//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Bitfields;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct BfSegModel<K>
        where K : unmanaged
    {
        /// <summary>
        /// The segment name
        /// </summary>
        public readonly asci64 SegName;

        /// <summary>
        /// The index of the first bit in the segment
        /// </summary>
        public readonly uint MinIndex;

        /// <summary>
        /// The index of the last bit in the segment
        /// </summary>
        public readonly uint MaxIndex;

        /// <summary>
        /// The segment width
        /// </summary>
        public readonly byte SegWidth;

        /// <summary>
        /// The segment mask
        /// </summary>
        public readonly BitMask Mask;

        [MethodImpl(Inline)]
        public BfSegModel(asci64 name, uint min, uint max, BitMask mask)
        {
            SegName = name;
            MinIndex = min;
            MaxIndex = max;
            SegWidth = (byte)bits.segwidth(MinIndex,MaxIndex);
            Mask = mask;
        }

        public string Format()
            => api.format(this);


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BfSegModel(BfSegModel<K> src)
            => new (src.SegName, src.MinIndex, src.MaxIndex, src.Mask);
    }
}