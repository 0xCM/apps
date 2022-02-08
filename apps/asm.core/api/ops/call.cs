//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static CallRel32 call(Rip rip, Disp32 disp)
            => new CallRel32(rip, AsmRel32.target(rip,disp));

        [MethodImpl(Inline), Op]
        public static byte call32(Rip src, MemoryAddress dst, ref byte hex)
        {
            const byte Size = 5;
            seek(hex, 0) = CallRel32.OpCode;
            i32(seek(hex, 1)) = AsmRel32.disp(src, dst);
            return CallRel32.InstSize;
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode call32(Rip rip, MemoryAddress dst)
        {
            var encoded = AsmHexCode.Empty;
            var bytes = encoded.Bytes;
            seek(bytes,15) = call32(rip, dst, ref first(bytes));
            return encoded;
        }

        [MethodImpl(Inline), Op]
        public static AsmHexCode call32(CallRel32 spec)
        {
            var encoding = AsmHexCode.Empty;
            var buffer = encoding.Bytes;
            seek(buffer,0) = CallRel32.OpCode;
            @as<Disp32>(seek(buffer,1)) = AsmRel32.disp(spec.Rip, spec.TargetAddress);
            seek(buffer,15) = CallRel32.InstSize;
            return encoding;
        }

        [MethodImpl(Inline), Op]
        public static bool IsCall32(ReadOnlySpan<byte> encoding)
            => encoding.Length >= CallRel32.InstSize && core.first(encoding) == CallRel32.OpCode;

    }
}