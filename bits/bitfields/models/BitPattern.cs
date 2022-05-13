//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitPatterns;

    public class BitPattern
    {
        /// <summary>
        /// The pattern source
        /// </summary>
        public readonly BfOrigin Origin;

        /// <summary>
        /// The pattern specification
        /// </summary>
        public readonly string Content;

        /// <summary>
        /// The pattern name
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Segment indicators/specifiers
        /// </summary>
        public readonly Index<string> Indicators;

        /// <summary>
        /// The width of the data represented by the pattern
        /// </summary>
        public readonly byte DataWidth;

        /// <summary>
        /// The minimum amount of storage required to store the represented data
        /// </summary>
        public readonly NativeSize MinSize;

        /// <summary>
        /// A data type with size of <see cref='MinSize'/> or greater
        /// </summary>
        public readonly Type DataType;

        public readonly Index<BitfieldSegModel> Segments;

        public readonly Index<byte> SegWidths;

        public readonly string Descriptor;

        public BitPattern(BfOrigin orign, string pattern)
        {
            Origin = orign;
            Content = text.despace(pattern);
            Name = name(Content);
            Indicators = indicators(Content);
            DataWidth = datawidth(Content);
            DataType = datatype(Content);
            MinSize = minsize(Content);
            SegWidths = segwidths(Content);
            Segments = segments(Content);
            Descriptor = descriptor(Content);
        }

        public uint SegCount
        {
            [MethodImpl(Inline)]
            get => Indicators.Count;
        }

        public string Format()
            => Descriptor;

        public override string ToString()
            => Format();

        public static BitPattern Empty => new BitPattern(BfOrigin.Empty, EmptyString);
    }
}