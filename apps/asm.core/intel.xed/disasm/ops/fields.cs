//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedDisasm
    {
        public static Fields fields(in DisasmFile src, uint block)
            => fields(src[block]);

        public static Fields fields(in DisasmLineBlock src)
        {
            var lookups = XedLookups.Service;
            var data = props(src);
            var count = data.Count;
            var dst = XedRules.fields();
            for(var i=0; i<count; i++)
            {
                ref readonly var prop = ref data[i];
                if(XedParsers.parse(prop.Key, out FieldKind kind))
                {
                    ref readonly var spec = ref lookups.FieldSpec(kind);
                    if(spec.DeclaredType == nameof(bit))
                    {
                        dst[kind] = paired(kind,bit.On);
                    }
                    else
                    {
                        if(CellDefCalcs.parse(prop.Value, kind, out var pack))
                            dst[kind] = pack.Pack();
                        else
                            Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldPack), prop.Value));
                    }
                }
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldKind), prop.Key));
            }

            return dst;
        }
    }
}