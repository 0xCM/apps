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

    public readonly struct BitPattern
    {
        public string Content {get;}

        public Index<string> Identifiers {get;}

        public BitPattern(string content)
        {
            Content = text.despace(content);
            Identifiers = sys.empty<string>();
        }

        public BitPattern(string content, string[] identifiers)
        {
            Content = text.despace(content);
            Identifiers = identifiers;
            Require.equal(SegCount, Identifiers.Count);
        }

        public string Name
            => api.name(this);

        public Index<string> Indicators
            => api.indicators(this);

        public byte DataWidth()
            => api.datawidth(this);

        public Index<Segment> Segments()
            => api.segments(this);

        public uint SegCount
        {
            [MethodImpl(Inline)]
            get => Indicators.Count;
        }

        public Type DataType
            => api.datatype(DataWidth());

        public Index<byte> SegWidths()
            => api.segwidths(this);

        public Index<BitfieldMember> BitfieldMembers()
            => api.members(this);

        public NativeSize MinSize
            => api.minsize(this);

        public string Descriptor()
            => api.descriptor(this);

        public string Format()
            => Content;

        public override string ToString()
            => Format();

        public static BitPattern Empty => new BitPattern(EmptyString, sys.empty<string>());

        public readonly struct Segment
        {
            public NativeSize SourceSize {get;}

            public string Indicator {get;}

            public string Identifier {get;}

            public byte MinIndex {get;}

            public byte MaxIndex {get;}

            [MethodImpl(Inline)]
            public Segment(NativeSize srcsize, string indicator, byte min, byte max)
            {
                SourceSize = srcsize;
                Indicator = indicator;
                Identifier = EmptyString;
                MinIndex = min;
                MaxIndex = max;
                Identifier = EmptyString;
            }

            [MethodImpl(Inline)]
            public Segment(NativeSize srcsize, string indicator, byte min, byte max, string identifier)
            {
                SourceSize = srcsize;
                Indicator = indicator;
                Identifier = identifier;
                MinIndex = min;
                MaxIndex = max;
                Identifier = identifier;
            }

            public byte DataWidth
            {
                [MethodImpl(Inline)]
                get => api.segwidth(MinIndex,MaxIndex);
            }

            public BitfieldMember BitfieldMember()
                => api.member(SourceSize, this);

            public string Format()
                => Indicator;

            public override string ToString()
                => Format();
        }
    }
}