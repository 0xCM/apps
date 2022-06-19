//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Cmd
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmdJob<T> job<T>(string name, T spec)
            where T : struct
                => new CmdJob<T>(name, spec);
    }
}