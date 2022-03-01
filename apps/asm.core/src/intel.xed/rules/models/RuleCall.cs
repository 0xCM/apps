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
            public readonly Identifier Source;

            public readonly Identifier Target;

            [MethodImpl(Inline)]
            public RuleCall(Identifier src, Identifier dst)
            {
                Source = src;
                Target = dst;
            }

            public string Format()
                => string.Format("{0} -> {1}", Source, Target);

            public override string ToString()
                => Format();

            public bool Equals(RuleCall src)
                => Target.Equals(src.Target) && Source.Equals(src.Source);

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
        }
    }
}