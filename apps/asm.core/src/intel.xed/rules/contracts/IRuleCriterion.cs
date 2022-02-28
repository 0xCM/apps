//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        public interface IRuleCriterion
        {
            FieldKind Kind {get;}

            RuleOperator Operator {get;}

            dynamic Value {get;}

        }

        public interface IRuleCriterion<T> : IRuleCriterion
            where T : unmanaged
        {
            new T Value {get;}

            dynamic IRuleCriterion.Value
                => Value;
        }
    }
}