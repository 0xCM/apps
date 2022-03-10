//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RuleCall : IEquatable<RuleCall>
        {
            public readonly NameResolver Target;

            [MethodImpl(Inline)]
            public RuleCall(NameResolver dst)
            {
                Target = dst;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public bool Equals(RuleCall src)
                => Target.Equals(src.Target);

            public override bool Equals(object src)
                => src is RuleCall x && Equals(x);

            public override int GetHashCode()
                => (int)alg.hash.marvin(Format());

            [MethodImpl(Inline)]
            public static bool operator ==(RuleCall a, RuleCall b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(RuleCall a, RuleCall b)
                => !a.Equals(b);

            [MethodImpl(Inline)]
            public static implicit operator RuleCall(NameResolver src)
                => new RuleCall(src);
        }
    }
}