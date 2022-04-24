//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        partial struct CellParser
        {
            public static bool IsEq(string src)
                => !src.Contains("!=") && src.Contains("=");

            public static bool IsNeq(string src)
                => src.Contains("!=");

            public static bool IsImpl(string src)
                => src.Contains("=>");

            public static bool IsExpr(string src)
                => IsEq(src) || IsNeq(src);

            static bool IsNonTerm(string src)
                => XedParsers.IsNonterm(src);

            public static bool IsSeg(string src)
            {
                var i = text.index(src, Chars.LBracket);
                var j = text.index(src, Chars.RBracket);
                return i> 0 && j > i;
            }

            public static bool expr(string src, out CellExpr dst)
            {
                dst = CellExpr.Empty;
                Require.invariant(IsExpr(src));

                var i = text.index(src, "!=");
                var j = text.index(src, "=");
                var right = EmptyString;
                var left = EmptyString;
                var fv = CellValue.Empty;
                var fk = FieldKind.INVALID;
                RuleOperator op = OperatorKind.None;
                if(i > 0)
                {
                    right = text.right(src, i + 1);
                    op = OperatorKind.Neq;
                    left = text.left(src,i);
                }
                else if (j>0)
                {
                    right = text.right(src, j);
                    op = OperatorKind.Eq;
                    left = text.left(src,j);
                }

                Require.nonempty(left);
                Require.nonempty(right);
                if(IsSeg(left))
                {
                    var k = text.index(left, Chars.LBracket);
                    var q = text.index(left, Chars.RBracket);
                    var ft = text.inside(left, k, q);
                    left = text.left(left, k);
                    XedParsers.parse(left, out fk);
                    Require.nonzero(fk);
                    var type = InstSegTypes.type(ft);
                    if(type.IsEmpty)
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(InstSegType), ft));

                    dst = new CellExpr(op, new CellValue(fk, type));
                }
                else if(IsNonTerm(right))
                {
                    XedParsers.parse(left, out fk);
                    var k = text.index(right, Chars.LParen);
                    var name = text.left(right,k);
                    var result = Enum.TryParse(name, out RuleName rule);
                    if(!result)
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleName), name));
                    dst = new CellExpr(op, new CellValue(fk, rule));
                }
                else
                {
                    XedParsers.parse(left, out fk);
                    Require.nonzero(fk);
                    var result = parse(fk, right, out fv);
                    if(!result)
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(CellExpr), src));
                    dst = new CellExpr(op, fv);
                }

                return true;
            }
        }
    }
}