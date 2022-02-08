//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRecords;

    partial struct XedModels
    {
        public interface IRuleCriterion
        {
            XedOpKind Kind {get;}

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