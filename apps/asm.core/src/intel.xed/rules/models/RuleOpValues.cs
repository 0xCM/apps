//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class RuleOpValues
        {
            readonly Dictionary<RuleOpName,RuleOpValue> Data;

            public RuleOpValues(Dictionary<RuleOpName,RuleOpValue> src)
            {
                Data = src;
            }

            public bool TryGetValue(RuleOpName key, out RuleOpValue value)
                => Data.TryGetValue(key, out value);

            public ICollection<RuleOpName> Keys
                => Data.Keys;

            public ICollection<RuleOpValue> Values
                => Data.Values;

            public RuleOpValue this[RuleOpName name]
            {
                get => Data[name];
                set => Data[name] = value;
            }

            public static implicit operator RuleOpValues(Dictionary<RuleOpName,RuleOpValue> src)
                => new RuleOpValues(src);
        }
    }
}