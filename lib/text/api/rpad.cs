//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class text
    {
        [MethodImpl(Inline), Op]
        public static string rpad(string src, int width, char c = Space)
            => src.PadRight(width, c);
    }
}