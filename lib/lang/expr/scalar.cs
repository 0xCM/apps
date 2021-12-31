//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct expr
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static scalar<T> scalar<T>(T src, BitWidth content = default)
            where T : unmanaged, IEquatable<T>
                => new scalar<T>(src,content);
    }
}