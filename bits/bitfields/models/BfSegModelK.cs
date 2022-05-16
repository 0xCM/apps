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
        public readonly uint MinPos;

        /// <summary>
        /// The index of the last bit in the segment
        /// </summary>
        public readonly uint MaxPos;

        /// <summary>
        /// The segment width
        /// </summary>
        public readonly byte Width;

        /// <summary>
        /// The segment mask
        /// </summary>
        public readonly BitMask Mask;

        [MethodImpl(Inline)]
        public BfSegModel(asci64 name, uint min, uint max, BitMask mask)
        {
            SegName = name;
            MinPos = min;
            MaxPos = max;
            Width = (byte)bits.segwidth(MinPos,MaxPos);
            Mask = mask;
        }

        public string Format()
            => api.expr(this);


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BfSegModel(BfSegModel<K> src)
            => new (src.SegName, src.MinPos, src.MaxPos, src.Mask);
    }
}