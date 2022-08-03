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
        public static ref short seek16i<T>(in T src, ulong count)
            => ref Add(ref As<T,short>(ref edit(src)), (int)count);
    }
}