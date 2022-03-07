//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct XedModels
    {
        public static AttributeKind[] attributes(string src, char delimiter)
        {
            var parts = src.SplitClean(delimiter).ToReadOnlySpan();
            var count = parts.Length;
            if(count == 0)
                return default;

            var counter = 0u;
            var dst = span<AttributeKind>(count);
            for(var i=0; i<count; i++)
            {
                ref var target = ref seek(dst,i);
                var result = DataParser.eparse(skip(parts,i), out target);
                if(result)
                {
                    if(target != 0)
                        counter++;
                }
                else
                    return sys.empty<AttributeKind>();
            }

            return slice(dst,0,counter).ToArray();
        }
    }
}