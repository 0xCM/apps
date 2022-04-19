//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    partial struct sys
    {
        /// <summary>
        /// The handle for the current process
        /// </summary>
        public static IntPtr CurrentProcessHandle
        {
            [MethodImpl(Options), Op]
            get => proxy.CurrentProcessHandle;
        }
    }
}