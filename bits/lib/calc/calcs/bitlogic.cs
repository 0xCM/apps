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

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory, Closures(Integers)]
        public static VBitLogic128<T> vbitlogic<T>(N128 w)
            where T : unmanaged
                => default(VBitLogic128<T>);

        [MethodImpl(Inline), Factory, Closures(Integers)]
        public static VBitLogic256<T> vbitlogic<T>(N256 w)
            where T : unmanaged
                => default(VBitLogic256<T>);
    }
}