//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial struct XedModels
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