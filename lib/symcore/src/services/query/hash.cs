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
        public static bit hash(byte src)
            => (C)src == C.Hash;

        [MethodImpl(Inline), Op]
        public static bit hash(char src)
            => src == (char)C.Hash;

        [MethodImpl(Inline), Op]
        public static bit hash(AsciSymbol src)
            => src == (char)C.Hash;
    }
}