//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static CalcHosts;
    using static ApiClassKind;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory(BitClear), Closures(Integers)]
        public static VBitClear128<T> vbitclear<T>(N128 w)
            where T : unmanaged
                => default(VBitClear128<T>);

        [MethodImpl(Inline), Factory(BitClear), Closures(Integers)]
        public static VBitClear256<T> vbitclear<T>(N256 w)
            where T : unmanaged
                => default(VBitClear256<T>);
    }
}