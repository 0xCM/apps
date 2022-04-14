//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [DataWidth(4,8)]
        public readonly struct RuleOperator : IComparable<RuleOperator>, IEquatable<RuleOperator>
        {
            public static RuleOperator None => OperatorKind.None;

            public static RuleOperator Eq => OperatorKind.Eq;

            public static RuleOperator Neq => OperatorKind.Neq;

            public static RuleOperator Impl => OperatorKind.Impl;

            public static RuleOperator And => OperatorKind.And;

            public readonly OperatorKind Kind;

            [MethodImpl(Inline)]
            public RuleOperator(OperatorKind kind)
            {
                Kind = kind;
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
                => (byte)Kind;

            public string Format()
                => XedRender.format(Kind);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public bool Equals(RuleOperator src)
                => Kind== src.Kind;

            public override bool Equals(object src)
                => src is RuleOperator x && Equals(x);

            [MethodImpl(Inline)]
            public int CompareTo(RuleOperator src)
                => XedRules.cmp(Kind,src.Kind);

            [MethodImpl(Inline)]
            public static implicit operator RuleOperator(OperatorKind kind)
                =>new RuleOperator(kind);

            [MethodImpl(Inline)]
            public static implicit operator OperatorKind(RuleOperator src)
                => src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator byte(RuleOperator src)
                => (byte)src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator RuleOperator(byte src)
                => new RuleOperator((OperatorKind)src);

            [MethodImpl(Inline)]
            public static bool operator==(RuleOperator a, RuleOperator b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator!=(RuleOperator a, RuleOperator b)
                => !a.Equals(b);
        }
    }
}