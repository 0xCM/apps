//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct BitfieldPatterns
    {
        public class PatternInfo
        {
            /// <summary>
            /// The pattern specification
            /// </summary>
            public BitfieldPattern Pattern {get;}

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

            public Index<PatternSegment> Segments {get;}

            public Index<byte> SegWidths {get;}

            public string Descriptor {get;}

            public PatternInfo(BitfieldPattern pattern)
            {
                Pattern = text.despace(pattern.Text);
                Name = name(Pattern);
                Indicators = indicators(Pattern);
                DataWidth = datawidth(Pattern);
                DataType = datatype(Pattern);
                MinSize = minsize(Pattern);
                SegWidths = segwidths(Pattern);
                Segments = segments(Pattern);
                Descriptor = descriptor(Pattern);
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

            public static PatternInfo Empty => new PatternInfo(BitfieldPattern.Empty);
        }

        public class PatternSegment
        {
            public NativeSize SourceSize {get;}

            public string Indicator {get;}

            public string Identifier {get;}

            public byte MinIndex {get;}

            public byte MaxIndex {get;}

            public byte DataWidth {get;}

            public BitMask Mask {get;}

            [MethodImpl(Inline)]
            public PatternSegment(NativeSize srcsize, BitMask mask, string indicator, byte min, byte max)
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
            public PatternSegment(NativeSize srcsize, BitMask mask, string indicator, byte min, byte max, string identifier)
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

        [Op]
        public static BitfieldPattern infer(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            var counter = 0u;
            AsciSymbol k = AsciCode.a;
            AsciSymbol error = AsciCode.Bang;
            Span<char> buffer = stackalloc char[count];

            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                ref var dst = ref seek(buffer,i);
                if(c == Chars.Space)
                {
                    dst = c;
                    k++;
                }
                else
                {
                    if(c == bit.One || c == bit.Zero)
                        dst = k;
                    else
                        dst = error;
                }
            }

            return new BitfieldPattern(new string(buffer));
        }

        public static string name(BitfieldPattern src)
            => text.replace(src, Chars.Space, Chars.Underscore);

        public static PatternInfo describe(BitfieldPattern src)
            => new PatternInfo(src);

        public static Index<string> indicators(BitfieldPattern src)
            => text.split(src, Chars.Space).Reverse();

        public static Index<PatternSegment> segments(BitfieldPattern src)
        {
            var _indicators = indicators(src);
            var count = _indicators.Length;
            var buffer = alloc<PatternSegment>(count);
            var offset = z8;
            var size = minsize(src);
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var indicator = ref _indicators[i];
                var width = (byte)indicator.Length;
                var min = offset;
                var max = (byte)(width + offset - 1);
                var m = BitMasks.mask(size, min, max);
                dst = new PatternSegment(size, BitMasks.mask(size, min, max), indicator, min, max);
                offset += width;
            }
            return buffer;
        }

        public static Index<PatternSegment> segments(BitfieldPattern src, Index<Identifier> identifiers)
        {
            var _indicators = indicators(src);
            var count = _indicators.Length;
            var buffer = alloc<PatternSegment>(count);
            var offset = z8;
            var size = minsize(src);
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var indicator = ref _indicators[i];
                var width = (byte)indicator.Length;
                var min = offset;
                var max = (byte)(width + offset - 1);
                dst = new PatternSegment(size, BitMasks.mask(size, min, max), indicator, min, max, identifiers[i]);
                offset += width;
            }
            return buffer;
        }

        public static string bitstring(PatternInfo pattern, byte data)
        {
            var segs = pattern.Segments.Reverse();
            var count = segs.Count;
            Span<char> buffer = stackalloc char[pattern.Pattern.Length];
            var j=0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var seg = ref segs[i];
                var mask = seg.Mask;
                var width = seg.DataWidth;
                var bits = math.srl(seg.Mask.Apply(data), seg.MinIndex);
                BitRender.render(bits, ref j, width, buffer);
                seek(buffer, j++) = Chars.Space;
            }
            return new string(buffer);
        }

        public static Index<BitMask> masks(PatternInfo src)
        {
            var size = minsize(src.Pattern);
            var segs = src.Segments;
            var count = segs.Length;
            var dst = alloc<BitMask>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = segs[i].Mask;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static NativeSize minsize(BitfieldPattern src)
        {
            var width = datawidth(src);
            if(width <= 8)
                return NativeSizeCode.W8;
            else if(width <= 16)
                return NativeSizeCode.W16;
            else if(width <= 32)
                return NativeSizeCode.W32;
            else if(width <= 64)
                return NativeSizeCode.W64;
            else
                Throw.message("Width unsupported");

            return default;
        }

        static BitfieldMember member(NativeSize size, PatternSegment src)
            => new BitfieldMember(text.ifempty(src.Identifier, src.Indicator), src.MinIndex, src.MaxIndex, src.Mask);

        static Index<BitfieldMember> members(BitfieldPattern src)
            => BitfieldPatterns.segments(src).Select(s => member(BitfieldPatterns.minsize(src), s));

        public static Index<byte> segwidths(BitfieldPattern src)
        {
            var fields = indicators(src);
            var count = fields.Length;
            var buffer = alloc<byte>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = (byte)fields[i].Length;
            return buffer;
        }

        public static byte datawidth(BitfieldPattern src)
            => (byte)text.remove(src, Chars.Space).Length;

        public static Type datatype(BitfieldPattern src)
            => datatype(datawidth(src));

        [Op]
        public static Type datatype(byte width)
        {
            var dst = typeof(void);
            if(width <= 8)
                dst = typeof(byte);
            else if(width <= 16)
                dst = typeof(ushort);
            else if(width <= 32)
                dst = typeof(uint);
            else if(width <= 64)
                dst = typeof(ulong);
            else
                Throw.message("Width unsupported");

            return dst;
        }

        public static string descriptor(BitfieldPattern src)
            => string.Format("{0}:{1} := {2}", name(src), datatype(src).DisplayName(), text.intersperse(members(src).Reverse().Select(x => x.Format()), Chars.Space));
    }
}