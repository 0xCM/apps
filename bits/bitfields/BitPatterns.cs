//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct BitPatterns
    {
        public static Char5Seq seg<S>(in S src, byte offset)
            where S : struct, IAsciSeq<S>
        {
            var storage = 0ul;
            var dst = recover<Char5>(bytes(storage));
            var data = slice(recover<AsciSymbol>(src.View), offset);
            var count = min(Char5Seq.MaxLength, data.Length);
            var counter = z8;
            for(var i=z8; i<count; i++)
            {
                ref readonly var c = ref skip(data,i);
                if(c != Chars.Space)
                    dst[counter++] = (char)c;
                else
                    break;

            }
            return new Char5Seq(slice(dst,0,counter));
        }

        public static string name(string src)
            => text.replace(src, Chars.Space, Chars.Underscore);

        public static BitPattern infer(BfOrigin origin, string src)
            => new BitPattern(origin, src);

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

        public static Index<BitMask> masks(BitPattern src)
        {
            var size = BitPatterns.minsize(src.Content);
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
            => text.intersperse(segments(src).Reverse().Select(x => x.Format()), Chars.Space);
    }
}