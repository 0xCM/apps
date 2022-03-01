//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static bool modrm(in RuleState src, out ModRm dst)
        {
            if(src.HAS_MODRM)
            {
                dst = ModRm.init();
                dst.Mod(src.MOD);
                dst.Reg(src.REG);
                dst.Rm(src.RM);
                return true;
            }
            else
            {
                dst = ModRm.Empty;
                return false;
            }
        }
    }
}