//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;

    partial class XedFields
    {
        [MethodImpl(Inline), Op]
        public static ModIndicator mod(in InstFields src)
        {
            var result = false;
            var dst = ModIndicator.Empty;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var field = ref src[i];
                if(field.FieldKind == FieldKind.MOD && field.IsFieldExpr)
                {
                    var expr = field.ToFieldExpr();
                    if(expr.Operator == OperatorKind.Neq)
                    {
                        dst = ModKind.NE3;
                        result = true;
                        break;
                    }
                    else if(expr.Operator == OperatorKind.Eq)
                    {
                        dst = ModKind.MOD3;
                        result = true;
                        break;
                    }
                }
            }
            return dst;
        }
    }
}