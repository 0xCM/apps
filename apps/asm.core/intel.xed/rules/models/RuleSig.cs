//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public readonly struct RuleSig : IComparable<RuleSig>, IEquatable<RuleSig>
        {
            public RuleSig(RuleTableKind kind, string name)
            {
                var data = ByteBlock4.Empty;
                if(XedParsers.parse(name, out RuleName rn))
                {
                    @as<RuleName>(data.First) = rn;
                    data[2] = (byte)kind;
                }
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(XedRules.RuleName), name));

                Data = data;
            }

            readonly ByteBlock4 Data;

            public ref readonly RuleName Name
            {
                [MethodImpl(Inline)]
                get => ref @as<RuleName>(Data.First);
            }

            public string ShortName
                => Name.ToString();

            public readonly RuleTableKind TableKind
            {
                [MethodImpl(Inline)]
                get => (RuleTableKind)Data[2];
            }

            public bool IsEncTable
            {
                [MethodImpl(Inline)]
                get => TableKind == RuleTableKind.Enc;
            }

            public bool IsDecTable
            {
                [MethodImpl(Inline)]
                get => TableKind == RuleTableKind.Dec;
            }

            public readonly bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => TableKind == 0;
            }

            public readonly bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => TableKind != 0;
            }

            public string Format()
                => string.Format("{0}.{1}", Name.ToString(), TableKind.ToString().ToUpper());

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public RuleSigKey ToKey()
                => new (Name,TableKind);

            public bool Equals(RuleSig src)
                => Name == src.Name && TableKind == src.TableKind;

            public override int GetHashCode()
                => ((ushort)TableKind << 7) | (ushort)Name;

            public override bool Equals(object src)
                => src is RuleSig x && Equals(x);

            public int CompareTo(RuleSig src)
            {
                var result = ShortName.CompareTo(src.ShortName);
                if(result == 0)
                    result = XedRules.cmp(TableKind, src.TableKind);
                return result;
            }

            [MethodImpl(Inline)]
            public static bool operator ==(RuleSig a, RuleSig b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(RuleSig a, RuleSig b)
                => !a.Equals(b);

            public static RuleSig Empty => default;
        }
    }
}