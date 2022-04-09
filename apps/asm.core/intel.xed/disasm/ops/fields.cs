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

    partial class XedDisasm
    {
        public static Index<Facet<string>> kvp(in DisasmLineBlock src)
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

            return dst;
        }

        public static Fields fields(in DisasmLineBlock src, Index<Facet<string>> props)
            => fields(src, props, XedFields.fields());

        public static Fields fields(in DisasmLineBlock src, Index<Facet<string>> props, Fields dst, bool clear = true)
        {
            if(clear)
                dst.Clear();

            var count = props.Count;
            for(var i=0; i<count; i++)
            {
                var name = props[i].Key;
                var value = props[i].Value;
                if(name == nameof(InstForm))
                    continue;

                if(XedParsers.parse(name, out FieldKind kind))
                {
                    if(TableCalcs.parse(value, kind, out var pack))
                        dst.Update(pack);
                    else
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldPack), value));
                }
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind),name));
            }
            return dst;
        }
    }
}