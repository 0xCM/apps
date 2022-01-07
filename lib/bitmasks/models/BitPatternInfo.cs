//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = BitPatterns;

    public class BitPatternInfo
    {
        /// <summary>
        /// The pattern specification
        /// </summary>
        public BitPattern Pattern {get;}

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
        /// <value></value>
        public NativeSize MinSize {get;}

        /// <summary>
        /// A data type with size of <see cref='MinSize'/> or greater
        /// </summary>
        public Type DataType {get;}

        public Index<Segment> Segments {get;}

        public Index<byte> SegWidths {get;}

        public string Descriptor {get;}

        public BitPatternInfo(BitPattern pattern)
        {
            Pattern = text.despace(pattern.Text);
            Name = api.name(Pattern);
            Indicators = api.indicators(Pattern);
            DataWidth = api.datawidth(Pattern);
            DataType = api.datatype(Pattern);
            MinSize = api.minsize(Pattern);
            SegWidths = api.segwidths(Pattern);
            Segments = api.segments(Pattern);
            Descriptor = api.descriptor(Pattern);
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

        public static BitPatternInfo Empty => new BitPatternInfo(BitPattern.Empty);

        public class Segment
        {
            public NativeSize SourceSize {get;}

            public string Indicator {get;}

            public string Identifier {get;}

            public byte MinIndex {get;}

            public byte MaxIndex {get;}

            public byte DataWidth {get;}

            public BitMask Mask {get;}

            [MethodImpl(Inline)]
            public Segment(NativeSize srcsize, BitMask mask, string indicator, byte min, byte max)
            {
                SourceSize = srcsize;
                Mask = mask;
                Indicator = indicator;
                Identifier = EmptyString;
                MinIndex = min;
                MaxIndex = max;
                DataWidth = bits.segwidth(MinIndex,MaxIndex);
            }

            [MethodImpl(Inline)]
            public Segment(NativeSize srcsize, BitMask mask, string indicator, byte min, byte max, string identifier)
            {
                SourceSize = srcsize;
                Mask = mask;
                Indicator = indicator;
                Identifier = identifier;
                MinIndex = min;
                MaxIndex = max;
                DataWidth = bits.segwidth(MinIndex,MaxIndex);
            }

            public string Format()
                => Indicator;

            public override string ToString()
                => Format();
        }
    }
}