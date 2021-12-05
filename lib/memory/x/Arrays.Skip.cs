//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Linq;

    using static Root;

    partial class XArray
    {
        [MethodImpl(Inline)]
        public static T[] Skip<T>(this T[] src, int count)
            => Enumerable.Skip(src, count).ToArray();
    }
}