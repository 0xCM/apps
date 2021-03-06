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
    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId), Doc("Describes a segment in a bitfield")]
    public struct BfSegModel
    {
        public const string TableId = "bitfield.segs";

        /// <summary>
        /// The segment name
        /// </summary>
        [Render(16), Doc("The segment name")]
        public asci64 SegName;

        /// <summary>
        /// The index of the first bit in the segment
        /// </summary>
        [Render(6), Doc("The index of the first bit in the segment")]
        public uint MinPos;

        /// <summary>
        /// The index of the last bit in the segment
        /// </summary>
        [Render(6), Doc("The index of the last bit in the segment")]
        public uint MaxPos;

        /// <summary>
        /// The segment width
        /// </summary>
        [Render(6), Doc("The segment width")]
        public byte Width;

        /// <summary>
        /// The segment mask
        /// </summary>
        [Render(1), Doc("The segment mask")]
        public BitMask Mask;

        [MethodImpl(Inline)]
        public BfSegModel(in asci64 name, uint min, uint max, BitMask mask)
        {
            SegName = name;
            MinPos = min;
            MaxPos = max;
            Width = (byte)bits.segwidth(min,max);
            Mask = mask;
        }

        public BfInterval Interval
        {
            [MethodImpl(Inline)]
            get => new BfInterval(MinPos,Width);
        }

        public string Format()
            => api.expr(this);

        public override string ToString()
            => Format();
    }
}