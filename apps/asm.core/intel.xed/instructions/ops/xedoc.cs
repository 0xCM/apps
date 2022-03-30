//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;

    partial class XedPatterns
    {
        public static Index<XedOpCode> xedoc(Index<InstPattern> src)
            => src.Map(x => x.Spec.OpCode).Sort();

        public static XedOpCode xedoc(InstPatternBody body)
        {
            var vc = VexClass.None;
            var number = z8;
            var value = ocvalue(body);
            var kind = OpCodeKind.None;
            for(var i=0; i<body.FieldCount; i++)
            {
                ref readonly var part = ref body[i];
                if(part.IsFieldExpr && part.FieldKind == FieldKind.VEXVALID)
                    vc = (VexClass)part.AsFieldExpr().Value;
                if(part.IsFieldExpr && part.FieldKind == FieldKind.MAP)
                    number = part.AsFieldExpr().Value;
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
                    kind = ockind((OpCodeIndex)basemap(value));
                break;
            }

            return new XedOpCode(kind, value);
        }
    }
}