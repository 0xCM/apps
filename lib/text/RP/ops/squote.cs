//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RP
    {
        [MethodImpl(Inline), Op]
        public static string squote(object src)
            => enclose(src, CharText.SQuote);
    }
}