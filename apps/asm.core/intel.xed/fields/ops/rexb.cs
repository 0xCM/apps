//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedFields
    {
        [MethodImpl(Inline), Op]
        public static BitIndicator rexb(in InstFields src)
        {
            var dst = BitIndicator.Empty;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var f = ref src[i];
                if(f.IsFieldExpr && f.FieldKind == FieldKind.REXB)
                {
                    dst = BitIndicator.defined(f.ToFieldExpr().Value);
                    break;
                }
            }
            return dst;
        }
    }
}