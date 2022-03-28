//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedState
    {
        [MethodImpl(Inline), Op]
        public static ScaleFactor scale(in RuleState src)
            => (ScaleFactor)src.SCALE;

        [MethodImpl(Inline), Op]
        public static void scale(ScaleFactor src, ref RuleState dst)
            => dst.SCALE = (byte)src;

        [MethodImpl(Inline), Op]
        public static bool scale(in RuleState src, out ScaleFactor dst)
        {
            if(src.SCALE != 0)
            {
                dst = (ScaleFactor)src.SCALE;
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }
    }
}