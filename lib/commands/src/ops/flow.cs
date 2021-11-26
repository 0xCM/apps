//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Cmd
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmdFlow<T> flow<T>(string actor, T src, T dst)
            => new CmdFlow<T>(actor,src,dst);
    }
}