//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDisasm
    {
        public static Index<Facet<string>> props(in DisasmLineBlock src)
        {
            var dst = Index<Facet<string>>.Empty;
            var content = text.despace(src.Props.Content);
            var j = text.index(content, Chars.Space);
            if(j > 0)
            {
                var k = text.index(content, j+1, Chars.Space);
                if(k > 0)
                {
                    var props = text.words(text.right(content,k), Chars.Comma);
                    var count = props.Count;
                    var y = text.left(content,j);
                    var z = text.split(y,Chars.Space);

                    dst = alloc<Facet<string>>(count);
                    for(var m=0; m<count; m++)
                    {
                        ref readonly var prop = ref props[m];
                        if(prop.Contains(Chars.Colon))
                        {
                            var kv = text.split(prop, Chars.Colon);
                            if(kv.Length == 2)
                                dst[m] = (skip(kv,0).Trim(), skip(kv,1).Trim());
                        }
                        else
                            dst[m] = (prop.Trim(), EmptyString);
                    }
                }
            }
            return dst;
        }
    }
}