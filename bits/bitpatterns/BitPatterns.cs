//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics;
    using static core;


    [ApiHost]
    public readonly struct BitPatterns
    {
        public static BitPattern infer(BfOrigin origin, string src)
        {
            var content = text.despace(src);
            return new BitPattern(
                origin,
                content,
                name(content),
                datawidth(content),
                datatype(content),
                minsize(content),
                segments(content),
                descriptor(content)
            );
        }

        public static BitPattern originate(string src)
            => BitPatterns.infer(Bitfields.origin(new StackTrace().GetFrame(1).GetMethod().DeclaringType), src);

        public static Index<BitPattern> patterns(BfOrigin origin, ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var dst = alloc<BitPattern>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = infer(origin, skip(src,i));
            return dst;
        }

        public static string bitstring(BitPattern pattern, byte data)
        {
            var segs = pattern.Segments.Reverse();
            var count = segs.Count;
            Span<char> buffer = stackalloc char[pattern.Content.Length];
            var j=0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var seg = ref segs[i];
                var mask = seg.Mask;
                var width = seg.Width;
                var bits = math.srl(seg.Mask.Apply(data), (byte)seg.Offset);
                BitRender.render(bits, ref j, width, buffer);
                seek(buffer, j++) = Chars.Space;
            }
            return new string(buffer);
        }


        public static string name(string src)
            => text.replace(src, Chars.Space, Chars.Underscore);

        public static BitPattern concat(BitPattern a, BitPattern b)
            => infer(a.Origin, string.Format("{0} {1}", a.Content, b.Content));

        public static Index<string> indicators(string src)
            => text.split(src, Chars.Space).Reverse();

        public static Index<BfSegModel> segments(string src)
        {
            var names = indicators(src);
            var count = names.Length;
            var buffer = alloc<BfSegModel>(count);
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
            else if(width <= 128)
                return NativeSizeCode.W128;
            else
                Throw.message("Width unsupported");

            return default;
        }

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
            else if(width <= 128)
                dst = typeof(BitVector128<ulong>);
            else
                Throw.message("Width unsupported");

            return dst;
        }

        public static string descriptor(string src)
            => text.intersperse(segments(src).Reverse().Select(x => x.Format()), Chars.Space);
    }
}