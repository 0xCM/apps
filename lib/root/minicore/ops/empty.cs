//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct minicore
    {
        [MethodImpl(Inline)]
        public static T[] empty<T>()
            => Array.Empty<T>();

        [MethodImpl(Inline)]
        public static bool empty(string src)
            => string.IsNullOrEmpty(src);
    }
}