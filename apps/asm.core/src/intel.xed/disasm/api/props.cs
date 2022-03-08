//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;
    using R = XedRules;

    partial class XedDisasm
    {
        public static Index<R.FieldValue> props2(in DisasmLineBlock src)
        {
            var data = props(src);
            var count = data.Count;
            var dst = alloc<R.FieldValue>(count);
            var state = RuleState.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var x = ref data[i];

                if(Parsers.FieldKind(x.Key, out var kind))
                {
                    seek(dst,i) = XedRules.update(x.Value, kind, ref state);
                }
                else
                {
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), x.Key));
                }
            }

            return dst;

        }
        public static Index<Facet<string>> props(in DisasmLineBlock src)
        {
            var dst = Index<Facet<string>>.Empty;
            ref readonly var content = ref src.Instruction.Content;
            var j = text.index(content, Chars.Space);
            if(j > 0)
            {
                var k = text.index(content, j+1, Chars.Space);
                if(k > 0)
                {
                    var props = text.words(text.right(content,k), Chars.Comma);
                    var count = props.Count;
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