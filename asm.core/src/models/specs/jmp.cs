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

    partial class AsmSpecs
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
        public static byte jmp32(MemoryAddress rip, MemoryAddress dst, ref byte hex)
        {
            const byte OpCode = 0xE9;
            const byte Size = 5;
            var opcode = OpCode;
            var encoded = AsmHexCode.Empty;
            var bytes = encoded.Bytes;
            seek(hex, 0) = opcode;
            u32(seek(hex, 1)) = asm.disp32(rip,dst);
            return Size;
        }

        /// <summary>
        /// Jump short, RIP = RIP + 8-bit displacement sign extended to 64-bits
        /// </summary>
        /// <param name="w">The relative width selector</param>
        /// <param name="rip">The address of the first instruction following the callsite</param>
        /// <param name="dst">The target address</param>
        [MethodImpl(Inline), Op]
        public static byte jmp8(MemoryAddress rip, MemoryAddress dst, ref byte hex)
        {
            const byte OpCode = 0xE8;
            const byte Size = 2;
            var opcode = OpCode;
            var encoded = AsmHexCode.Empty;
            var bytes = encoded.Bytes;
            seek(hex,0) = opcode;
            u8(seek(hex, 1)) = asm.disp8(rip,dst);
            return 2;
        }
    }
}