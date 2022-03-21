//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedRules;
    using static XedModels;

    using R = XedRules;

    partial class XedDisasm
    {
        public static Index<R.FieldValue> fields(in DisasmLineBlock src)
        {
            var data = props(src);
            var count = data.Count;
            var dst = alloc<R.FieldValue>(count);
            var state = RuleState.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var prop = ref data[i];
                if(XedParsers.parse(prop.Key, out FieldKind kind))
                    seek(dst,i) = XedDisasm.update(prop.Value, kind, ref state);
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), prop.Key));
            }

            return dst;
        }
    }
}