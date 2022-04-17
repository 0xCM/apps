//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    partial class XedPatterns
    {
        [MethodImpl(Inline), Op]
        public static bool bcast(in PatternOp src, out BCastKind dst)
        {
            dst = 0;
            if(src.Kind == OpKind.Bcast)
                if(XedParsers.parse(src.SourceExpr, out dst))
                    return true;
            return false;
        }
    }
}