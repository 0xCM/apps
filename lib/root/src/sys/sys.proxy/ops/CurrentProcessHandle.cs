//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;
    using System.Diagnostics;

    using static ApiOpaqueClass;

    partial struct proxy
    {
        /// <summary>
        /// The handle for the current process
        /// </summary>
        public static IntPtr CurrentProcessHandle
        {
            [MethodImpl(Options), Opaque(GetCurrentProcessHandle)]
            get => Process.GetCurrentProcess().Handle;
        }
    }
}