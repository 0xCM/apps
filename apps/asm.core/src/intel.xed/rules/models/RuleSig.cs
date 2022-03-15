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

            public readonly RuleClass Class;

            public readonly @string Name;

            public readonly Hash32 Hash;

            [MethodImpl(Inline)]
            public RuleSig(RuleTableKind kind, RuleClass @class, string name)
            {
                TableKind = kind;
                Class = @class;
                Name = name;
                Hash = (alg.hash.marvin(name) & 0b11111111_11111111_1111111_11111000) | ((uint)kind);
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

            public override int GetHashCode()
                => Hash;

            public bool Equals(RuleSig src)
                => TableKind == src.TableKind && Name == src.Name;

            public override bool Equals(object src)
                => src is RuleSig x && Equals(x);

            public int CompareTo(RuleSig src)
            {
                var result = ((byte)TableKind).CompareTo((byte)src.TableKind);
                if(result == 0)
                    result = Name.CompareTo(src.Name);
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