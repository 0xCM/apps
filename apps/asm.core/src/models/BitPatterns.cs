//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static BitPattern;
    using static Root;

    public readonly struct BitPatterns
    {
        public static string name(BitPattern src)
            => text.replace(src.Content, Chars.Space, Chars.Underscore);

        public static BitPattern define(string content)
            => new BitPattern(content);

        public static BitPattern define(string content, string[] identifiers)
            => new BitPattern(content, identifiers);

        public static Index<string> indicators(BitPattern src)
            => text.split(src.Content, Chars.Space).Reverse();

        public static Index<Segment> segments(BitPattern src)
        {
            var _indicators = indicators(src);
            var count = _indicators.Length;
            var buffer = alloc<Segment>(count);
            var identifiers = src.Identifiers;
            var useids = identifiers.IsNonEmpty;
            var offset = z8;
            var size = src.MinSize;
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var indicator = ref _indicators[i];
                var width = (byte)indicator.Length;
                var min = offset;
                var max = (byte)(width + offset - 1);
                if(useids)
                    dst = new Segment(size, indicator, min, max, identifiers[i]);
                else
                    dst = new Segment(size, indicator, min, max);

                offset += width;
            }
            return buffer;
        }

        [MethodImpl(Inline)]
        public static ref BitMask invert(ref BitMask src)
        {
            src.Value = ~src.Value;
            return ref src;
        }

        public static string format(BitMask src)
        {
            if(src.Width <=8)
                return ((byte)src.Value).FormatBits();
            else if(src.Width <=16)
                return ((ushort)src.Value).FormatBits();
            else if(src.Width <=32)
                return ((uint)src.Value).FormatBits();
            else
                return ((ulong)src.Value).FormatBits();
        }

        public static Index<BitMask> masks(BitPattern src)
        {
            var size = minsize(src);
            var segs = src.Segments();
            var count = segs.Length;
            var dst = alloc<BitMask>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = mask(size,segs[i]);
            return dst;
        }

        [MethodImpl(Inline)]
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

        public static BitMask mask(NativeSize size, Segment src)
            => size.Code switch{
                NativeSizeCode.W8 => mask(w8, src),
                NativeSizeCode.W16 => mask(w16, src),
                NativeSizeCode.W32 => mask(w32, src),
                NativeSizeCode.W64 => mask(w64, src),
                _ => BitMask.Empty
            };

        [MethodImpl(Inline)]
        public static BitMask mask(W8 w, Segment seg)
            => new BitMask((byte)w, bits.enable(w, (byte)seg.MinIndex, (byte)seg.MaxIndex));

        [MethodImpl(Inline)]
        public static BitMask mask(W16 w, Segment seg)
            => new BitMask((byte)w, bits.enable(w, (byte)seg.MinIndex, (byte)seg.MaxIndex));

        [MethodImpl(Inline)]
        public static BitMask mask(W32 w, Segment seg)
            => new BitMask((byte)w, bits.enable(w, (byte)seg.MinIndex, (byte)seg.MaxIndex));

        [MethodImpl(Inline)]
        public static BitMask mask(W64 w, Segment seg)
            => new BitMask((byte)w, bits.enable(w, (byte)seg.MinIndex, (byte)seg.MaxIndex));

        [MethodImpl(Inline)]
        public static byte segwidth(uint i0, uint i1)
            => (byte)(i1 - i0 + 1);

        public static BitfieldMember member(NativeSize size, Segment src)
            => new BitfieldMember(text.ifempty(src.Identifier, src.Indicator), src.MinIndex, src.MaxIndex, mask(size,src));

        public static Index<BitfieldMember> members(BitPattern src)
            => segments(src).Select(s => member(minsize(src), s));

        public static Index<byte> segwidths(BitPattern src)
        {
            var fields = indicators(src);
            var count = fields.Length;
            var buffer = alloc<byte>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = (byte)skip(fields,i).Length;
            return buffer;
        }

        public static byte datawidth(BitPattern src)
            => (byte)text.remove(src.Content, Chars.Space).Length;

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
            => string.Format("{0}:{1} := {2}",
                    src.Name, src.DataType.DisplayName(), text.intersperse(src.BitfieldMembers().Reverse().Select(x => x.Format()), Chars.Space));
    }
}