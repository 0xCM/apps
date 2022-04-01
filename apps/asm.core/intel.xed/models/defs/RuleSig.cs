//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RuleSig : IComparable<RuleSig>, IEquatable<RuleSig>
        {
            public readonly RuleTableKind TableKind;

            public readonly Hash32 Hash;

            readonly NameResolver _Name;

            [MethodImpl(Inline)]
            public RuleSig(RuleTableKind kind, string name)
            {
                TableKind = kind;
                Hash = (alg.hash.marvin(name) & 0b11111111_11111111_1111111_11111000) | ((uint)kind);
                _Name = NameResolvers.Instance.Create(name);
            }

            public readonly string Name
            {
                [MethodImpl(Inline)]
                get => _Name.Format();
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => TableKind == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => TableKind != 0;
            }

            public bool IsEncRule
            {
                [MethodImpl(Inline)]
                get => TableKind == RuleTableKind.Enc;
            }

            public bool IsDecRule
            {
                [MethodImpl(Inline)]
                get => TableKind == RuleTableKind.Dec;
            }

            public bool IsEncDecRule
            {
                [MethodImpl(Inline)]
                get => TableKind == RuleTableKind.EncDec;
            }


            public override int GetHashCode()
                => Hash;

            public bool Equals(RuleSig src)
                => TableKind == src.TableKind && Name == src.Name;

            public override bool Equals(object src)
                => src is RuleSig x && Equals(x);

            public int CompareTo(RuleSig src)
            {
                var result = Name.CompareTo(src.Name);
                if(result == 0)
                    result = XedRules.cmp(TableKind, src.TableKind);
                return result;
            }

            public string Format()
                => IsEmpty ? EmptyString : Name;

            public override string ToString()
                => Format();

            public static RuleSig Empty => default;
        }
    }
}