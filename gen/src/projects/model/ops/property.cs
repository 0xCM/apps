//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct ProjectModel
    {
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static Property<T> property<T>(Name name, T value)
            => new Property<T>(name, value);
    }
}