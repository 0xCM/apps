//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    partial class XedDisasm
    {
        public static Index<CellValue> update(in LineBlock src, ref RuleState dst)
        {
            var fields = values(src);
            XedState.Edit.update(fields, ref dst);
            return fields;
        }

        public static Index<CellValue> values(in LineBlock src)
        {
            parse(src, out DisasmProps props);
            var state = RuleState.Empty;
            var names = props.Keys.Array();
            var count = names.Length;
            var dst = alloc<CellValue>(count - 2);
            var k=0u;
            for(var i=0; i<count; i++)
            {
                var name = skip(names,i);
                if(name == nameof(FieldKind.ICLASS) || name == nameof(InstForm))
                    continue;

                if(XedParsers.parse(name, out FieldKind kind))
                    seek(dst,k++) = XedState.Edit.field(props[name], kind, ref state);
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), name));
            }
            return dst;
        }
    }
}