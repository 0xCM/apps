//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static XedFields;

    partial class XedPatterns
    {
        [MethodImpl(Inline), Op]
        public static ModKind mod(InstPattern src)
            => mod(src.Fields);

        [MethodImpl(Inline)]
        public static ModKind mod(uint2 src)
            => new ModKind((ModIndicator)(byte)src + 1);

        [MethodImpl(Inline)]
        public static ModKind modNeq3()
            =>new ModKind(ModIndicator.NE3);

        [MethodImpl(Inline), Op]
        public static ModKind mod(in InstFields src)
        {
            var result = false;
            var dst = ModKind.Empty;
            for(var i=0; i<src.Count; i++)
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
            return dst;
        }
    }
}