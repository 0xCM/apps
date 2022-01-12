//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public readonly struct AsciStringFormatter : IAsciStringFormatter
    {
        public string Format(ReadOnlySpan<AsciCode> src)
            => src.Format();
    }
}