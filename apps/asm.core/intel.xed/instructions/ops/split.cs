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
        public static Pair<InstPatternBody> split(in InstPatternBody src)
        {
            var left = list<InstField>();
            var right = list<InstField>();
            var count = src.FieldCount;
            for(var i=0; i<count; i++)
            {
                ref readonly var part = ref src[i];
                if(part.IsFieldExpr)
                    right.Add(part);
                else
                    left.Add(part);
            }
            return (left.ToArray(),right.ToArray());
        }

    }
}