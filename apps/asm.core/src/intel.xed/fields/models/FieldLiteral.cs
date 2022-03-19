//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using K = XedRules.FieldLiteralKind;

    partial class XedRules
    {
        public readonly struct FieldLiteral
        {
            public static FieldLiteral infer(string input)
            {
                var dst = FieldLiteral.Empty;
                if(input.Length > 8)
                        return dst;

                if(XedParsers.IsBinaryLiteral(input))
                    dst = Binary(input);
                else if(input == "else" || input == "default")
                    dst = Default;
                else if(input == "null")
                    dst = Null;
                else if(input == "error")
                    dst = Error;
                else if(input == "@")
                    dst = Wildcard;
                else
                    dst = Text(input);

                return dst;
            }

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

            public FieldLiteralKind LiteralKind
            {
                [MethodImpl(Inline)]
                get => (FieldLiteralKind)Data[15];
            }

            public CellDataKind DataKind
            {
                [MethodImpl(Inline)]
                get => (CellDataKind)Data[15];
            }

            FieldKind FieldKind
            {
                [MethodImpl(Inline)]
                get => (FieldKind)Data[14];
            }


            [MethodImpl(Inline)]
            public RuleCriterion ToCriterion(bool premise)
                => criterion(premise, FieldKind, (asci8)Data.A, DataKind);


            public string Format()
                => ToCriterion(false).Format();

            public override string ToString()
                => Format();

            public static FieldLiteral Empty => default;
        }
    }
}