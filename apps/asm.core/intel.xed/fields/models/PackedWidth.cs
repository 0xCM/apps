//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly record struct PackedWidth : IComparable<PackedWidth>
        {
            public readonly byte Value;

            [MethodImpl(Inline)]
            public PackedWidth(byte value)
            {
                Value = value;
            }

            [MethodImpl(Inline)]
            public int CompareTo(PackedWidth src)
                => Value.CompareTo(src.Value);

            public string Format()
                => Value.ToString();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator PackedWidth(byte src)
                => new PackedWidth(src);

            [MethodImpl(Inline)]
            public static implicit operator byte(PackedWidth src)
                => src.Value;
        }
    }
}