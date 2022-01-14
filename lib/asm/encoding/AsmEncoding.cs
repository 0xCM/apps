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
                    dst = asm.imm(size, signed, src[pos]);
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