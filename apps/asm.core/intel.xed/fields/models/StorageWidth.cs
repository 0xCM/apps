//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly record struct StorageWidth : IComparable<StorageWidth>
        {
            public readonly byte Value;

            [MethodImpl(Inline)]
            public StorageWidth(byte value)
            {
                Value = value;
            }

            [MethodImpl(Inline)]
            public int CompareTo(StorageWidth src)
                => Value.CompareTo(src.Value);

            public string Format()
                => Value.ToString();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator StorageWidth(byte src)
                => new StorageWidth(src);

            [MethodImpl(Inline)]
            public static implicit operator byte(StorageWidth src)
                => src.Value;
        }

    }
}