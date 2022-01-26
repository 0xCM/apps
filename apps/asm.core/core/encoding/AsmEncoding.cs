//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public class AsmEncoding : AppService<AsmEncoding>
    {
        const string FieldSep = " | ";

        public static string bitstring(Sib src)
            => string.Format("{0} {1} {2}", BitRender.format2(src.Scale), BitRender.format3(src.Index), BitRender.format3(src.Base));


        [MethodImpl(Inline), Op]
        static uint sib(Sib src, ref uint i, Span<char> dst)
        {
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
        public static uint bits(Span<char> dst)
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
        public static bool rel32dx(BinaryCode src, out int dx)
        {
            var opcode = src.First;
            if(opcode == 0xe8)
            {
                dx = i32(slice(src.View, 1));
                return true;
            }
            dx = default;
            return false;
        }

        [MethodImpl(Inline), Op]
        public static SizeOverrides overrides(bit opsz, bit adsz)
            => new SizeOverrides(opsz,adsz);

        [Op]
        public static AsmEncodingInfo describe(in AsmFormInfo form, in AsmExpr statement, in AsmHexCode encoded)
            => new AsmEncodingInfo(form, statement, encoded, AsmBits.bitstring(encoded));

        [MethodImpl(Inline), Op]
        public static AsmEncodingInfo describe(in AsmFormInfo form, in AsmExpr statement, in AsmHexCode encoded, in AsmBitstring bitstring)
            => new AsmEncodingInfo(form, statement, encoded, bitstring);

         [MethodImpl(Inline), Op]
         static byte combine(Pair<byte> a, Pair<byte> b, Pair<byte> c)
         {
             var dst = Bytes.sll(a.Left, a.Right);
             dst = Bytes.or(dst, Bytes.sll(b.Left, b.Right));
             dst = Bytes.or(dst, Bytes.sll(c.Left, c.Right));
             return dst;
         }

        [MethodImpl(Inline), Op]
        public static Sib sib(uint3 @base, uint3 index, uint2 scale)
            => new Sib(combine((scale, 0), (index, 2), (@base, 6)));

        [MethodImpl(Inline), Op]
        public static ModRm modrm(byte src)
            => new ModRm(src);

        [MethodImpl(Inline), Op]
        public static ModRm modrm(byte rm, byte reg, byte mod)
            => new ModRm(combine((rm, 0), (reg, 3), (mod, 6)));

        [MethodImpl(Inline), Op]
        public static ModRm modrm(RegIndex r1, RegIndex r2)
            => modrm((byte)r1, (byte)r2, 0b11);

        [MethodImpl(Inline), Op]
        public static ModRm modrm(RegIndex rm, RegIndex reg, byte mod)
            => modrm((byte)rm, (byte)reg, mod);

        [Op]
        public static string semantic(in AsmDetailRow row)
        {
            var encoded = row.Encoded.Bytes;
            var ip = row.IP;
            var @base = row.BlockAddress;

            if(row.Mnemonic.Format(MnemonicCase.Lowercase) == "jmp")
            {
                if(JmpRel8.test(encoded))
                    return string.Format("jmp(rel8,{0},{1}) -> {2}",
                        JmpRel8.dx(encoded),
                        JmpRel8.offset(@base, ip, encoded),
                        JmpRel8.target(ip, encoded)
                        );
                else if(JmpRel32.test(encoded))
                    return string.Format("jmp(rel32,{0},{1}) -> {2}",
                        JmpRel32.dx(encoded).FormatMinimal(),
                        JmpRel32.offset(@base, ip, encoded).FormatMinimal(),
                        JmpRel32.target(ip, encoded)
                        );
                else if(Jmp64.test(encoded))
                    return string.Format("jmp({0})", Jmp64.target(encoded));
            }
            return EmptyString;
        }

        [Op]
        public static Imm imm(AsmHexCode src, byte pos, bool signed, NativeSize size)
        {
            var dst = Imm.Empty;
            switch(size.Code)
            {
                case NativeSizeCode.W8:
                    dst = AsmOpFactory.imm(size, signed, src[pos]);
                break;
                case NativeSizeCode.W16:
                    dst = AsmOpFactory.imm(size, signed, slice(src.Bytes,pos, 2).TakeUInt16());
                break;
                case NativeSizeCode.W32:
                    dst = AsmOpFactory.imm(size, signed, slice(src.Bytes,pos, 4).TakeUInt32());
                break;
                case NativeSizeCode.W64:
                    dst = AsmOpFactory.imm(size, signed, slice(src.Bytes,pos, 8).TakeUInt64());
                break;
            }
            return dst;
        }

        [Op]
        public static long disp(AsmHexCode src, byte pos, NativeSize size)
        {
            var val = Disp.Zero;
            var width = (byte)size.Width;
            var length = (byte)(width/8);
            switch(size.Code)
            {
                case NativeSizeCode.W8:
                    val = new Disp((sbyte)src[pos], width);
                break;
                case NativeSizeCode.W16:
                    val = new Disp(slice(src.Bytes, pos, length).TakeInt16(), width);
                break;
                case NativeSizeCode.W32:
                    val = new Disp(slice(src.Bytes, pos, length).TakeInt32(), width);
                break;
                case NativeSizeCode.W64:
                    val = new Disp(slice(src.Bytes, pos, length).TakeInt64(), width);
                break;
            }

            return val;
        }
    }
}