//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedRender
    {
        public static string format(in InstDefSeg src)
        {
            var dst = EmptyString;
            var kind = src.Kind;
            switch(kind)
            {
                case DefSegKind.HexLiteral:
                    dst = src.Map<Hex8,string>(kind, format);
                break;
                case DefSegKind.BitLiteral:
                    dst = src.Map<uint5,string>(kind, format3);
                break;
                case DefSegKind.Bitfield:
                    dst = src.Map<BitfieldSeg,string>(kind, format);
                break;
                case DefSegKind.Constraint:
                    dst = src.Map<FieldConstraint,string>(kind, format);
                break;
                case DefSegKind.FieldAssign:
                    dst = src.Map<FieldAssign,string>(kind, format);
                break;
                case DefSegKind.Nonterm:
                    dst = src.Map<NontermCall,string>(kind, format);
                break;
                case DefSegKind.FieldLiteral:
                    dst = src.Map<XedRules.FieldValue,string>(kind, format);
                break;
            }
            return dst;
        }
    }
}