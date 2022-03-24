//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    partial class XedPatterns
    {
        public static InstAttribs attributes(string src)
        {
            var input = text.trim(src);
            if(empty(input))
                return InstAttribs.Empty;

            var sep = ',';
            if(input.Contains(Chars.Colon))
                sep = ':';
            else if(input.Contains(Chars.Space))
                sep = ' ';

            if(text.fenced(input, RenderFence.Embraced))
            {
                if(input.Length > 2)
                    input = text.unfence(input, RenderFence.Embraced);
                else
                    input = EmptyString;
            }

            if(empty(input))
                return InstAttribs.Empty;

            var parts = input.SplitClean(sep).ToReadOnlySpan();
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