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
        public static Process CurrentProcess
        {
            [MethodImpl(Options), Opaque(GetCurrentProcess)]
            get => Process.GetCurrentProcess();
        }
    }
}