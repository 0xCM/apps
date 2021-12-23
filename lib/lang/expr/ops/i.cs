//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using Expr;

    partial struct expr
    {
        [MethodImpl(Inline), Op]
        public static iN<T> iN<T>(uint n, T value = default)
            where T : unmanaged
                => new iN<T>(n,value);
    }
}