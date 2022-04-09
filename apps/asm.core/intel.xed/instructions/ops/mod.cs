//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;

    partial class XedPatterns
    {
        [MethodImpl(Inline), Op]
        public static bool mod(InstPattern src, out ModKind dst)
            => mod(src.Body, out dst);

        [MethodImpl(Inline), Op]
        public static bool mod(in InstPatternBody src, out ModKind dst)
        {
            var result = false;
            dst = ModKind.Empty;
            for(var i=0; i<src.FieldCount; i++)
            {
                ref readonly var field = ref src[i];
                if(field.FieldKind == FieldKind.MOD && field.IsFieldExpr)
                {
                    var expr = field.AsFieldExpr();
                    if(expr.Operator == OperatorKind.Neq)
                    {
                        dst = ModIndicator.NE3;
                        result = true;
                        break;
                    }
                    else if(expr.Operator == OperatorKind.Eq)
                    {
                        dst = ModIndicator.MOD3;
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }
    }
}