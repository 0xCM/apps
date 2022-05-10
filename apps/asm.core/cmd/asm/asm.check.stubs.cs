//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;

    using static Asm.AsmChecks;

    using K = Asm.AsmOcTokenKind;
    using P = Pow2x32;

    partial class AsmCoreCmd
    {
       static ReadOnlySpan<byte> x7ffaa76f0ae0
            => new byte[32]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xd1,0x48,0xb9,0x50,0x0f,0x24,0xa5,0xfa,0x7f,0x00,0x00,0x48,0xb8,0x30,0xdd,0x99,0xa6,0xfa,0x7f,0x00,0x00,0x48,0xff,0xe0,0};

        [CmdOp("check/vfind")]
        Outcome CheckV(CmdArgs args)
        {
            const byte count = 32;
            const byte Target = 0x48;
            var input = cpu.vload(w256,x7ffaa76f0ae0);
            var mask = cpu.vindices(input, Target);
            var bits = recover<bit>(Cells.alloc(w256).Bytes);
            BitPack.unpack1x32x8(mask, bits);
            var buffer = ByteBlock32.Empty;
            var j=z8;
            for(byte i=0; i<count; i++)
            {
                if(skip(bits,i))
                    buffer[j++] = i;
            }

            var indices = slice(buffer.Bytes, 0, j);
            Require.equal(skip(indices,0), 5);
            Require.equal(skip(indices,1), 8);
            Require.equal(skip(indices,2), 18);
            Require.equal(skip(indices,3), 28);
            return true;
        }

        [CmdOp("check/seq/prod")]
        Outcome SeqProd(CmdArgs args)
        {
            var a = Intervals.closed(2u, 12u).Partition();
            var b = Intervals.closed(33u, 41u).Partition();
            var c = SeqProducts.mul(a,b);
            Write(SeqProducts.format(c));

            return true;
        }

        [CmdOp("check/sigs")]
        Outcome CheckSigs(CmdArgs args)
        {
            using var dispenser = Alloc.allocate();
            var specs = new NativeOperandSpec[3];
            seek(specs,0) = NativeSigs.ptr("op0", NativeTypes.u8());
            seek(specs,1) = NativeSigs.@const("op1", NativeTypes.i16());
            seek(specs,2) = NativeSigs.@out("op2", NativeTypes.u32());
            var sig = dispenser.Sig("funcs","f2", NativeTypes.i32(), specs);
            Write(sig.Format(SigFormatStyle.C));

            var intrinsics = new IntrinsicSigs();

            var f0 = intrinsics._mm_add_epi8();
            Write(f0.Format(SigFormatStyle.C));

            var f0x = dispenser.Sig(f0);
            Write(f0x.Format(SigFormatStyle.C));

            var f1 = intrinsics._mm_add_epi16();
            Write(f1.Format(SigFormatStyle.C));

            var f1x = dispenser.Sig(f1);
            Write(f1x.Format(SigFormatStyle.C));

            var f2 = intrinsics._mm_add_epi32();
            Write(f2.Format(SigFormatStyle.C));

            var f2x = dispenser.Sig(f2);
            Write(f2x.Format(SigFormatStyle.C));

            var f3 = intrinsics._mm_add_epi64();
            Write(f3.Format(SigFormatStyle.C));

            var f3x = dispenser.Sig(f3);
            Write(f3x.Format(SigFormatStyle.C));


            return true;
        }


        [CmdOp("check/strings/buffers")]
        Outcome CheckStringBuffers(CmdArgs args)
        {
            var result = Outcome.Success;

            result = CheckStringAllocator();
            if(result.Fail)
                return result;
            else
                Status(result.Message);

            result = CheckLabelAllocator();
            if(result.Fail)
                return result;
            else
                Status(result.Message);


            return result;
        }

        Outcome CheckStringAllocator()
        {
            var result = Outcome.Success;
            var count = Pow2.T16;
            var inputlen = Pow2.T04;
            var totallen = count*inputlen;
            var size = totallen*core.size<char>();
            using var dispenser = Alloc.strings(size);
            var strings = core.alloc<StringRef>(count);
            for(var i=0; i<count; i++)
            {
                var input = BitRender.format16((ushort)i);
                ref var @string = ref seek(strings,i);
                @string = dispenser.String(input);
                if(!input.Equals(@string.Format()))
                {
                    result = (false, string.Format("input:{0} != output:{1}", input, @string.Format()));
                    break;
                }
            }
            if(result)
                result = (true, string.Format("Verified string allocator for {0} inputs over a buffer of size {1}", count, size));

            return result;
        }

        Outcome CheckLabelAllocator()
        {
            var count = 256;
            var result = Outcome.Success;
            var src = alloc<string>(count);
            for(uint i=0; i<count; i++)
                seek(src,i) = BitRender.format8((byte)i);

            using var allocation = Alloc.labels(src);
            var labels = allocation.Allocated;
            if(labels.Length != count)
                result = (false, string.Format("{0} != {1}", labels.Length, count));
            else
            {
                for(var i=0; i<count; i++)
                {
                    ref readonly var label = ref skip(labels,i);
                    ref readonly var input = ref skip(src,i);
                    var same = label.Format() == input;
                    if(!same)
                    {
                        result = (false, string.Format("{0} != {1}", label, input));
                        break;
                    }
                }
            }
            if(result)
                result = (true, string.Format("Verified {0} label allocations", count));

            return result;
        }

        [CmdOp("check/sym/stores")]
        Outcome CheckSymStores(CmdArgs args)
        {
            var store = SymbolStores.symstore<string>(24);
            store.Deposit("abc", out var s1);
            Write(s1);
            store.Deposit("def", out var s2);
            Write(s2);
            store.Deposit("hij", out var s3);
            Write(s3);
            store.Deposit("klm", out var s4);
            Write(s4);
            store.Deposit("nop", out var s5);
            Write(s5);

            var e1 = store.Find(s1);
            var e2 = store.Find(s2);
            var e3 = store.Find(s3);
            var e4 = store.Find(s4);
            var e5 = store.Find(s5);
            Write(e1 + e2 + e3 + e4 + e5);
            return true;
        }

        [CmdOp("check/sorters")]
        Outcome RunSorters(CmdArgs args)
        {
            var result = Outcome.Success;
            var sorter = SortingNetworks.define<byte>();
            byte x0 = 9, x1 = 5, x2 = 2, x3 = 6;
            sorter.Send(x0, x1, x2, x3, out var y0, out var y1, out var y2, out var y3);
            Write(string.Format("{0} -> {1}", x0, y0));
            Write(string.Format("{0} -> {1}", x1, y1));
            Write(string.Format("{0} -> {1}", x2, y2));
            Write(string.Format("{0} -> {1}", x3, y3));
            return result;
        }

        void CheckSig1()
        {
            using var dispenser = Alloc.allocate();
            var specs = new NativeOperandSpec[3];
            seek(specs,0) = NativeSigs.op("op0", NativeTypes.u8());
            seek(specs,1) = NativeSigs.op("op1", NativeTypes.i16());
            seek(specs,2) = NativeSigs.op("op2", NativeTypes.u32());
            var sig = dispenser.Sig("funcs","f1", NativeTypes.i32(), specs);

            ref readonly var ret = ref sig.Return;
            ref readonly var op0 = ref sig[0];
            ref readonly var op1 = ref sig[1];
            ref readonly var op2 = ref sig[2];
            ref readonly var name = ref sig.Name;
            ref readonly var scope = ref sig.Scope;

            var x0 = string.Format("{0}:{1}", op0.Name, op0.Type);
            var x1 = string.Format("{0}:{1}", op1.Name, op1.Type);
            var x2 = string.Format("{0}:{1}", op2.Name, op2.Type);
            var result = ret.Type.Format();
            var sigfmt = string.Format("{0}::{1}:{2} -> {3} -> {4} -> {5}", scope, name, x0, x1,x2, result);
            Write(sigfmt);
        }

        [Op]
        public static uint serialize(PointMapper<K,P> src, Span<ushort> dst)
        {
            var points = src.Points;
            var count = points.Length;
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var point = ref seek(points,i);
                ref var t0 = ref @as<byte>(seek(dst,i));
                ref var t1 = ref @as<Log2x32>(seek(t0,1));
                t0 = u8(point.Left);
                t1 = Pow2.log(point.Right);
            }

            return 0;
        }

        public static Index<ushort> serialize(PointMapper<K,P> src)
        {
            var dst = alloc<ushort>(src.PointCount);
            serialize(src,dst);
            return dst;
        }

        [CmdOp("check/asm/widths")]
        Outcome TestAsmWidths(CmdArgs args)
        {
            var result = bit.On;
            var pass = bit.Off;
            var test = default(AsmSizeCheck);
            var inputs = Symbols.index<NativeSizeCode>().Kinds;
            var count = inputs.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(inputs,i);
                test.Input = input;
                pass = check(ref test);
                result &= pass;
                Write(test, pass ? FlairKind.Status : FlairKind.Error);
            }

            BitWidth w8 = 8;
            BitWidth w16 = 16;
            BitWidth w32 = 32;
            BitWidth w64 = 64;

            var sz8 = Sizes.native(w8);
            var sz16 = Sizes.native(w16);
            var sz32 = Sizes.native(w32);
            var sz64 = Sizes.native(w64);
            Write(sz8);
            Write(sz16);
            Write(sz32);
            Write(sz64);

            return (result, result ? "Pass" : "Fail");
        }

        [CmdOp("asm/check/stubs")]
        Outcome CheckStubDispatch(CmdArgs args)
        {
            var stubs = Jumps;
            if(stubs.Create<ulong>(0))
                Write(stubs.EncodeDispatch(0).FormatHexData());
            return true;
        }

        [CmdOp("check/native/types")]
        Outcome CheckNativeTypes(CmdArgs args)
        {
            var t0 = NativeTypes.seg(NativeSegKind.Seg128x16i);
            Write(t0.Format());

            var t1 = NativeTypes.seg(NativeSegKind.Seg16u);
            Write(t1.Format());
            return true;
        }

        public class TableInfo
        {
            public ulong Count;

            public uint M;

            public uint N;
        }

        [CmdOp("check/block/size")]
        Outcome CheckBlockSize(CmdArgs args)
        {
            ByteBlock4 block4 = 0xFF000000;
            Write(Storage.trim(block4).Format());


            ByteBlock4 block3 = 0xFF0000;
            Write(Storage.trim(block3).Format());

            ByteBlock4 block2 =  0xFF00;
            Write(Storage.trim(block2).Format());

            ByteBlock4 block1 =  0xFF;
            Write(Storage.trim(block1).Format());

            ByteBlock4 block0 =  0x0;
            Write(Storage.trim(block0).Format());
            return true;
        }

        [CmdOp("check/md/arrays")]
        unsafe Outcome CheckMdArrays(CmdArgs args)
        {
            var m = 0xF;
            var n = 0xA;
            var data = new ulong[m,n];
            for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                data[i,j] = (ulong)(i*j);


            fixed(ulong* pSrc = data)
            {
                MemoryAddress @base = pSrc;
                var pCurrent = pSrc;
                for(var i=0; i<m; i++)
                {
                    for(var j=0; j<n; j++)
                    {
                        MemoryAddress loc = pCurrent;
                        var a = *pCurrent++;
                        Require.equal(a, (ulong)(i*j));
                        Write(string.Format("{0} {1} {2}x{3}={4}", loc, loc - @base, i, j, a));
                    }
                }
            }

            var dst = Unsafe.As<TableInfo>(data);
            Write(string.Format("{0}={1}x{2}", dst.Count, dst.M, dst.N));

            return true;
        }

        Parsers Parsers => Service(Wf.Parsers);

        [CmdOp("check/api/parsers")]
        Outcome CheckApiParsers(CmdArgs args)
        {
            var x = 32u;
            if(Parsers.Parse(x.ToString(), out uint dst))
            {
                Require.equal(x,dst);
            }
            return true;
        }

        [CmdOp("check/bitfields")]
        Outcome CheckBitFields(CmdArgs args)
        {
            var storage = ByteBlock32.Empty;
            var buffer = storage.Bytes;
            byte segwidth = 8;
            ReadOnlySpan<byte> indices = new byte[]{3,33,59,61,101,203};
            gbits.enable(buffer, indices);
            var segcount = buffer.Length;
            for(var i=z8; i<segcount; i++)
            {
                ref readonly var cell = ref skip(buffer,i);
                var offset = (byte)(i*segwidth);
                if(cell != 0)
                {
                    var seg = BitfieldSeg.define(cell, offset, segwidth);
                    Write(seg.Format());
                }
            }

            return true;
        }

        [CmdOp("check/expr/scopes")]
        Outcome TestScopes(CmdArgs args)
        {
            var result = Outcome.Success;

            ExprScope a = "a";

            Require.invariant(a.IsRoot);

            ExprScope b = "b";
            Require.invariant(b.IsRoot);

            var c = a + b;
            Require.equal(c, "a.b");

            var d = ExprScope.root("d");
            var e = c + d;
            Require.equal(e, "a.b.d");

            var fg = ExprScope.root("f") + ExprScope.root("g");
            var h = e + fg;
            Require.equal(h, "a.b.d.f.g");

            return result;
        }

        [CmdOp("check/lookups")]
        Outcome TestKeys(CmdArgs args)
        {
            var outcome = Outcome.Success;
            ushort rows = Pow2.T13;
            ushort cols = Pow2.T13;
            var keys = LookupTables.keys(rows,cols);
            var range = Intervals.closed(z16, (ushort)(rows - 1)).Partition();
            iter(range,i =>{
            for(var j=z16; j<cols; j++)
            {
                ref readonly var key = ref keys[i,j];
                LookupKey expect = (i,j);
                Require.invariant(expect.Equals(key));
            }
            },true);

            Status(string.Format("Verifified {0} lookup operations", rows*cols));

            return true;
        }

        [CmdOp("check/range")]
        Outcome CheckRange(CmdArgs args)
        {
            Span<byte> buffer = stackalloc byte[32];
            var emitter = text.buffer();
            points(new BitRange(0, 2), buffer,emitter);
            Write(emitter.Emit());
            points(new BitRange(5, 3), buffer,emitter);
            Write(emitter.Emit());
            points(new BitRange(6, 7), buffer,emitter);
            Write(emitter.Emit());
            points(new BitRange(1, 4), buffer,emitter);
            Write(emitter.Emit());
            return true;
        }

        static BitRange points(BitRange src, Span<byte> dst, ITextEmitter emitter)
        {
            var count = src.Values(dst,true);
            emitter.Append(src.Format());
            emitter.Append(Chars.LBrace);
            for(var i=0;i<count; i++)
            {
                if(i != 0)
                    emitter.Append(Chars.Comma);
                emitter.Append(skip(dst,i).ToString());
            }
            emitter.Append(Chars.RBrace);
            return src;
        }
    }
}