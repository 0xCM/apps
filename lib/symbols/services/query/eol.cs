//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsciCode;

    using C = AsciCode;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static bit eol(byte a0, byte a1)
            => ((C)a0 == CR && (C)a1 == NL) || ((C)a1 == NL);

        [MethodImpl(Inline), Op]
        public static bit eol(char a, char b)
            => (cr(a) && nl(b)) || nl(b);

        [MethodImpl(Inline), Op]
        public static bit eol(AsciSymbol a0, AsciSymbol a1)
            => (a0 == CR && a1 == NL) || (a1 == NL);
    }
}