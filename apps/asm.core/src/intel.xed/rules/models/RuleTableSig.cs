//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RuleTableSig : IComparable<RuleTableSig>, IEquatable<RuleTableSig>
        {
            public readonly RuleTableKind Kind;

            public readonly @string Name;

            public readonly Hash32 Hash;

            [MethodImpl(Inline)]
            public RuleTableSig(RuleTableKind kind, string name)
            {
                Kind = kind;
                Name = name;
                Hash = (alg.hash.marvin(name) & 0b11111111_11111111_1111111_11111000) | ((uint)kind);
            }


            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Kind == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Kind != 0;
            }

            public override int GetHashCode()
                => Hash;

            public bool Equals(RuleTableSig src)
                => Kind == src.Kind && Name == src.Name;

            public override bool Equals(object src)
                => src is RuleTableSig x && Equals(x);

            public int CompareTo(RuleTableSig src)
            {
                var result = ((byte)Kind).CompareTo((byte)src.Kind);
                if(result == 0)
                    result = Name.CompareTo(src.Name);
                return result;
            }

            public string Format()
                => IsEmpty ? EmptyString : Name;

            public override string ToString()
                => Format();

            public static implicit operator RuleTableSig((RuleTableKind kind, string name) src)
                => new RuleTableSig(src.kind, src.name);

            public static RuleTableSig Empty => default;
        }
    }
}