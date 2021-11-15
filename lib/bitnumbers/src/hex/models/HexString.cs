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
    /// Defines a sequence of hex values
    /// </summary>
    public readonly ref struct HexString
    {
        public ReadOnlySpan<char> Data {get;}

        [MethodImpl(Inline)]
        public HexString(ReadOnlySpan<char> src)
        {
            Data = src;
        }

        public string Format()
            => text.format(Data);

        [MethodImpl(Inline)]
        public static implicit operator HexString(string src)
            => new HexString(src);

        [MethodImpl(Inline)]
        public static implicit operator HexString(ReadOnlySpan<char> src)
            => new HexString(src);
    }
}