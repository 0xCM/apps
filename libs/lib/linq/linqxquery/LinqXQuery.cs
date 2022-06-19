//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost(ApiNames.LinqXQuery, true)]
    public partial class LinqXQuery
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        static T cast<T>(object src)
            => (T)src;
    }
}