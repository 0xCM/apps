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

    partial class XedFields
    {
        public XedRegs regs(in RuleState src)
        {
            var dst = XedRegs.Empty;
            var count = z8;
            if(src.REG0 != 0)
            {

            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static XedRegs regs(params XedRegId[] src)
            => new XedRegs(src);
    }
}