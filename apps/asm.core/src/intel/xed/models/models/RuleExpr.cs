//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        public struct RuleExpr
        {
            public RuleExprKind Kind;

            public TextBlock Premise;

            public TextBlock Consequent;

            [MethodImpl(Inline)]
            public RuleExpr(RuleExprKind kind, string premise, string consequent)
            {
                Kind = kind;
                Premise = premise;
                Consequent = consequent;
            }

            public string Format()
                => Kind == RuleExprKind.EncodeStep
                ? string.Format("{0} -> {1}", Premise, Consequent)
                : string.Format("{0} | {1}", Premise, Consequent);

            public override string ToString()
                => Format();
        }
    }
}