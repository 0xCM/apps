//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules.FieldKind;

    partial class XedRules
    {
        [Op]
        public static bool fieldseg(FieldKind src)
        {
            var result = false;
            switch(src)
            {
                case MOD:
                case REG:
                case RM:
                case SIBINDEX:
                case SIBSCALE:
                case SIBBASE:
                    result = true;
                break;
            }
            return result;
        }

        [Op]
        public static bool fieldbit(FieldKind src)
        {
            var result = false;
            switch(src)
            {
                case REXW:
                case REXR:
                case REXX:
                case REXB:
                case REXRR:
                case VEXDEST3:
                case VEXDEST4:
                    result = true;
                break;
            }

            return  result;
        }
    }
}