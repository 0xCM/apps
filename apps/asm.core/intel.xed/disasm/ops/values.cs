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
        public static Index<CellValue> values(in DisasmLineBlock src)
        {
            DisasmParse.parse(src, out DisasmProps props);
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
                    seek(dst,k++) = XedState.update(props[name], kind, ref state);
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), name));
            }
            return dst;
        }
    }
}