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

    partial class AsmHexSpecs
    {
        /// <summary>
        /// Jump near, relative, RIP = RIP + 32-bit displacement sign extended to 64-bits
        /// </summary>
        /// <param name="w">The relative width selector</param>
        /// <param name="rip">The address of the first instruction following the callsite</param>
        /// <param name="dst">The target address</param>
        [MethodImpl(Inline), Op]
        public static AsmHexCode jmp32(MemoryAddress rip, MemoryAddress dst)
        {
            var encoded = AsmHexCode.Empty;
            var bytes = encoded.Bytes;
            seek(bytes,15) = jmp32(rip, dst, ref first(bytes));
            return encoded;
        }

        [MethodImpl(Inline), Op]
        public static byte jmp32(MemoryAddress ip, MemoryAddress dst, ref byte hex)
        {
            const byte Size = 5;
            seek(hex, 0) = JmpRel32.OpCode;
            i32(seek(hex, 1)) = AsmOpFactory.disp32(ip + Size, dst);
            return Size;
        }

        /// <summary>
        /// Jump short, RIP = RIP + 8-bit displacement sign extended to 64-bits
        /// </summary>
        /// <param name="w">The relative width selector</param>
        /// <param name="ip">The address of the first instruction following the callsite</param>
        /// <param name="dst">The target address</param>
        [MethodImpl(Inline), Op]
        public static byte jmp8(MemoryAddress ip, MemoryAddress dst, ref byte hex)
        {
            const byte Size = 2;
            var encoded = AsmHexCode.Empty;
            var bytes = encoded.Bytes;
            seek(hex,0) = JmpRel8.OpCode;
            u8(seek(hex, 1)) = AsmOpFactory.disp8(ip + Size, dst);
            return 2;
        }
    }
}