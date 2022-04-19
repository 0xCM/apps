//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static ArrayUtil;

    partial class XArray
    {
        [MethodImpl(Inline)]
        public static T Single<T>(this T[] src)
            => single(src);
    }
}