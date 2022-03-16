//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;

    partial class XedRender
    {
        public static string format(in InstDefPart src)
        {
            var dst = EmptyString;
            var kind = src.PartKind;
            switch(kind)
            {
                case DefSegKind.HexLiteral:
                    dst = src.Map<Hex8,string>(kind, format);
                break;
                case DefSegKind.Bitfield:
                    dst = src.Map<BitfieldSeg,string>(kind, format);
                break;
                case DefSegKind.BitLiteral:
                    dst = src.Map<uint5,string>(kind, format3);
                break;
                case DefSegKind.Nonterm:
                    dst = src.Map<Nonterminal,string>(kind, format);
                break;
                case DefSegKind.FieldLiteral:
                    dst = src.Map<XedRules.FieldValue,string>(kind, format);
                break;
                case DefSegKind.FieldAssign:
                    dst = src.Map<FieldAssign,string>(kind, format);
                break;
                case DefSegKind.Constraint:
                    dst = src.Map<FieldConstraint,string>(kind, format);
                break;
                default:
                    Errors.Throw(kind.ToString());
                break;
            }

            return dst;
        }
    }
}