//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedPatterns
    {
        [MethodImpl(Inline), Op]
        public static bool @lock(in InstPatternBody src, out bit dst)
        {
            var result = false;
            dst = FieldValue.Empty;
            for(var i=0; i<src.FieldCount; i++)
            {
                ref readonly var field = ref src[i];
                if(field.FieldKind == FieldKind.LOCK)
                {
                    dst = field.AsFieldExpr().Value;
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}