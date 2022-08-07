//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial class Refs
    {
       [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe T* gptr<T>(in T src)
            where T : unmanaged
                => (T*)AsPointer(ref edit(src));
    }
}