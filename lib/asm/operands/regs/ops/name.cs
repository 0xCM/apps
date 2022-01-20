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
    using static RegClasses;

    partial struct AsmRegs
    {
        static AsmRegName gp8hi(RegIndexCode index)
        {
            const byte RegLength = 2;
            const string Data = "ahchdhbh";
            var i0 = (ushort)((uint)index*RegLength);
            return FixedChars.txt(n7,slice(text.chars(Data), i0, RegLength));
        }

        public static AsmRegName name<T>(T src)
            where T : unmanaged, IRegOp
        {
            switch(src.RegClassCode)
            {
                case RegClassCode.GP:
                    return Gp.RegName(src.Index, (NativeSizeCode)(u16(src) & 0b111));
                case RegClassCode.GP8HI:
                    return gp8hi(src.Index);
                case RegClassCode.XMM:
                    return Xmm.RegName(src.Index);
                case RegClassCode.YMM:
                    return Ymm.RegName(src.Index);
                case RegClassCode.ZMM:
                    return Zmm.RegName(src.Index);
                case RegClassCode.MASK:
                    return KReg.RegName(src.Index);
                case RegClassCode.MMX:
                    return Mmx.RegName(src.Index);
                case RegClassCode.DB:
                    return Db.RegName(src.Index);
                case RegClassCode.CR:
                    return Cr.RegName(src.Index);
            }
            return text7.Empty;
        }
    }
}