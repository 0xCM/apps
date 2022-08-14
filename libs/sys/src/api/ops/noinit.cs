//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;
    using static System.Runtime.InteropServices.MemoryMarshal;

    partial class sys
    {
        [MethodImpl(Inline)]
        public static T noinit<T>(out T dst)
        {
            SkipInit(out dst);
            return dst;
        }
    }
}