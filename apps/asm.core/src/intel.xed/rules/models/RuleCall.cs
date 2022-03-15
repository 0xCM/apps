//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly struct RuleCall : IEquatable<RuleCall>
        {
            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly NameResolver Target;

            [MethodImpl(Inline)]
            public RuleCall(FieldKind field, RuleOperator op, NameResolver dst)
            {
                Field = field;
                Operator = op;
                Target = dst;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Target.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Target.IsNonEmpty;
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
        }
    }
}