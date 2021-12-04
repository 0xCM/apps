//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ToolInvocation
    {
        public ToolId Tool {get;}

        public CmdArgs Args {get;}

        [MethodImpl(Inline)]
        public ToolInvocation(ToolId tool, CmdArg[] args)
        {
            Tool = tool;
            Args = args;
        }
    }
}