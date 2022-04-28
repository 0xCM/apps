//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static core;

    partial class XedState
    {
        [Op]
        public static XedRegs regs(in OperandState src)
        {
            var storage = ByteBlock32.Empty;
            var dst = recover<XedRegId>(storage.Bytes);
            var count = z8;
            if(src.REG0 != 0)
                seek(dst,count++) = src.REG0;
            if(src.REG1 != 0)
                seek(dst,count++) = src.REG1;
            if(src.REG2 != 0)
                seek(dst,count++) = src.REG2;
            if(src.REG3 != 0)
                seek(dst,count++) = src.REG3;
            if(src.REG4 != 0)
                seek(dst,count++) = src.REG4;
            if(src.REG5 != 0)
                seek(dst,count++) = src.REG5;
            if(src.REG6 != 0)
                seek(dst,count++) = src.REG6;
            if(src.REG7 != 0)
                seek(dst,count++) = src.REG7;
            if(src.REG8 != 0)
                seek(dst,count++) = src.REG8;
            if(src.REG9 != 0)
                seek(dst,count++) = src.REG9;
            storage[31] = count;
            return @as<XedRegs>(storage.Bytes);
        }

        partial struct Edit
        {
            public static ref Register reg(byte n, ref OperandState dst)
            {
                switch(n)
                {
                    default:
                        return ref @as<XedRegId,Register>(dst.REG0);
                    case 1:
                        return ref @as<XedRegId,Register>(dst.REG0);
                    case 2:
                        return ref @as<XedRegId,Register>(dst.REG0);
                    case 3:
                        return ref @as<XedRegId,Register>(dst.REG0);
                    case 4:
                        return ref @as<XedRegId,Register>(dst.REG0);
                    case 5:
                        return ref @as<XedRegId,Register>(dst.REG0);
                    case 6:
                        return ref @as<XedRegId,Register>(dst.REG0);
                    case 7:
                        return ref @as<XedRegId,Register>(dst.REG0);
                    case 8:
                        return ref @as<XedRegId,Register>(dst.REG0);
                    case 9:
                        return ref @as<XedRegId,Register>(dst.REG9);
                }
            }

            [Op]
            public static ref readonly XedRegs regs(in XedRegs src, ref OperandState dst)
            {
                for(byte i=0; i<src.Count; i++)
                    reg(i, ref dst) = @as<XedRegId,Register>(src[i]);
                return ref src;
            }
        }
    }
}