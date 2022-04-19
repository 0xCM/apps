//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    unsafe partial struct memory
    {
        /// <summary>
        /// Deallocates a native allocation
        /// </summary>
        /// <param name="handle">The allocation handle</param>
        [MethodImpl(Inline), Op]
        internal static void release(in NativeBuffer src)
            => Marshal.FreeHGlobal(src.Handle);

        /// <summary>
        /// Deallocates a native allocation
        /// </summary>
        /// <param name="handle">The allocation handle</param>
        [MethodImpl(Inline), Op]
        internal static void release<T>(in NativeBuffer<T> src)
            where T : unmanaged
                => Marshal.FreeHGlobal(src.Handle);
    }
}