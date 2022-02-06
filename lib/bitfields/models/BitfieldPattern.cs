//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitfieldPatterns;

    public class BitfieldPattern
    {
        /// <summary>
        /// The pattern specification
        /// </summary>
        public string Content {get;}

        /// <summary>
        /// The pattern name
        /// </summary>
        public string Name {get;}

        /// <summary>
        /// Segment indicators/specifiers
        /// </summary>
        public Index<string> Indicators {get;}

        /// <summary>
        /// The width of the data represented by the pattern
        /// </summary>
        public byte DataWidth {get;}

        /// <summary>
        /// The minimum amount of storage required to store the represented data
        /// </summary>
        public NativeSize MinSize {get;}

        /// <summary>
        /// A data type with size of <see cref='MinSize'/> or greater
        /// </summary>
        public Type DataType {get;}

        public Index<BitfieldSegModel> Segments {get;}

        public Index<byte> SegWidths {get;}

        public string Descriptor {get;}

        public BitfieldPattern(string pattern)
        {
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

        public static BitfieldPattern Empty => new BitfieldPattern(EmptyString);
    }
}