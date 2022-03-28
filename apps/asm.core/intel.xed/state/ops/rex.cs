//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;

    partial class XedState
    {
        [MethodImpl(Inline), Op]
        public static RexPrefix rex(in RuleState src)
            => new RexPrefix(src.REXB, src.REXX, src.REXR, src.REXW);

        [MethodImpl(Inline), Op]
        public static bool rex(in RuleState src, out RexPrefix dst)
        {
            if(src.REX)
            {
                dst = RexPrefix.init();
                dst.W = src.REXW;
                dst.R = src.REXR;
                dst.X = src.REXX;
                dst.B= src.REXB;
                return true;
            }
            else
            {
                dst = RexPrefix.Empty;
                return false;
            }
        }
    }
}