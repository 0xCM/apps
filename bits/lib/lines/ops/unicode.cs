//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Lines
    {
        [MethodImpl(Inline), Op]
        public static UnicodeLine unicode(string src, uint number, uint offset, uint chars)
            => new UnicodeLine(number, offset, text.slice(src, offset, chars));
    }
}