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