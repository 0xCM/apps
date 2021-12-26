//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    partial struct Seq
    {
       public static NamedSeq<T> named<T>(Name name, params T[] src)
            where T : IEquatable<T>
                => new NamedSeq<T>(name, src);
    }
}