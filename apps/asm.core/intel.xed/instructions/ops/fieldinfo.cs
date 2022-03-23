//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedPatterns
    {
        [Op]
        public static InstDefFieldInfo fieldinfo(InstPattern pattern, InstDefField src, byte index)
        {
            var dst = InstDefFieldInfo.Empty;
            dst.InstId = pattern.InstId;
            dst.PatternId = pattern.PatternId;
            dst.Index = index;
            dst.FieldClass = src.Class;
            switch(src.Class)
            {
                case DefFieldClass.Bitfield:
                    dst.BitfieldSeg = src.AsBfSeg();
                break;
                case DefFieldClass.BitLiteral:
                    dst.BitLiteral = src.AsBitLit();
                break;
                case DefFieldClass.Constraint:
                    dst.Constraint = src.AsConstraint();
                break;
                case DefFieldClass.FieldAssign:
                    dst.Assignment = src.AsAssignment();
                break;
                case DefFieldClass.FieldLiteral:
                    dst.FieldLiteral = src.AsFieldLit();
                break;
                case DefFieldClass.HexLiteral:
                    dst.HexLiteral = src.AsHexLit();
                break;
                case DefFieldClass.IntLiteral:
                    dst.IntLiteral = src.AsIntLit();
                break;
                case DefFieldClass.Nonterm:
                    dst.Nonterminal = src.AsNonterminal();
                break;
            }

            return dst;
        }
    }
}