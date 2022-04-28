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
        public static string name(string src)
            => text.replace(src, Chars.Space, Chars.Underscore);

        public static BitfieldPattern infer(string src)
            => new BitfieldPattern(src);

        public static Index<string> indicators(string src)
            => text.split(src, Chars.Space).Reverse();

        public static Index<BitfieldSegModel> segments(string src)
        {
            var names = indicators(src);
            var count = names.Length;
            var buffer = alloc<BitfieldSegModel>(count);
            var offset = z8;
            var size = minsize(src);
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var name = ref names[i];
                var width = (byte)name.Length;
                var min = offset;
                var max = (byte)(width + offset - 1);
                dst = Bitfields.segmodel(name, min, max, BitMask.mask(size, min, max));
                offset += width;
            }
            return buffer;
        }

        public static string bitstring(BitfieldPattern pattern, byte data)
        {
            var segs = pattern.Segments.Reverse();
            var count = segs.Count;
            Span<char> buffer = stackalloc char[pattern.Content.Length];
            var j=0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var seg = ref segs[i];
                var mask = seg.Mask;
                var width = seg.SegWidth;
                var bits = math.srl(seg.Mask.Apply(data), seg.MinIndex);
                BitRender.render(bits, ref j, width, buffer);
                seek(buffer, j++) = Chars.Space;
            }
            return new string(buffer);
        }

        public static Index<BitMask> masks(BitfieldPattern src)
        {
            var size = minsize(src.Content);
            var segs = src.Segments;
            var count = segs.Length;
            var dst = alloc<BitMask>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = segs[i].Mask;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static NativeSize minsize(string src)
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

        // public static Index<BitfieldMember> members(string src)
        //     => BitfieldPatterns.segments(src).Select(s => Bitfields.member(BitfieldPatterns.minsize(src), s));

        public static Index<byte> segwidths(string src)
        {
            var fields = indicators(src);
            var count = fields.Length;
            var buffer = alloc<byte>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = (byte)fields[i].Length;
            return buffer;
        }

        public static byte datawidth(string src)
            => (byte)text.remove(src, Chars.Space).Length;

        public static Type datatype(string src)
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

        public static string descriptor(string src)
            => string.Format("{0}:{1} := {2}", name(src), datatype(src).DisplayName(), text.intersperse(segments(src).Reverse().Select(x => x.Format()), Chars.Space));
    }
}