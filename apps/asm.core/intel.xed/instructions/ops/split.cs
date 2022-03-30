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
        static Pair<InstPatternBody> split(in InstPatternBody src)
        {
            var criteria = dict<byte,InstDefPart>();
            var parts = mapi(src, (i,p) => ((byte)i, p)).ToDictionary();
            var count = src.FieldCount;
            for(byte i=0; i<count; i++)
            {
                ref readonly var part = ref src[i];
                switch(part.FieldClass)
                {
                    case DefFieldClass.FieldExpr:
                        criteria[i] = part;
                        parts.Remove(i);
                    break;
                    default:
                        break;
                }
            }

            var right = alloc<InstDefPart>(parts.Count);
            var keys = parts.Keys.Array().Sort();
            for(var i=0; i<keys.Length; i++)
                seek(right,i) = parts[skip(keys,i)];

            var left = alloc<InstDefPart>(criteria.Count);
            keys = criteria.Keys.Array().Sort();
            for(var i=0; i<keys.Length; i++)
                seek(left,i) = criteria[skip(keys,i)];

            return (left,right);
        }
    }
}