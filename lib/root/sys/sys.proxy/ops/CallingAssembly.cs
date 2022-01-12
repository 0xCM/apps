//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static ApiOpaqueClass;

    partial struct proxy
    {
        public static Assembly CallingAssembly
        {
            [MethodImpl(Options), Opaque(GetCallingAssembly)]
            get => Assembly.GetCallingAssembly();
        }
    }
}