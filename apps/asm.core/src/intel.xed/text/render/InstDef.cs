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
                    dst = format(src.AsHexLit());
                break;
                case DefSegKind.Bitfield:
                    dst = format(src.AsBfSeg());
                break;
                case DefSegKind.BitLiteral:
                    dst = format5(src.AsB5());
                break;
                case DefSegKind.Nonterm:
                    dst = format(src.AsNonterminal());
                break;
                case DefSegKind.FieldLiteral:
                    dst = format(src.AsFieldLit());
                break;
                case DefSegKind.FieldAssign:
                    dst = format(src.AsAssign());
                break;
                case DefSegKind.Constraint:
                    dst = format(src.AsConstraint());
                break;
                default:
                    Errors.Throw(kind.ToString());
                break;
            }

            return dst;
        }
    }
}