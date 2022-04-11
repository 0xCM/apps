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
    using static XedPatterns;

    partial class XedFields
    {
        public static XedOpCode opcode(in InstFields src)
        {
            var vc = VexClass.None;
            var number = z8;
            var value = ocvalue(src);
            var kind = OpCodeKind.None;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var part = ref src[i];
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

            return new XedOpCode(XedFields.mode(src), kind, value);
        }

    }

}