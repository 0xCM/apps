//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static bool scale(in RuleState src, uint4 dst)
        {
            if(src.SCALE != 0)
            {
                dst = src.SCALE;
                return true;
            }
            {
                dst = default;
                return false;
            }
        }
    }
}