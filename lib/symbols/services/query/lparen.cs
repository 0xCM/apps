//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using C = AsciCode;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static bit lparen(C c)
            => c == C.LParen;

        [MethodImpl(Inline), Op]
        public static bit lparen(char c)
            => c == (char)C.LParen;
    }
}