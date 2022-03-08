//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules.RuleOpName;

    using FK = XedRules.FieldKind;

    partial class XedRules
    {
        public static bool opname(string src, out RuleOpName dst)
        {
            var input = text.despace(src);
            var i = text.index(input, Chars.Colon);
            var j = text.index(input, Chars.Eq);

            var index = -1;
            if(i > 0 && j > 0)
            {
                index = i < j ? i : j;
            }
            else if(i>0 && j<0)
            {
                index = i;
            }
            else if(j>0 && i<0)
            {
                index = j;
            }

            return OpNames.ExprKind(text.left(input, index), out dst);
        }

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