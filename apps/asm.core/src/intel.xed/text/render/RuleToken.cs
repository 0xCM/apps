//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    using TK = XedRules.RuleTokenKind;

    partial class XedRender
    {
        public static string format(NontermCall src)
            => string.Format("{0}()", format(src.Kind));

        public static string format(FieldConstraint src)
            => string.Format("{0}{1}{2}",
                    format(src.Field),
                    format(src.Kind),
                    literal(src.LiteralKind, src.Value)
                    );

        public static string format(in RuleToken src)
            => format(src, false);

        public static string format(in RuleToken src, bool showkind)
        {
            var kind = src.Kind;
            var value = EmptyString;
            switch(kind)
            {
                case TK.BinLit:
                    value = "0b" + src.AsBinaryLit().Format();
                break;
                case TK.DecLit:
                    value = src.AsDecimalLit().ToString();
                break;
                case TK.HexLit:
                    value = src.AsHexLit().Format(prespec:true,uppercase:true);
                break;
                case TK.Constraint:
                    value = format(src.AsConstraint());
                break;
                case TK.FieldSeg:
                    value = src.AsFieldSeg().Format();
                break;
                case TK.Macro:
                    value = format(src.AsMacro());
                break;
                case TK.Nonterm:
                    value = format(src.AsNonterm());
                break;
                case TK.Assignment:
                    value = format(src.AsAssignment());
                break;
            }

            return src.IsEmpty
                ? EmptyString
                : showkind
                ? string.Format("<{0}:{1}>", value, src.Kind)
                : value;
        }

        static string literal(FieldLiteralKind kind, byte src)
        {
            var val = EmptyString;
            switch(kind)
            {
                case FieldLiteralKind.BinaryLiteral:
                    val = "0b" + ((uint8b)(src)).Format();
                break;
                case FieldLiteralKind.DecimalLiteral:
                    val = src.ToString();
                break;
                case FieldLiteralKind.HexLiteral:
                    val = ((Hex8)(src)).Format(prespec:true, uppercase:true);
                break;
                default:
                    val = RP.Error;
                break;
            }
            return val;
        }
    }
}