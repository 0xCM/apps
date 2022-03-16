//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules.FieldKind;
    using static XedRules;

    [ApiHost]
    public partial class XedFields
    {
        [Op]
        public static bool ispos(FieldKind field)
        {
            var result = false;
            switch(field)
            {
                case POS_NOMINAL_OPCODE:
                case POS_MODRM:
                case POS_SIB:
                case POS_IMM:
                case POS_IMM1:
                case POS_DISP:
                    result = true;
                break;
            }
            return result;
        }
    }
}