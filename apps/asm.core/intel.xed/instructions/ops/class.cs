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
        public static InstFieldClass @class(InstFieldKind kind)
        {
            var dst = InstFieldClass.None;
            switch(kind)
            {
                case InstFieldKind.BitLiteral:
                case InstFieldKind.IntLiteral:
                case InstFieldKind.HexLiteral:
                    dst = InstFieldClass.Literal;
                break;
                case InstFieldKind.Expr:
                    dst = InstFieldClass.Expr;
                break;
                case InstFieldKind.Seg:
                    dst = InstFieldClass.Seg;
                break;
                case InstFieldKind.Nonterm:
                    dst = InstFieldClass.Nonterm;
                break;
            }
            return dst;
        }
    }
}