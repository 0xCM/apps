//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;

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