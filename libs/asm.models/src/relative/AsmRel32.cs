//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [ApiHost]
    public readonly struct AsmRel32
    {
        [MethodImpl(Inline), Op]
        public static Disp32 disp(Rip rip, MemoryAddress dst)
            => (Disp32)((long)dst - (long)rip);

        [MethodImpl(Inline), Op]
        public static MemoryAddress target(Rip rip, Disp32 disp)
            => (MemoryAddress)((long)rip + (long)disp);

        [MethodImpl(Inline), Op]
        public static MemoryAddress target(Rip rip, ReadOnlySpan<byte> encoding)
            => (MemoryAddress)((long)rip + (int)disp(encoding));

        [MethodImpl(Inline), Op]
        public static Address32 reltarget(Disp32 disp)
            => (Address32)((int)disp + (int)JmpRel32.InstSize);

        [MethodImpl(Inline), Op]
        public static Disp32 disp(ReadOnlySpan<byte> encoding)
        {
            var storage = ByteBlock4.Empty;
            var buffer = storage.Bytes;
            ref var dst = ref @as<Disp32>(buffer);
            dst = @as<Disp32>(slice(encoding,1,4));
            return dst;
        }
    }
}