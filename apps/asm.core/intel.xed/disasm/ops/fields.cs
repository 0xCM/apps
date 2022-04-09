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

        public static Fields fields(in DisasmLineBlock src, Index<Facet<string>> props)
            => fields(src, props, XedFields.fields());

        public static Fields fields(in DisasmLineBlock src, DisasmProps props, Fields dst, bool clear = true)
        {
            if(clear)
                dst.Clear();

            var count = props.Count;
            var keys = props.Keys.Array();
            for(var i=0; i<count; i++)
            {
                var name = skip(keys,i);
                var value = props[name];
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