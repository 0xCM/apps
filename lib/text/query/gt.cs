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
        public static bit gt(char c)
            => (char)AsciCode.Gt == c;

        [MethodImpl(Inline), Op]
        public static bit gt(AsciCode c)
            => AsciCode.Gt == c;
    }
}