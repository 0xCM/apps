//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedRules;
    using static XedModels;

    partial class XedDisasm
    {
        public static Outcome parse(in LineBlock src, out AsmInfo dst)
            => DisasmParse.parse(src.XDis.Content, out dst);

        public static Outcome parse(in LineBlock src, out Instruction dst)
        {
            var result = Outcome.Success;
            dst = default(Instruction);
            ref readonly var content = ref src.Props.Content;
            if(text.nonempty(content))
            {
                result = DisasmParse.parse(src, out dst.Class);
                if(result.Fail)
                    return result;

                result = DisasmParse.parse(src, out dst.Form);
                if(result.Fail)
                    return result;

                XedDisasm.parse(src, out dst.Props);
            }
            return result;
        }

        public static void parse(in Instruction src, out DisasmState dst)
        {
            var parser = new FieldParser();
            dst = parser.Parse(src.Props);
        }

        public static uint parse(in LineBlock src, out DisasmProps dst)
        {
            var content = text.trim(text.despace(src.Props.Content));
            var i = text.index(content,Chars.Space);
            var @class = text.left(content,i);
            var right = text.right(content,i);
            var j = text.index(right, Chars.Space);
            var form = text.left(right,i);
            var props = text.trim(text.split(text.right(right,j), Chars.Comma));
            var count = props.Length;
            var facets = alloc<Facet<string>>(count + 2);
            var k=0u;
            seek(facets,k++) = (nameof(FieldKind.ICLASS), @class);
            seek(facets,k++) = (nameof(InstForm), form);
            for(var m=0; m<count; m++,k++)
            {
                var prop = skip(props,m);
                if(text.contains(prop,Chars.Colon))
                {
                    var kv = text.split(prop,Chars.Colon);
                    Demand.eq(kv.Length,2);
                    seek(facets,k) = ((skip(kv,0), skip(kv,1)));
                }
                else
                    seek(facets,k) = ((prop, "1"));
            }

            DisasmParse.parse(src, out var _class, out var _form);

            dst = XedDisasm.props(_class, _form, facets);

            return k;
        }


    }
}