//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct sys
    {
        public static Assembly EntryAssembly
        {
            [MethodImpl(Options), Op]
            get => Assembly.GetCallingAssembly();
        }
    }
}