//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Hex
    {
        [MethodImpl(Inline)]
        public static char delimiter(string src)
            => text.index(src,Chars.Comma) > 0 ? Chars.Comma : Chars.Space;
    }
}