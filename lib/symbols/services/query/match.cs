//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static bit match(char a, char b)
            => a == b;

        [MethodImpl(Inline), Op]
        public static bit match(Pair<char> a, Pair<char> b)
            => match(a.Left, b.Left) && match(a.Right, b.Right);
    }
}