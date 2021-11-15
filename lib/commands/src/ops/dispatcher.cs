//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial struct Cmd
    {
        [Op]
        public static CmdDispatcher dispatcher(object host, Func<string,CmdArgs,Outcome> fallback = null)
            => new CmdDispatcher(host, lookup(host), fallback);
    }
}