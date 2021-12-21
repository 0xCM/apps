//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct CharBlocks
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T hydrate<T>(StringAddress src, out T dst)
            where T : unmanaged, ICharBlock<T>
        {
            dst = default;
            var i=0u;
            src.Render(ref i, dst.Data);
            return ref dst;
        }
    }
}