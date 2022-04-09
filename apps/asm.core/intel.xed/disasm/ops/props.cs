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
    using static XedPatterns;

    partial class XedDisasm
    {
        public static DisasmProps kvp(in DisasmLineBlock src)
        {
            var content = text.trim(text.despace(src.Props.Content));
            var i = text.index(content,Chars.Space);
            var @class = text.left(content,i);
            var right = text.right(content,i);
            var j = text.index(right, Chars.Space);
            var form = text.left(right,i);
            var props = text.trim(text.split(text.right(right,j), Chars.Comma));
            var count = props.Length;
            var dst = alloc<Facet<string>>(count + 2);
            var k=0u;
            seek(dst,k++) = (nameof(FieldKind.ICLASS), @class);
            seek(dst,k++) = (nameof(InstForm), form);
            for(var m=0; m<count; m++,k++)
            {
                var prop = skip(props,m);
                if(text.contains(prop,Chars.Colon))
                {
                    var kv = text.split(prop,Chars.Colon);
                    Demand.eq(kv.Length,2);
                    seek(dst,k) = ((skip(kv,0), skip(kv,1)));
                }
                else
                    seek(dst,k) = ((prop, "1"));
            }

            parse(src, out var _class, out var _form);

            return DisasmProps.load(_class, _form, dst);


        }

        static void parse(in DisasmLineBlock src, out InstClass @class, out InstForm form)
        {
            var content = text.trim(text.split(text.despace(src.Props.Content), Chars.Space));
            XedParsers.parse(skip(content,0), out @class);
            if(!XedParsers.parse(skip(content,1), out form))
            {
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(InstForm), skip(content,1)));
            }
        }

        public static Index<Facet<string>> props(in DisasmLineBlock src)
        {
            var dst = Index<Facet<string>>.Empty;
            var content = text.trim(text.despace(src.Props.Content));
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