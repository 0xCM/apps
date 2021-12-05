//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.IO;

    using static Root;
    using static core;
    using static Typed;

    partial struct Resources
    {
        [Op]
        internal static MemoryAddress fptr(MethodInfo src)
            => src.MethodHandle.GetFunctionPointer();

        [Op]
        internal static MemoryAddress jit(MethodInfo src)
        {
            sys.prepare(src.MethodHandle);
            return fptr(src);
        }

    }
}