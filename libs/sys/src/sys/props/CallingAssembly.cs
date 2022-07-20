//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct sys
    {
        public static Assembly CallingAssembly
        {
            [MethodImpl(Options), Op]
            get => Assembly.GetEntryAssembly();
        }
    }
}