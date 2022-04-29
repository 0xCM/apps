//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public interface ILogicOperand
        {
            RuleOperator Operator {get;}
        }

        public interface ILogicOperand<T> : ILogicOperand
            where T : unmanaged, ILogicValue
        {
            T Value {get;}
        }
    }
}