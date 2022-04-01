//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedPatterns
    {
        [MethodImpl(Inline), Op]
        public static bit @locked(in InstPatternBody src)
        {
            var result = bit.Off;
            for(var i=0; i<src.FieldCount; i++)
            {
                ref readonly var field = ref src[i];
                if(field.FieldKind == FieldKind.LOCK)
                {
                    result = field.AsFieldExpr().Value;
                    break;
                }
            }
            return result;
        }
    }
}