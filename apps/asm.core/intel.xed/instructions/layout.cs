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
        public static InstPatternBody layout(in InstPatternBody body)
        {
            var buffer = list<InstDefField>();
            var count = body.FieldCount;
            for(var i=0; i<count; i++)
            {
                ref readonly var part = ref body[i];
                if(!part.IsFieldExpr)
                    buffer.Add(part);
            }
            return buffer.ToArray();
        }
    }
}