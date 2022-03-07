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
        public class DisasmOps
        {
            readonly Dictionary<RuleOpName,DisasmOp> Data;

            public DisasmOps(Dictionary<RuleOpName,DisasmOp> src)
            {
                Data = src;
            }

            public bool TryGetValue(RuleOpName key, out DisasmOp value)
                => Data.TryGetValue(key, out value);

            public ICollection<RuleOpName> Keys
                => Data.Keys;

            public ICollection<DisasmOp> Values
                => Data.Values;

            public DisasmOp this[RuleOpName name]
            {
                get => Data[name];
                set => Data[name] = value;
            }

            public static implicit operator DisasmOps(Dictionary<RuleOpName,DisasmOp> src)
                => new DisasmOps(src);
        }
    }
}