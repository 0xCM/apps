//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static bit lt(char c)
            => (char)AsciCode.Lt == c;

        [MethodImpl(Inline), Op]
        public static bit lt(AsciCode c)
            => AsciCode.Lt == c;
    }
}