//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static XedFields;

    partial class XedPatterns
    {
        [MethodImpl(Inline), Op]
        public static RexBit rexr(in InstFields src)
        {
            var dst = RexBit.Empty;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var f = ref src[i];
                if(f.DataKind == InstFieldKind.Expr && f.FieldKind == FieldKind.REXR)
                {
                    dst = new (RexIndicator.R,f.AsFieldExpr().Value);
                    break;
                }
            }
            return dst;
        }
    }
}