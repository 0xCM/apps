//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using KW = XedRules.RuleKeyWordKind;
    using CK = XedRules.CellRole;

    partial class XedRules
    {
        public readonly struct RuleKeyword
        {
            public static RuleKeyword from(RuleKeyWordKind kind)
                => kind switch
                {
                    KW.Branch => Branch,
                    KW.Default => Default,
                    KW.Error => Error,
                    KW.Null => Null,
                    KW.Wildcard => Wildcard,
                    _ => RuleKeyword.Empty
                };

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
                    case "otherwise":
                        dst = RuleKeyword.Branch;
                    break;
                    case "nothing":
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

            public static RuleKeyword Wildcard => new RuleKeyword(KW.Wildcard, CK.Wildcard, "@");

            public static RuleKeyword Null => new RuleKeyword(KW.Null, CK.Null, "null");

            public static RuleKeyword Default => new RuleKeyword(KW.Default, CK.Default, "default");

            public static RuleKeyword Branch => new RuleKeyword(KW.Branch, CK.Branch, "branch");

            public static RuleKeyword Error => new RuleKeyword(KW.Error, CK.Error, "error");

            public static RuleKeyword Text(asci8 src) => new RuleKeyword(KW.None, CK.None, src);

            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            RuleKeyword(RuleKeyWordKind kind, CellRole ck, asci8 src)
            {
                var data = ByteBlock16.Empty;
                data = (ulong)src;
                data[14] = (byte)ck;
                data[15] = (byte)kind;
                Data = data;
            }

            public ref readonly CellRole CellRole
            {
                [MethodImpl(Inline)]
                get => ref core.@as<CellRole>(Data[14]);
            }

            public ref readonly RuleKeyWordKind KeywordKind
            {
                [MethodImpl(Inline)]
                get => ref core.@as<RuleKeyWordKind>(Data[15]);
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
                => ToAsci().Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static bool operator ==(RuleKeyword a, RuleKeyword b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(RuleKeyword a, RuleKeyword b)
                => !a.Equals(b);

            [MethodImpl(Inline)]
            public static explicit operator byte(RuleKeyword src)
                => (byte)src.KeywordKind;

            [MethodImpl(Inline)]
            public static explicit operator asci8(RuleKeyword src)
                => src.ToAsci();

            public static RuleKeyword Empty => default;
        }
    }
}