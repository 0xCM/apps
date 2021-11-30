//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ToolInvocation
    {
        public ToolId Tool {get;}

        readonly Index<ToolArg> _Args;

        [MethodImpl(Inline)]
        public ToolInvocation(ToolId tool, ToolArg[] args)
        {
            Tool = tool;
            _Args = args;
        }

        public ReadOnlySpan<ToolArg> Args
        {
            [MethodImpl(Inline)]
            get => _Args;
        }
    }
}