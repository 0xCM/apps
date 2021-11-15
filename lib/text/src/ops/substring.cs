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
        public static string substring(string src, int start)
            => RP.substring(src, start);

        [MethodImpl(Inline), Op]
        public static string substring(string src, int start, int len)
            => RP.substring(src, start, len);
    }
}