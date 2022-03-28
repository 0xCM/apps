//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;
    using static XedRules;
    using static core;

    partial class XedState
    {
        [Op]
        public static XedRegs regs(in RuleState src)
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

        [Op]
        public static ref RuleState set(in XedRegs src, ref RuleState dst)
        {
            for(byte i=0; i<src.Count; i++)
            {
                ref readonly var reg = ref src[i];
                switch(i)
                {
                    case 0:
                        dst.REG0 = reg;
                    break;
                    case 1:
                        dst.REG1 = reg;
                    break;
                    case 2:
                        dst.REG2 = reg;
                    break;
                    case 3:
                        dst.REG3 = reg;
                    break;
                    case 4:
                        dst.REG4 = reg;
                    break;
                    case 5:
                        dst.REG5 = reg;
                    break;
                    case 6:
                        dst.REG6 = reg;
                    break;
                    case 7:
                        dst.REG7 = reg;
                    break;
                    case 8:
                        dst.REG8 = reg;
                    break;
                    case 9:
                        dst.REG9 = reg;
                    break;
                }
            }

            return ref dst;
        }
    }
}