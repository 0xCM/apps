//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Diagnostics;

    partial struct sys
    {
        public static Process CurrentProcess
        {
            [MethodImpl(Options), Op]
            get => proxy.CurrentProcess;
        }
    }
}