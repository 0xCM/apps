//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct BitPatterns
    {
        [MethodImpl(Inline)]
        public static BpCalcs calcs(in BpDef def)
            => new (def);

        public static Index<BpCalcs> calcs(ReadOnlySpan<BpInfo> src)
            => src.Map(p => calcs(p.Def));

        public static string bitstring(in BpDef src, ulong value)
        {
            var segments = segs(src.Content);
            var count = segments.Count;
            Span<char> buffer = stackalloc char[src.Content.Length];
            var j=0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var seg = ref segments[i];
                var bits = math.srl(seg.Mask.Apply(value), (byte)seg.MinPos);
                BitRender.render((ushort)bits, ref j, seg.Width, buffer);
                seek(buffer, j++) = Chars.Space;
            }
            return new string(buffer);
        }

        public static Index<BpSeg> segs(ReadOnlySpan<BpInfo> src)
        {
            var count = 0u;
            var counter = 0u;
            iter(src, x => count += x.Segs.Count);
            var dst = alloc<BpSeg>(count);
            var j=0u;
            for(var i=0; i<src.Length; i++)
                segs(skip(src,i), ref j, dst);
            return dst.Sort();
        }

        public static uint segs(BpInfo src, ref uint j, Span<BpSeg> dst)
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
        public static Index<BfSegModel> segs(in asci64 src)
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
                dst = PolyBits.seg(name, min, max, BitMask.mask(size, min, max));
                offset += width;
            }
            return buffer;
        }

        public static Index<byte> segwidths(in BitPattern src)
        {
            var fields = indicators(src);
            var count = fields.Length;
            var buffer = alloc<byte>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = (byte)fields[i].Length;
            return buffer;
        }

        public static Index<string> indicators(in BitPattern src)
            => text.split(src.Data, Chars.Space).Reverse();

        [MethodImpl(Inline)]
        public static BpDef def(BfOrigin origin, in asci32 name, in asci64 content)
            => new BpDef(origin, name, content);

        public static Index<BpDef> defs(ReadOnlySpan<BpInfo> src)
        {
            var count = src.Length;
            var dst = alloc<BpDef>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i).Def;
            return dst;
        }

        public static byte datawidth(in BitPattern src)
            => (byte)text.remove(src.Data, Chars.Space).Length;

        public static Type datatype(in BitPattern src)
        {
            var w = datawidth(src);
            var dst = typeof(void);
            if(w <= 8)
                dst = typeof(byte);
            else if(w <= 16)
                dst = typeof(ushort);
            else if(w <= 32)
                dst = typeof(uint);
            else if(w <= 64)
                dst = typeof(ulong);
            else if(w <= 128)
                dst = typeof(BitVector128<ulong>);
            else
                Throw.message("Width unsupported");
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static BpSpec spec(in BpInfo src)
        {
            var dst = BpSpec.Empty;
            dst.Origin = src.Origin.Format();
            dst.Content = src.Content;
            dst.DataType = src.DataType.DisplayName();
            dst.Descriptor = src.Descriptor;
            dst.MinSize = src.MinSize;
            dst.Name = src.Name;
            dst.DataWidth = src.DataWidth;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static NativeSize minsize(in BitPattern src)
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
        public static BpInfo pattern<O>(in asci32 name, in asci64 data)
            => pattern(PolyBits.origin<O>(), name, data);

        public static BpInfo pattern(BfOrigin origin, in asci32 name, in asci64 content)
        {
            return new BpInfo(
                def(origin, name, content),
                datawidth(content),
                datatype(content),
                minsize(content),
                segs(content),
                descriptor(content)
            );
        }

        public static string descriptor(in BitPattern src)
            => text.intersperse(segs(src).Reverse().Select(x => x.Format()), Chars.Space);

        public static Index<BpInfo> reflected(Type src)
        {
            var target = typeof(BpInfo);
            var props = src.Properties().Ignore().Static().WithPropertyType(target).Index();
            var fields = src.Fields().Ignore().Static().Where(x => x.FieldType == target).Index();
            var methods = src.Methods().Ignore().Public().WithArity(0).Returns(target).Index();
            var count = props.Count + fields.Count + methods.Count;
            Index<BpInfo> dst = alloc<BpInfo>(count);
            var k=0u;
            for(var i=0; i<props.Count; i++, k++)
                dst[k] = (BpInfo)props[i].GetValue(null);

            for(var i=0; i<fields.Count; i++, k++)
                dst[k] = (BpInfo)fields[i].GetValue(null);

            for(var i=0; i<methods.Count; i++, k++)
                dst[k] = (BpInfo)methods[i].Invoke(null, new object[]{});
            return dst;
        }
    }
}