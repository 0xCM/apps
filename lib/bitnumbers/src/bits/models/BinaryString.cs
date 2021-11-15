//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a sequence of binary values
    /// </summary>
    public readonly ref struct BinaryString
    {
        public ReadOnlySpan<char> Data {get;}

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