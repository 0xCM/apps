//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = XedRules.RuleKeyWordKind;

    partial class XedRules
    {
        public readonly struct RuleKeyword
        {
            public static bool parse(string src, out RuleKeyword dst)
            {
                var result = true;
                var input = text.trim(src);
                dst = RuleKeyword.Empty;
                switch(input)
                {
                    case "default":
                        dst = RuleKeyword.Default;
                        break;
                    case "else":
                    case "otherwise":
                        dst = RuleKeyword.Branch;
                    break;
                    case "nothing":
                    case "null":
                        dst = RuleKeyword.Null;
                    break;
                    case "error":
                        dst = RuleKeyword.Error;
                    break;
                    case "@":
                        dst = RuleKeyword.Wildcard;
                    break;
                    default:
                        if(src.Length <= 8)
                            dst = RuleKeyword.Text(input);
                        else
                            result = false;
                    break;
                }

                return result;
            }

            public static RuleKeyword Wildcard => new RuleKeyword(K.Wildcard,"@");

            public static RuleKeyword Null => new RuleKeyword(K.Null, "null");

            public static RuleKeyword Default => new RuleKeyword(K.Default, "default");

            public static RuleKeyword Branch => new RuleKeyword(K.Default, "branch");

            public static RuleKeyword Error => new RuleKeyword(K.Error,"error");

            public static RuleKeyword Text(asci8 src) => new RuleKeyword(K.Text, src);

            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            RuleKeyword(RuleKeyWordKind kind, asci8 src)
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
            public bool Equals(RuleKeyword src)
                => Data.Equals(src.Data);

            public override int GetHashCode()
                => Data.GetHashCode();

            public override bool Equals(object src)
                => src is RuleKeyword x && Equals(x);

            public string Format()
                => ToAsci();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static bool operator ==(RuleKeyword a, RuleKeyword b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(RuleKeyword a, RuleKeyword b)
                => !a.Equals(b);

            public static RuleKeyword Empty => default;
        }
    }
}