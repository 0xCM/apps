//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedFields
    {
        [MethodImpl(Inline), Op]
        public static BitIndicator rexw(in InstFields src)
        {
            var dst = BitIndicator.Empty;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var f = ref src[i];
                if(f.IsCellExpr && f.FieldKind == FieldKind.REXW)
                {
                    dst = BitIndicator.defined(f.ToCellExpr().Value);
                    break;
                }
            }
            return dst;
        }
    }
}