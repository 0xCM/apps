//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RuleTableSpec : IComparable<RuleTableSpec>
        {
            public readonly RuleSig Sig;

            public readonly Index<StatementSpec> Statements;

            [MethodImpl(Inline)]
            public RuleTableSpec(in RuleSig sig, StatementSpec[] statements)
            {
                Require.invariant(sig.IsNonEmpty);
                Sig = sig;
                Statements = statements;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public int CompareTo(RuleTableSpec src)
                => Sig.CompareTo(src.Sig);
        }
    }
}