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
        public readonly struct RuleCriterion : IRuleCriterion
        {
            public OpKind Kind {get;}

            public RuleOperator Operator {get;}

            public dynamic Value {get;}

            [MethodImpl(Inline)]
            public RuleCriterion(OpKind kind, RuleOperator @op,  dynamic value)
            {
                Kind = kind;
                Operator = @op;
                Value = value;
            }

            public string Format()
            {
                if(Operator != 0)
                    return string.Format("{0}{1}{2}", Symbols.expr(Kind), Symbols.expr(Operator), Value);
                else
                    return string.Format("{0}", Value);
            }

            public override string ToString()
                => Format();
        }
    }
}