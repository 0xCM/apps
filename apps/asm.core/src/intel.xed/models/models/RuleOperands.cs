//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-operand-storage.h/all-fields.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial struct XedModels
    {
        public class RuleOperands
        {
            readonly Dictionary<RuleOpName,RuleOperand> Data;

            public RuleOperands(Dictionary<RuleOpName,RuleOperand> src)
            {
                Data = src;
            }

            public bool TryGetValue(RuleOpName key, out RuleOperand value)
                => Data.TryGetValue(key, out value);

            public ICollection<RuleOpName> Keys
                => Data.Keys;

            public ICollection<RuleOperand> Values
                => Data.Values;

            public RuleOperand this[RuleOpName name]
            {
                get => Data[name];
                set => Data[name] = value;
            }

            public static implicit operator RuleOperands(Dictionary<RuleOpName,RuleOperand> src)
                => new RuleOperands(src);
        }
    }
}