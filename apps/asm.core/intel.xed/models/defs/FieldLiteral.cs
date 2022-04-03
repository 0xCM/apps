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
            public static bool test(string src)
            {
                var result = false;
                switch(src)
                {
                    case "default":
                    case "else":
                    case "otherwise":
                    case "nothing":
                    case "null":
                    case "error":
                    case "@":
                        result = true;
                    break;
                }
                return result;
            }

            public static bool parse(string src, out FieldLiteral dst)
            {
                var result = true;
                var input = text.trim(src);
                dst = FieldLiteral.Empty;
                switch(input)
                {
                    case "default":
                        dst = FieldLiteral.Default;
                        break;
                    case "else":
                    case "otherwise":
                        dst = FieldLiteral.Branch;
                    break;
                    case "nothing":
                    case "null":
                        dst = FieldLiteral.Null;
                    break;
                    case "error":
                        dst = FieldLiteral.Error;
                    break;
                    case "@":
                        dst = FieldLiteral.Wildcard;
                    break;
                    default:
                        if(src.Length <= 8)
                            dst = FieldLiteral.Text(input);
                        else
                            result = false;
                    break;
                }

                return result;
            }

            public static FieldLiteral Wildcard => new FieldLiteral(K.Wildcard,"@");

            public static FieldLiteral Null => new FieldLiteral(K.Null, "null");

            public static FieldLiteral Default => new FieldLiteral(K.Default, "default");

            public static FieldLiteral Branch => new FieldLiteral(K.Default, "branch");

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
            public RuleCriterion ToCriterion()
                => XedRules.criterion(this);

            [MethodImpl(Inline)]
            public asci8 ToAsci()
                => (asci8)Data.A;

            [MethodImpl(Inline)]
            public bool Equals(FieldLiteral src)
                => Data.Equals(src.Data);

            public override int GetHashCode()
                => Data.GetHashCode();

            public override bool Equals(object src)
                => src is FieldLiteral x && Equals(x);

            public string Format()
                => ToAsci();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static bool operator ==(FieldLiteral a, FieldLiteral b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(FieldLiteral a, FieldLiteral b)
                => !a.Equals(b);

            public static FieldLiteral Empty => default;
        }
    }
}