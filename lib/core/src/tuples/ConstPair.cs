//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines const pair manipulation api
    /// </summary>
    [ApiHost]
    public class ConstPair
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        public static ConstPair<T> zero<T>(T z = default)
            => default;
    }
}