//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = XedRules.FieldLiteralKind;

    partial class XedRules
    {
        public readonly struct FieldLiteral
        {
            public static FieldLiteral Wildcard => new FieldLiteral(K.Wildcard,"@");

            public static FieldLiteral Null => new FieldLiteral(K.Null, "null");

            public static FieldLiteral Default => new FieldLiteral(K.Default, "default");

            public static FieldLiteral Binary(asci8 src) => new FieldLiteral(K.BinaryLiteral,src);

            public static FieldLiteral Error => new FieldLiteral(FieldKind.ERROR, K.Error,"error");

            public static FieldLiteral Text(asci8 src) => new FieldLiteral(K.Text, src);

            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            FieldLiteral(FieldKind fk, FieldLiteralKind lk, asci8 src)
            {
                var data = ByteBlock16.Empty;
                data = (ulong)src;
                data[14] = (byte)fk;
                data[15] = (byte)lk;
                Data = data;
            }

            [MethodImpl(Inline)]
            FieldLiteral(FieldLiteralKind kind, asci8 src)
            {
                var data = ByteBlock16.Empty;
                data = (ulong)src;
                data[15] = (byte)kind;
                Data = data;
            }

            [MethodImpl(Inline)]
            public RuleCriterion ToCriterion(bool premise)
                => XedRules.criterion(premise, this);

            public asci8 ToAsci()
                => (asci8)Data.A;

            public string Format()
                => ToAsci();

            public override string ToString()
                => Format();

            public static FieldLiteral Empty => default;
        }
    }
}