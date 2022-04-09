//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedPatterns
    {
        public static InstPatternBody layout(in InstPatternBody src)
        {
            var buffer = list<InstField>();
            var count = src.FieldCount;
            for(var i=0; i<count; i++)
            {
                ref readonly var part = ref src[i];
                if(!part.IsFieldExpr)
                    buffer.Add(part);
            }
            return buffer.ToArray();
        }
    }
}