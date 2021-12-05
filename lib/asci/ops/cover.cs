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

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciSymbol> cover(in asci2 src)
            => recover<AsciSymbol>(core.bytes(src));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciSymbol> cover(in asci4 src)
            => recover<AsciSymbol>(core.bytes(src));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciSymbol> cover(in asci8 src)
            => recover<AsciSymbol>(core.bytes(src));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciSymbol> cover(in asci16 src)
            => recover<AsciSymbol>(core.bytes(src));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciSymbol> cover(in asci32 src)
            => recover<AsciSymbol>(core.bytes(src));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciSymbol> cover(in asci64 src)
            => recover<AsciSymbol>(core.bytes(src));
    }
}