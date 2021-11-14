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
        public Label ToolName {get;}

        readonly Index<ToolArg> _Args;

        [MethodImpl(Inline)]
        public ToolInvocation(Label name, ToolArg[] args)
        {
            ToolName = name;
            _Args = args;
        }

        public ReadOnlySpan<ToolArg> Args
        {
            [MethodImpl(Inline)]
            get => _Args;
        }
    }
}