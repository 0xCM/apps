//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Bitfields;

    /// <summary>
    /// Defines an identified, contiguous bitsequence, represented symbolically as {Identifier}:[Min,Max]
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct BitfieldSegModel
    {
        public const string TableId = "bitfields.models.segments";

        /// <summary>
        /// The segment name
        /// </summary>
        public text31 SegName;

        /// <summary>
        /// The index of the first bit in the segment
        /// </summary>
        public byte MinIndex;

        /// <summary>
        /// The index of the last bit in the segment
        /// </summary>
        public byte MaxIndex;

        /// <summary>
        /// The segment width
        /// </summary>
        public byte SegWidth;

        /// <summary>
        /// The segment mask
        /// </summary>
        public BitMask Mask;

        [MethodImpl(Inline)]
        public BitfieldSegModel(text31 name, byte min, byte max, BitMask mask = default)
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