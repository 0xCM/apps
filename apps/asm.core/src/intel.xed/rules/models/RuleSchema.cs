//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RuleSchema : IComparable<RuleSchema>
        {
            public readonly RuleSig Sig;

            public readonly Index<RuleCellSpec> Cols;

            [MethodImpl(Inline)]
            public RuleSchema(RuleSig sig, RuleCellSpec[] cols)
            {
                Sig = sig;
                Cols = cols;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Cols.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Cols.IsNonEmpty;
            }

            public int CompareTo(RuleSchema src)
                => Sig.CompareTo(src.Sig);

            public static RuleSchema Empty => new RuleSchema(RuleSig.Empty, sys.empty<RuleCellSpec>());
        }
    }
}