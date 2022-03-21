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
            readonly Dictionary<OpName,DisasmOp> Data;

            public DisasmOps(Dictionary<OpName,DisasmOp> src)
            {
                Data = src;
            }

            public bool TryGetValue(OpName key, out DisasmOp value)
                => Data.TryGetValue(key, out value);

            public ICollection<OpName> Keys
                => Data.Keys;

            public ICollection<DisasmOp> Values
                => Data.Values;

            public DisasmOp this[OpName name]
            {
                get => Data[name];
                set => Data[name] = value;
            }

            public static implicit operator DisasmOps(Dictionary<OpName,DisasmOp> src)
                => new DisasmOps(src);
        }
    }
}