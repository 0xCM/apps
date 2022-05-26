//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public partial class PolyBits : AppService<PolyBits>
    {
        const NumericKind Closure = UInt64k;

        public ByteSpanSpec GenBits(W8 w, byte start = 0, byte end = byte.MaxValue)
        {
            var blocks = BitBlocks(w,start,end).View;
            var count = blocks.Length;
            var buffer = alloc<ByteSpanSpec>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                var b = @bytes(block.Data);
                seek(dst,i) = SpanRes.specify(string.Format("Block{0:X2}", i), b.ToArray());
            }
            var merge = SpanRes.merge("CharBytes", buffer);
            var seg = merge.Segment(16,16);
            var chars = recover<char>(seg);
            return merge;
        }

        public Index<CharBlock8> BitBlocks(W8 w, byte start = 0, byte end = byte.MaxValue)
        {
            var count = end - start + 1;
            var buffer = alloc<CharBlock8>(count);
            ref var dst = ref first(buffer);
            var k = 0;
            for(uint i=start; i<=end; i++, k++)
            {
                var block = CharBlocks.alloc(n8);
                var data = block.Data;
                for(var j=0; j<8; j++)
                    seek(data,j) = bit.test(i,(byte)j).ToChar();
                block.Data.Invert();
                seek(dst,k) = block;
            }

            return buffer;
        }

        public Index<CharBlock16> BitBlocks(W16 w, ushort start = 0, ushort end = ushort.MaxValue)
        {
            var count = end - start + 1;
            var buffer = alloc<CharBlock16>(count);
            ref var dst = ref first(buffer);
            var k = 0;
            for(uint i=start; i<=end; i++, k++)
            {
                var block = CharBlocks.alloc(n16);
                var data = block.Data;
                for(var j=0; j<16; j++)
                    seek(data,j) = bit.test(i,(byte)j).ToChar();
                block.Data.Invert();
                seek(dst,k) = block;
            }

            return buffer;
        }
        /// <summary>
        /// Allocates and populates a character span, comprising each value covered by an <typeparamref name='N'>-bit number, expressed as a bitstring of length <typeparamref name='N'>
        /// </summary>
        /// <param name="n">The natural bit width</param>
        /// <typeparam name="N">The natural with type</typeparam>
        public static Span<char> bitstrings<N>(N n)
            where N : unmanaged, ITypeNat
        {
            var width = (uint)n.NatValue;
            var count = Numbers.count(n);
            var buffer = span<char>(count*width);
            for(var i=0; i<count; i++)
            {
                ref var c = ref seek(buffer,i*width);
                for(byte j=0; j<width; j++)
                    seek(c,width-1-j) = bit.test(i,(byte)j).ToChar();
            }
            return buffer;
        }

        const string DbScope = "polybits";

        AppSvcOps AppSvc => Service(Wf.AppSvc);

        AppDb AppDb => Service(Wf.AppDb);

        DbTargets Targets => AppDb.Targets().Targets(DbScope);

        public void Check()
        {
            Targets.Delete();
            BitCheckers.run(Wf);
            var n = n8;
            var count = Numbers.count(n);
            var convert = BitConverters.converter(n);
            for(var i=0; i<count; i++)
            {
                ref readonly var hex = ref convert.Chars(base16, (ushort)i);
                ref readonly var bin = ref convert.Chars(base2, (ushort)i);
            }

            PbChecks.create(Wf).Run();
        }

        public Index<BfModel> BvEmit(DbSources sources, string filter, FS.FolderPath dst)
            => BvEmit(PolyBits.bitvectors(sources, filter), dst);

        public Index<BfModel> BvEmit(Index<BfModel> src, FS.FolderPath dst)
        {
            dst.Clear();
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var bv = ref src[i];
                ref readonly var name = ref bv.Name;
                var target = dst + FS.file(name.Format(), FS.ext("bv"));
                var msg = string.Format("{0} -> {1}", bv.Origin, target.ToUri());
                AppSvc.FileEmit(bv, msg, target);
            }
            return src;
        }

        public void EmitPatterns(string label, Type src)
        {
            var name = label + ".bits.patterns.info";
            var patterns = BitPatterns.reflected(src);
            EmitDescriptions(name, patterns);
            EmitRecords(label, patterns);
        }

        public void EmitDescriptions(string name, ReadOnlySpan<BpInfo> src)
        {
            var dst = text.emitter();
            for(var i=0u; i<src.Length; i++)
                PbRender.render(skip(src,i), i, dst);
            AppSvc.FileEmit(dst.Emit(), 12, Targets.Path(name, FileKind.Txt));
        }

        public void EmitRecords(string name, ReadOnlySpan<BpInfo> src)
        {
            var count = src.Length;
            var specs = alloc<BpSpec>(count);
            var segs = BitPatterns.segs(src);
            for(var i=0; i<src.Length; i++)
                seek(specs,i) = skip(src,i).Spec;
            AppSvc.TableEmit(segs, Targets.Table<BpSeg>(name));
            AppSvc.TableEmit(specs, Targets.Table<BpSpec>(name));
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
    }
}