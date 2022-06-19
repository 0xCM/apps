//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class Delegates
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Emitter<T> emitter<T>(System.Func<T> f)
            => new Emitter<T>(f);

        [MethodImpl(Inline)]
        public static Emitter<T,C> emitter<T,C>(System.Func<T> f)
            where T : unmanaged
            where C : unmanaged
                => new Emitter<T,C>(f);
    }
}