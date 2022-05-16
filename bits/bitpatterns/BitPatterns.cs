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
        [MethodImpl(Inline)]
        public static BitPatternCalcs calcs(in BitPatternDef def)
            => new (def);

        public static Index<BitPatternCalcs> calcs(ReadOnlySpan<BitPattern> src)
            => src.Map(p => calcs(p.Def));

        public static uint segs(BitPattern src, ref uint j, Span<BitPatternSeg> dst)
        {
            var i0 = j;
            for(var i=0u; i<src.Segs.Count; i++, j++)
            {
                ref var seg = ref seek(dst,j);
                ref readonly var model = ref src.Segs[i];
                seg.Pattern = src.Name;
                seg.Name = model.SegName;
                seg.Index = i;
                seg.MinPos = model.MinPos;
                seg.MaxPos = model.MaxPos;
                seg.Width = model.Width;
                seg.Expr = model.Format();
                seg.Mask = model.Mask;
            }
            return j - i0;
        }

        public static Index<BitPatternSeg> segs(ReadOnlySpan<BitPattern> src)
        {
            var count = 0u;
            var counter = 0u;
            iter(src, x => count += x.Segs.Count);
            var dst = alloc<BitPatternSeg>(count);
            var j=0u;
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var pattern = ref skip(src,i);
                segs(pattern, ref j, dst);
            }
            return dst.Sort();
        }

        [MethodImpl(Inline)]
        public static BitPatternSpec spec(BitPattern src)
        {
            var dst = BitPatternSpec.Empty;
            dst.Origin = src.Origin.Format();
            dst.Content = src.Content;
            dst.DataType = src.DataType.DisplayName();
            dst.Descriptor = src.Descriptor;
            dst.MinSize = src.MinSize;
            dst.Name = src.Name;
            dst.DataWidth = src.DataWidth;
            return dst;
        }

        public static Index<string> gridlines(ReadOnlySpan<byte> src, int rowlen, int? maxbits, bool showrow)
        {
            const byte Pad = 3;
            const string Sep = " | ";
            const char Delimit = Chars.Space;
            var limit = maxbits ?? src.Length;
            var remainder = limit%rowlen;
            var bits = BitRender.render8x8(src);
            var count = (limit/rowlen) + (remainder == 0 ? 0 : 1);
            var buffer = alloc<string>(count);
            var rowidx = 0;
            var k=0u;
            for(int i=0; i<limit; i+=rowlen, k++)
            {
                var remains = bits.Length - i;
                var seglen = min(remains, rowlen);
                var row = slice(bits.View, i, seglen);
                if(showrow)
                    seek(buffer, k) = text.concat($"{rowidx.ToString().PadRight(Pad)}{Sep}", text.format(row.Intersperse(Delimit)));
                else
                    seek(buffer, k) = text.format(row.Intersperse(Delimit));
                rowidx++;
            }

            if(remainder != 0)
            {
                var remains = bits.Length - remainder;
                var seglen = remains;
                var row = slice(bits.View, seglen, remains);
                if(showrow)
                    seek(buffer, k) = text.concat($"{rowidx.ToString().PadRight(Pad)}{Sep}", text.format(row.Intersperse(Delimit)));
                else
                    seek(buffer, k) = text.format(row.Intersperse(Delimit));
            }
            return buffer;
        }

        public static BitPattern originate<O>(in asci32 name, in asci64 data)
            => infer(Bitfields.origin<O>(), name, data);

        public static string bitstring(in BitPatternDef src, ulong value)
        {
            var segs = segments(src.Content);
            var count = segs.Count;
            Span<char> buffer = stackalloc char[src.Content.Length];
            var j=0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var seg = ref segs[i];
                var bits = math.srl(seg.Mask.Apply(value), (byte)seg.MinPos);
                BitRender.render((ushort)bits, ref j, seg.Width, buffer);
                seek(buffer, j++) = Chars.Space;
            }
            return new string(buffer);
        }

        [MethodImpl(Inline)]
        public static BitPatternDef def(BfOrigin origin, in asci32 name, in asci64 content)
            => new BitPatternDef(origin, name, content);

        public static Index<BitPatternDef> defs(ReadOnlySpan<BitPattern> src)
        {
            var count = src.Length;
            var dst = alloc<BitPatternDef>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i).Def;
            return dst;
        }

        public static Index<BitPattern> originated(Type src)
        {
            var target = typeof(BitPattern);
            var props = src.Properties().Ignore().Static().WithPropertyType(target).Index();
            var fields = src.Fields().Ignore().Static().Where(x => x.FieldType == target).Index();
            var methods = src.Methods().Ignore().Public().WithArity(0).Returns(target).Index();
            var count = props.Count + fields.Count + methods.Count;
            Index<BitPattern> dst = alloc<BitPattern>(count);
            var k=0u;
            for(var i=0; i<props.Count; i++, k++)
                dst[k] = (BitPattern)props[i].GetValue(null);

            for(var i=0; i<fields.Count; i++, k++)
                dst[k] = (BitPattern)fields[i].GetValue(null);

            for(var i=0; i<methods.Count; i++, k++)
                dst[k] = (BitPattern)methods[i].Invoke(null, new object[]{});
            return dst;
        }

        public static BitPattern infer(BfOrigin origin, in asci32 name, in asci64 content)
        {
            return new BitPattern(
                def(origin, name, content),
                datawidth(content),
                datatype(content),
                minsize(content),
                segments(content),
                descriptor(content)
            );
        }

        public static Index<string> indicators(in asci64 src)
            => text.split(src, Chars.Space).Reverse();

        public static Index<BfSegModel> segments(in asci64 src)
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
        public static NativeSize minsize(in asci64 src)
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

        public static Index<byte> segwidths(in asci64 src)
        {
            var fields = indicators(src);
            var count = fields.Length;
            var buffer = alloc<byte>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = (byte)fields[i].Length;
            return buffer;
        }

        public static byte datawidth(in asci64 src)
            => (byte)text.remove(src, Chars.Space).Length;

        public static Type datatype(in asci64 src)
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

        public static string descriptor(in asci64 src)
            => text.intersperse(segments(src).Reverse().Select(x => x.Format()), Chars.Space);
    }
}