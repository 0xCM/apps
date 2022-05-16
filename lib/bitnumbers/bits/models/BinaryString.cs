//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a sequence of binary values
    /// </summary>
    public readonly ref struct BinaryString
    {
        public readonly ReadOnlySpan<char> Data;

        [MethodImpl(Inline)]
        public BinaryString(ReadOnlySpan<char> src)
        {
            Data = src;
        }

        public string Format()
            => text.format(Data);

        [MethodImpl(Inline)]
        public static implicit operator BinaryString(string src)
            => new BinaryString(src);

        [MethodImpl(Inline)]
        public static implicit operator BinaryString(ReadOnlySpan<char> src)
            => new BinaryString(src);
    }
}