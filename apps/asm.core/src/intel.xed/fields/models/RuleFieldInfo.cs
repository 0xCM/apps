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
        public readonly struct RuleFieldInfo : IEquatable<RuleFieldInfo>, IComparable<RuleFieldInfo>
        {
            public readonly bool Premise;

            public readonly FieldKind Kind;

            [MethodImpl(Inline)]
            public RuleFieldInfo(bool premise, FieldKind kind)
            {
                Premise = premise;
                Kind = kind;
            }

            public override int GetHashCode()
                => ((int)u8(Premise) << 16) | (int)Kind;

            [MethodImpl(Inline)]
            public bool Equals(RuleFieldInfo src)
                => Premise == src.Premise && Kind == src.Kind;

            public override bool Equals(object src)
                => src is RuleFieldInfo x && Equals(x);

            public int CompareTo(RuleFieldInfo src)
            {
                var result = src.Premise.CompareTo(Premise);
                if(result == 0)
                    return ((byte)Kind).CompareTo((byte)src.Kind);
                return result;
            }

            public string Format()
                => XedRender.format(Kind);

            public override string ToString()
                => Format();

        }
    }
}