//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class OpValues
        {
            readonly Dictionary<OpName,OpValue> Data;

            public OpValues(Dictionary<OpName,OpValue> src)
            {
                Data = src;
            }

            public bool TryGetValue(OpName key, out OpValue value)
                => Data.TryGetValue(key, out value);

            public ICollection<OpName> Keys
                => Data.Keys;

            public ICollection<OpValue> Values
                => Data.Values;

            public OpValue this[OpName name]
            {
                get => Data[name];
                set => Data[name] = value;
            }

            public static implicit operator OpValues(Dictionary<OpName,OpValue> src)
                => new OpValues(src);
        }
    }
}