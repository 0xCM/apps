//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using api = TokenStrings;

    public readonly struct TokenString
    {
        public Index<char> Content {get;}

        public TokenString(char[] src)
        {
            Content = src;
        }

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => Content.View;
        }

        public uint TokenCount
        {
            [MethodImpl(Inline)]
            get => api.count(this);
        }
    }
}