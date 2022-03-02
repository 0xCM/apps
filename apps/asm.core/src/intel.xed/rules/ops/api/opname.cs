//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-iclass-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules.RuleOpName;
    using static XedModels;

    using FK = XedModels.FieldKind;

    partial class XedRules
    {
        [Op]
        public static RuleOpName opname(FieldKind src)
        {
            var name = RuleOpName.None;
            switch(src)
            {
                case FK.REG0:
                    name = REG0;
                break;
                case FK.REG1:
                    name = REG1;
                break;
                case FK.REG2:
                    name = REG2;
                break;
                case FK.REG3:
                    name = REG3;
                break;
                case FK.REG4:
                    name = REG4;
                break;
                case FK.REG5:
                    name = REG5;
                break;
                case FK.REG6:
                    name = REG6;
                break;
                case FK.REG7:
                    name = REG7;
                break;
                case FK.REG8:
                    name = REG8;
                break;
                case FK.MEM0:
                    name = MEM0;
                break;
                case FK.MEM1:
                    name = MEM1;
                break;
                case FK.IMM0:
                    name = IMM0;
                break;
                case FK.IMM1:
                    name = IMM1;
                break;
                case FK.RELBR:
                    name = RELBR;
                break;
                case FK.BASE0:
                    name = BASE0;
                break;
                case FK.BASE1:
                    name = BASE1;
                break;
                case FK.SEG0:
                    name = SEG0;
                break;
                case FK.SEG1:
                    name = SEG1;
                break;
                case FK.AGEN:
                    name = AGEN;
                break;
                case FK.PTR:
                    name = PTR;
                break;
                case FK.INDEX:
                    name = INDEX;
                break;
                case FK.SCALE:
                    name = SCALE;
                break;
                case FK.DISP:
                    name = DISP;
                break;
            }
            return name;
        }
    }
}