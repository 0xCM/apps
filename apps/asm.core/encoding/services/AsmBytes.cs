//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Operands;

    using static Hex8Kind;
    using static core;

    [ApiHost]
    public class AsmBytes
    {
        [MethodImpl(Inline), Op]
        public static ModRm modrm(byte mod, byte reg, byte rm)
            => new ModRm(join((rm, 0), (reg, 3), (mod, 6)));

        [MethodImpl(Inline), Op]
        public static ModRm modrm(RegIndex reg, RegIndex rm)
            => modrm(0b11, (byte)reg, (byte)rm);

        [MethodImpl(Inline), Op]
        public static ModRm modrm(byte mod, RegIndex reg, RegIndex rm)
            => modrm(mod, (byte)reg, (byte)rm);

        [MethodImpl(Inline), Op]
        public static Sib sib(uint3 @base, uint3 index, uint2 scale)
            => new Sib(join((scale, 0), (index, 2), (@base, 6)));

        public static string bitstring(Sib src)
            => string.Format("{0} {1} {2}", BitRender.format2(src.Scale), BitRender.format3(src.Index), BitRender.format3(src.Base));

        [MethodImpl(Inline), Op]
        static uint sib(Sib src, ref uint i, Span<char> dst)
        {
            const string FieldSep = " | ";
            var i0=i;
            BitRender.render2(src.Scale, ref i, dst);
            text.copy(FieldSep, ref i, dst);

            BitRender.render3(src.Index, ref i, dst);
            text.copy(FieldSep, ref i, dst);

            BitRender.render3(src.Base, ref i, dst);

            text.copy(FieldSep, ref i, dst);

            text.copy(src.Value().FormatHex(2), ref i, dst);
            seek(dst,i++) = Chars.Space;
            text.copy(FieldSep, ref i, dst);

            text.copy(bitstring(src), ref i, dst);

            return i-i0;
        }

        [Op]
        public static uint SibTable(Span<char> dst)
        {
            const string Header = "scale | index | base | hex | bitstring";

            var m=0u;
            text.copy(Header, ref m, dst);
            text.crlf(ref m, dst);

            var f0 = BitSeq.bits(n3);
            var f1 = BitSeq.bits(n3);
            var f2 = BitSeq.bits(n2);

            for(var k=0; k<f2.Length; k++)
            {
                for(var j=0; j<f1.Length; j++)
                {
                    for(var i=0; i<f0.Length; i++)
                    {
                        var b0 = skip(f0, i);
                        var b1 = skip(f1, j);
                        var b2 = skip(f2, k);
                        sib(new Sib(BitNumbers.join(b0,b1,b2)), ref m, dst);
                        text.crlf(ref m, dst);
                    }
                }
            }
            return m;
        }


        public static uint modrm(ModRm src, ref uint i, Span<char> dst)
        {
            const string FieldSep = " | ";
            var i0 = i;
            BitRender.render2(src.Mod(), ref i, dst);
            seek(dst,i++) = Chars.Space;
            text.copy(FieldSep, ref i, dst);

            BitRender.render3(src.Reg(), ref i, dst);
            text.copy(FieldSep, ref i, dst);

            BitRender.render3(src.Rm(), ref i, dst);
            text.copy(FieldSep, ref i, dst);

            text.copy(src.Format(), ref i, dst);
            seek(dst,i++) = Chars.Space;
            text.copy(FieldSep, ref i, dst);

            text.copy(src.ToBitString(), ref i, dst);

            return i - i0;
        }

        [Op]
        public static uint ModRmTable(Span<char> dst)
        {
            const string ModRmHeader = "mod | reg | r/m | hex   | bits";

            var f0 = BitSeq.bits(n3);
            var f1 = BitSeq.bits(n3);
            var f2 = BitSeq.bits(n2);
            var k=0u;
            text.copy(ModRmHeader, ref k, dst);
            text.crlf(ref k, dst);

            for(var c=0u; c<f2.Length; c++)
            for(var b=0u; b<f1.Length; b++)
            for(var a=0u; a<f0.Length; a++)
            {
                modrm(AsmBytes.modrm(skip(f2, c), skip(f1, b), skip(f0, a)), ref k, dst);
                text.crlf(ref k, dst);
            }
            return k;
        }

        public static Index<SibRegCodes> SibRegCodes()
        {
            var count = 256*4;
            var dst = alloc<SibRegCodes>(count);
            var offset = 0u;
            offset += SibRegCodes(RegClassCode.GP, NativeSizeCode.W8, offset, dst);
            offset += SibRegCodes(RegClassCode.GP, NativeSizeCode.W16, offset, dst);
            offset += SibRegCodes(RegClassCode.GP, NativeSizeCode.W32, offset, dst);
            offset += SibRegCodes(RegClassCode.GP, NativeSizeCode.W64, offset, dst);
            return dst;
        }

        public static Index<SibBitfieldRow> SibRows()
        {
            var buffer = alloc<SibBitfieldRow>(256);
            var f0 = BitSeq.bits(n3);
            var f1 = BitSeq.bits(n3);
            var f2 = BitSeq.bits(n2);
            ref var dst = ref first(buffer);
            var m = 0u;
            for(var k=0; k<f2.Length; k++)
            {
                for(var j=0; j<f1.Length; j++)
                {
                    for(var i=0; i<f0.Length; i++)
                    {
                        ref var row = ref seek(dst,m);
                        row.@base = skip(f0, i);
                        row.index = skip(f1, j);
                        row.scale = skip(f2, k);
                        var sib = new Sib(BitNumbers.join(row.@base, row.index, row.scale));
                        row.bitstring = bitstring(sib);
                        row.hex = (byte)m;
                        m++;
                    }
                }
            }
            return buffer;
        }

        public static Index<SibRegCodes> SibRegCodes(RegClassCode @class, NativeSize size)
        {
            var buffer = alloc<SibRegCodes>(256);
            SibRegCodes(@class,size,0,buffer);
            return buffer;
        }

        public static uint SibRegCodes(RegClassCode @class, NativeSize size, uint offset, Span<SibRegCodes> buffer)
        {
            var f0 = BitSeq.bits(n3);
            var f1 = BitSeq.bits(n3);
            var f2 = BitSeq.bits(n2);
            ref var dst = ref first(buffer);
            var counter = 0u;
            var q = offset;
            for(var k=0; k<f2.Length; k++)
            {
                for(var j=0; j<f1.Length; j++)
                {
                    for(var i=0; i<f0.Length; i++, counter++, q++)
                    {
                        ref var row = ref seek(dst, q);
                        var @base = skip(f0, i);
                        var index = skip(f1, j);
                        var scale = skip(f2,k);
                        row.Base = AsmRegs.name(size, @class, (RegIndexCode)(byte)@base);
                        row.Index  = AsmRegs.name(size, @class, (RegIndexCode)(byte)index);
                        row.Scale = scale;
                        var sib = new Sib(BitNumbers.join(@base, index, scale));
                        row.Bits = bitstring(sib);
                        row.Hex= (byte)counter;
                    }
                }
            }
            return counter;
        }

        [MethodImpl(Inline), Op]
        public static uint vsib(Vsib src, Span<char> dst)
        {
            const char Open = Chars.LBracket;
            const char Close = Chars.RBracket;
            var i=0u;
            seek(dst,i++) = Open;
            BitNumbers.render(src.SS(), ref i, dst);
            seek(dst,i++) = Chars.Space;
            BitNumbers.render(src.Index(), ref i, dst);
            seek(dst,i++) = Chars.Space;
            BitNumbers.render(src.Base(), ref i, dst);
            seek(dst,i++) = Close;
            return i;
        }

        [MethodImpl(Inline), Op]
        public static BinaryCode code(in CodeBlock src, uint offset, byte size)
            => core.slice(src.View, offset, size).ToArray();

        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static InstructionId instid(Hex32 docid, MemoryAddress ip, ReadOnlySpan<byte> encoding)
            => new InstructionId(docid, encid(ip, encoding));

        [Op]
        public static EncodingId encid(MemoryAddress ip, ReadOnlySpan<byte> encoding)
        {
            var storage = ByteBlock8.Empty;
            var dst = storage.Bytes;
            var ipbytes = bytes((uint)ip);
            var size = (byte)encoding.Length;
            var k=7;
            seek(dst,k--) = size;
            seek(dst,k--) = skip(ipbytes,0);
            seek(dst,k--) = skip(ipbytes,1);

            if(skip(ipbytes,2) != 0)
                seek(dst,k--) = skip(ipbytes,2);
            if(skip(ipbytes,3) != 0)
                seek(dst,k--) = skip(ipbytes,3);

            var j = size - 1;
            if(j>=0 && k>=0 && skip(encoding,j) != 0)
                seek(dst,k--) = skip(encoding,j--);
            if(j>=0 && k>=0 && skip(encoding,j) != 0)
                seek(dst,k--) = skip(encoding,j--);
            if(j>=0 && k>=0 && skip(encoding,j) != 0)
                seek(dst,k--) = skip(encoding,j--);
            if(j>=0 && k>=0 && skip(encoding,j) != 0)
                seek(dst,k--) = skip(encoding,j--);
            if(j>=0 && k>=0 && skip(encoding,j) != 0)
                seek(dst,k--) = skip(encoding,j--);

            return (ulong)storage;
        }

        [Op]
        public static AsmBitstring bitstring(in AsmHexCode src)
            => src;

        [MethodImpl(Inline), Op]
        public static byte encode(RexPrefix a0, Hex8 a1, imm64 a2, Span<byte> buffer)
        {
            var dst = writer(buffer);
            return dst.Write(a0,a1,a2);
        }

        [MethodImpl(Inline), Op]
        public static byte encode(Rip a0, Jcc8 a1, AsmHexWriter dst)
            => dst.Write(a1.JccCode, AsmRel8.target(a0, a1.Disp));

        [MethodImpl(Inline), Op]
        static AsmHexWriter writer(Span<byte> buffer)
            => new AsmHexWriter(buffer);

        [MethodImpl(Inline), Op]
        static byte join(Pair<byte> a, Pair<byte> b, Pair<byte> c)
        {
            var dst = Bytes.sll(a.Left, a.Right);
            dst = Bytes.or(dst, Bytes.sll(b.Left, b.Right));
            dst = Bytes.or(dst, Bytes.sll(c.Left, c.Right));
            return dst;
        }
    }
}