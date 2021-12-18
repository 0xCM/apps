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
        // [MethodImpl(Inline)]
        // internal static S WithEndpoints<S,T>(this S src, T left, T right)
        //     where S : struct, IInterval<S,T>
        //     where T : unmanaged, IComparable<T>, IEquatable<T>
        //         => default(S).New(left, right, src.Kind);
    }
}