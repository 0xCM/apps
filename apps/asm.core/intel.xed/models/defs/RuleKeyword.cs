//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using KW = XedRules.RuleKeyWordKind;

    partial class XedRules
    {
        public readonly struct RuleKeyword
        {
            public static RuleKeyword from(RuleKeyWordKind kind)
                => kind switch
                {
                    KW.Else => Else,
                    KW.Default => Default,
                    KW.Error => Error,
                    KW.Null => Null,
                    KW.Wildcard => Wildcard,
                    _ => RuleKeyword.Empty
                };

            public static RuleKeyword Wildcard => new RuleKeyword(KW.Wildcard, "@");

            public static RuleKeyword Null => new RuleKeyword(KW.Null, "null");

            public static RuleKeyword Default => new RuleKeyword(KW.Default, "default");

            public static RuleKeyword Else => new RuleKeyword(KW.Else, "else");

            public static RuleKeyword Error => new RuleKeyword(KW.Error, "error");

            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            RuleKeyword(RuleKeyWordKind kind, asci8 src)
            {
                var data = ByteBlock16.Empty;
                data = (ulong)src;
                data[15] = (byte)kind;
                Data = data;
            }

            public ref readonly RuleKeyWordKind KeywordKind
            {
                [MethodImpl(Inline)]
                get => ref core.@as<RuleKeyWordKind>(Data[15]);
            }

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