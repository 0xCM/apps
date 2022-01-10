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
        public struct RuleCriterion<T> : IRuleCriterion<T>
            where T : unmanaged
        {
            public OperandKind Kind {get;}

            public RuleOperator Operator {get;}

            public T Value;

            [MethodImpl(Inline)]
            public RuleCriterion(OperandKind kind, RuleOperator op)
            {
                Kind = kind;
                Value = default;
                Operator = op;
            }

            public string Format()
            {
                if(Operator != 0)
                {
                    return string.Format("{0}{1}{2}", Symbols.expr(Kind), Operator, Value);
                }
                else
                {
                    return string.Format("{0}", Value);
                }
            }

            public override string ToString()
                => Format();

            T IRuleCriterion<T>.Value
                => Value;

        }
    }
}