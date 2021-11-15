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
    using static AsmOperands;

    partial class AsmSpecs
    {
        /// <summary>
        /// | 0F B6 /r | MOVZX r16, r8 | Move byte to word with zero-extension.
        /// </summary>
        /// <param name="dst">The target register</param>
        /// <param name="src">The source register</param>
        /// <typeparam name="T">The target register type</typeparam>
        /// <typeparam name="S">The source register type</typeparam>
        [MethodImpl(Inline), Op]
        public static byte movzx(r16 dst, r8 src, ref byte hex)
        {
            const byte Size = 5;
            seek(hex,0) = AsmEncoding.modrm(dst.Index, src.Index, 0);
            seek(hex,1)  = 0xB6;
            seek(hex,2)  = 0x0F;
            seek(hex,3)  = 0x66;
            return Size;
        }
    }
}