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
        public static bool sib(in RuleState src, out Sib dst)
        {
            if(src.HAS_SIB)
            {
                dst = Sib.init();
                dst.Base = src.SIBBASE;
                dst.Index = src.SIBINDEX;
                dst.Scale = src.SIBSCALE;
                return true;
            }
            else
            {
                dst = Sib.Empty;
                return false;
            }
        }
    }
}