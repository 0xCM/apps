//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedOpCodes
    {
        public static XedOpCode opcode(in InstFields src)
        {
            var vc = VexClass.None;
            var number = z8;
            var ocv = value(src);
            var ock = OpCodeKind.None;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var part = ref src[i];
                if(part.IsFieldExpr && part.FieldKind == FieldKind.VEXVALID)
                    vc = (VexClass)part.ToFieldExpr().Value;
                if(part.IsFieldExpr && part.FieldKind == FieldKind.MAP)
                    number = part.ToFieldExpr().Value;
            }

            switch(vc)
            {
                case VexClass.VV1:
                    ock = kind(index((VexMapKind)number));
                break;
                case VexClass.XOPV:
                    ock = kind(index((XopMapKind)number));
                break;
                case VexClass.EVV:
                case VexClass.KVV:
                    ock = kind(index((EvexMapKind)number));
                break;
                default:
                    ock = kind((OpCodeIndex)basemap(ocv));
                break;
            }

            return new XedOpCode(XedFields.mode(src), ock, ocv);
        }
    }
}