//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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