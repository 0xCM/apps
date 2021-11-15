//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public static class XLiterals
    {
        [MethodImpl(Inline), Op]
        public static char ToChar(this SymNotKind src)
            => (char)src;

        [MethodImpl(Inline), Op]
        public static string Format(this SymNotKind src)
            => ((char)src).ToString();
    }
}