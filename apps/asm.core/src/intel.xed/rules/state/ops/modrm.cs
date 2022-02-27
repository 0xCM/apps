//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial struct XedModels
    {
        partial struct RuleStateCalcs
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
}