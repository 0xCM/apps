//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Sse3;
    using static Root;
    using static core;

    [ApiHost]
    public readonly struct AsmEncoding
    {
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