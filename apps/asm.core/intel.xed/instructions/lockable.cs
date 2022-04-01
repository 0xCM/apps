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
        public static bit lockable(in InstPatternBody src)
        {
            var result = bit.Off;
            for(var i=0; i<src.FieldCount; i++)
            {
                ref readonly var field = ref src[i];
                result = field.FieldKind == FieldKind.LOCK;
                if(result)
                    break;
            }
            return result;
        }
    }
}