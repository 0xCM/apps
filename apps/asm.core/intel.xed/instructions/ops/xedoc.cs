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

    partial class XedPatterns
    {
        public static XedOpCode xedoc(uint pattern, InstPatternBody body)
        {
            var vc = VexClass.None;
            var number = z8;
            var value = ocvalue(body);
            var kind = OpCodeKind.None;
            for(var i=0; i<body.FieldCount; i++)
            {
                ref readonly var part = ref body[i];
                if(part.FieldClass == DefFieldClass.FieldAssign)
                {
                    var assign = part.AsAssignment();
                    if(assign.Field == FieldKind.VEXVALID)
                        vc = (VexClass)assign.Value.Data;
                    else if(assign.Field == FieldKind.MAP)
                        number = (byte)assign.Value.Data;
                }
            }

            switch(vc)
            {
                case VexClass.VV1:
                    kind = ockind(ocindex((VexMapKind)number));
                break;
                case VexClass.XOPV:
                    kind = ockind(ocindex((XopMapKind)number));
                break;
                case VexClass.EVV:
                case VexClass.KVV:
                    kind = ockind(ocindex((EvexMapKind)number));
                break;
                default:
                    kind = ockind((OpCodeIndex)lmap(value));
                break;
            }

            return new XedOpCode(pattern, kind, value);
        }
    }
}