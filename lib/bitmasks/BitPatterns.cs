//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static BitPatternInfo;
    using static Root;

    [ApiHost]
    public readonly struct BitPatterns
    {
        [Op]
        public static BitPattern infer(ReadOnlySpan<char> src)
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

            return new BitPattern(new string(buffer));
        }

        public static string name(BitPattern src)
            => text.replace(src, Chars.Space, Chars.Underscore);

        public static BitPatternInfo describe(BitPattern src)
            => new BitPatternInfo(src);

        public static Index<string> indicators(BitPattern src)
            => text.split(src, Chars.Space).Reverse();

        public static Index<Segment> segments(BitPattern src)
        {
            var _indicators = indicators(src);
            var count = _indicators.Length;
            var buffer = alloc<Segment>(count);
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
                dst = new Segment(size, BitMasks.mask(size, min, max), indicator, min, max);
                offset += width;
            }
            return buffer;
        }

        public static Index<Segment> segments(BitPattern src, Index<Identifier> identifiers)
        {
            var _indicators = indicators(src);
            var count = _indicators.Length;
            var buffer = alloc<Segment>(count);
            var offset = z8;
            var size = minsize(src);
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var indicator = ref _indicators[i];
                var width = (byte)indicator.Length;
                var min = offset;
                var max = (byte)(width + offset - 1);
                dst = new Segment(size, BitMasks.mask(size, min, max), indicator, min, max, identifiers[i]);
                offset += width;
            }
            return buffer;
        }

        public static string bitstring(BitPatternInfo pattern, byte data)
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

        public static Index<BitMask> masks(BitPatternInfo src)
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
        public static NativeSize minsize(BitPattern src)
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

        static BitfieldMember member(NativeSize size, Segment src)
            => new BitfieldMember(text.ifempty(src.Identifier, src.Indicator), src.MinIndex, src.MaxIndex, src.Mask);

        static Index<BitfieldMember> members(BitPattern src)
            => BitPatterns.segments(src).Select(s => member(BitPatterns.minsize(src), s));

        public static Index<byte> segwidths(BitPattern src)
        {
            var fields = indicators(src);
            var count = fields.Length;
            var buffer = alloc<byte>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = (byte)fields[i].Length;
            return buffer;
        }

        public static byte datawidth(BitPattern src)
            => (byte)text.remove(src, Chars.Space).Length;

        public static Type datatype(BitPattern src)
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

        public static string descriptor(BitPattern src)
            => string.Format("{0}:{1} := {2}", name(src), datatype(src).DisplayName(), text.intersperse(members(src).Reverse().Select(x => x.Format()), Chars.Space));
    }
}