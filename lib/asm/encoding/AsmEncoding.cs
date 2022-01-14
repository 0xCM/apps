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
        [Op]
        public static Imm imm(AsmHexCode src, byte pos, bool signed, NativeSize size)
        {
            var dst = Imm.Empty;
            switch(size.Code)
            {
                case NativeSizeCode.W8:
                    dst = asm.imm(size,signed, src[pos]);
                break;
                case NativeSizeCode.W16:
                    dst = asm.imm(size, signed, slice(src.Bytes,pos, 2).TakeUInt16());
                break;
                case NativeSizeCode.W32:
                    dst = asm.imm(size, signed, slice(src.Bytes,pos, 4).TakeUInt32());
                break;
                case NativeSizeCode.W64:
                    dst = asm.imm(size, signed, slice(src.Bytes,pos, 8).TakeUInt64());
                break;
            }
            return dst;
        }
    }
}