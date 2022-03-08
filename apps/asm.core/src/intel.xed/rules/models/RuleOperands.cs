//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class RuleOperands
        {
            readonly Dictionary<RuleOpName,RuleOp> Data;

            public RuleOperands(Dictionary<RuleOpName,RuleOp> src)
            {
                Data = src;
            }

            public bool TryGetValue(RuleOpName key, out RuleOp value)
                => Data.TryGetValue(key, out value);

            public ICollection<RuleOpName> Keys
                => Data.Keys;

            public ICollection<RuleOp> Values
                => Data.Values;

            public RuleOp this[RuleOpName name]
            {
                get => Data[name];
                set => Data[name] = value;
            }

            public static implicit operator RuleOperands(Dictionary<RuleOpName,RuleOp> src)
                => new RuleOperands(src);
        }
    }
}