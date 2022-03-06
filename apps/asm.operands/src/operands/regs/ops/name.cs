//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static RegClasses;

    partial struct AsmRegs
    {
        public static AsmRegName name<T>(T src)
            where T : unmanaged, IRegOp
                => name(src.Size, src.RegClassCode, src.Index);

        public static AsmRegName name(NativeSizeCode size, RegClassCode @class, RegIndexCode index)
        {
            switch(@class)
            {
                case RegClassCode.GP:
                    return Gp.RegName(index, size);
                case RegClassCode.GP8HI:
                    return Gp8Hi.RegName((RegIndexCode)((byte)index - 4));
                case RegClassCode.XMM:
                    return Xmm.RegName(index);
                case RegClassCode.YMM:
                    return Ymm.RegName(index);
                case RegClassCode.ZMM:
                    return Zmm.RegName(index);
                case RegClassCode.MASK:
                    return KReg.RegName(index);
                case RegClassCode.MMX:
                    return Mmx.RegName(index);
                case RegClassCode.DB:
                    return Db.RegName(index);
                case RegClassCode.CR:
                    return Cr.RegName(index);
                case RegClassCode.TR:
                    return Tr.RegName(index);
                case RegClassCode.ST:
                    return St.RegName(index);
                case RegClassCode.SEG:
                    return Seg.RegName(index);
            }
            return text7.Empty;
        }
    }
}