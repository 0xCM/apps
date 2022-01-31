//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [ApiHost]
    public readonly struct AsmRel8
    {
        const byte Rel8InstSize = 2;

        [MethodImpl(Inline), Op]
        public static bool isJmp(ReadOnlySpan<byte> encoding)
            => encoding.Length >= JmpRel8.InstSize && first(encoding) == JmpRel8.OpCode;

        [MethodImpl(Inline), Op]
        public static Disp8 disp(ReadOnlySpan<byte> encoding)
            => skip(encoding,1);

        [MethodImpl(Inline), Op]
        public static Disp8 disp(MemoryAddress src, MemoryAddress dst)
        {
            var rip = src + Rel8InstSize;
            var dx = (byte)(rip - dst);
            return dx;
        }

        [MethodImpl(Inline), Op]
        public static MemoryAddress target(MemoryAddress src, ReadOnlySpan<byte> encoding)
        {
            var rip = src + Rel8InstSize;
            var dx = disp(encoding);
            return rip + dx;
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode encode(JmpRel8 spec)
        {
            var encoding = AsmHexCode.Empty;
            var buffer = encoding.Bytes;
            seek(buffer,0) = JmpRel8.OpCode;
            seek(buffer,1) = AsmRel8.disp(spec.SourceAddress, spec.TargetAddress);
            return encoding;
        }
    }
}