//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
using System;

namespace Z0
{
    public readonly struct CharStringFormatter : ICharStringFormatter
    {
        public string Format(ReadOnlySpan<char> src)
            => new string(core.recover<char>(src));
    }
}