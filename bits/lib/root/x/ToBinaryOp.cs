//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XTend
    {
        [MethodImpl(Inline)]
        public static BinaryOp<T> ToBinaryOp<T>(this System.Func<T,T,T> f)
            => new BinaryOp<T>(f);
    }
}