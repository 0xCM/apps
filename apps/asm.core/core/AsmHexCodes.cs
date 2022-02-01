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
    public readonly struct AsmHexCodes
    {
        [MethodImpl(Inline), Op]
        public static AsmHexCode define(Hex8 a0, imm8 a1)
        {
            var dst = writer(buffer());
            dst.Write8(a0);
            dst.Write8(a1);
            return load(dst);
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode define(RexPrefix a0, Hex8 a1, imm64 a2)
        {
            var dst = writer(buffer());
            dst.Write8(a0);
            dst.Write8(a1);
            dst.Write64(a2);
            return load(dst);
        }

        [MethodImpl(Inline), Op]
        static byte write1<T>(T src, ref byte dst)
            where T : unmanaged
        {
            dst = u8(src);
            return 1;
        }

        [MethodImpl(Inline), Op]
        static byte write2<T>(T src, ref byte dst)
            where T : unmanaged
        {
            seek16(dst,0) = u16(src);
            return 2;
        }

        [MethodImpl(Inline), Op]
        static byte write4<T>(T src, ref byte dst)
            where T : unmanaged
        {
            seek32(dst,0) = u32(src);
            return 4;
        }

        [MethodImpl(Inline), Op]
        static byte write8<T>(T src, ref byte dst)
            where T : unmanaged
        {
            seek64(dst,0) = u64(src);
            return 8;
        }

        [MethodImpl(Inline), Op]
        public static byte encode(RexPrefix a0, Hex8 a1, imm64 a2, ref byte dst)
        {
            var size = z8;
            size += write1(a0, ref seek(dst, size));
            size += write1(a1, ref seek(dst, size));
            size += write8(a2, ref seek(dst, size));
            return size;
        }

        [MethodImpl(Inline), Op]
        static SpanWriter writer(Span<byte> buffer)
            => Spans.writer(buffer);

        [MethodImpl(Inline), Op]
        static Span<byte> buffer()
            => ByteBlocks.alloc(n16).Bytes;

        [MethodImpl(Inline), Op]
        static AsmHexCode close(in SpanWriter writer, Span<byte> dst)
        {
            seek(dst, AsmHexCode.SizeIndex) = (byte)writer.BytesWritten;
            return new AsmHexCode(first(recover<Cell128>(dst)));
        }

        [MethodImpl(Inline)]
        static unsafe Vector128<byte> vload(Span<byte> src)
            => LoadDquVector128(gptr(first(src)));

        [MethodImpl(Inline), Op]
        static AsmHexCode load(SpanWriter writer)
        {
            seek(writer.Target, AsmHexCode.SizeIndex) = (byte)writer.BytesWritten;
            return new AsmHexCode(vload(writer.Target));
        }
    }
}