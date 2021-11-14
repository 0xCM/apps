//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ToolArg : IToolArg
    {
        public Label ArgName {get;}

        public dynamic ArgValue {get;}

        [MethodImpl(Inline)]
        public ToolArg(Label name, dynamic value)
        {
            ArgName = name;
            ArgValue = value;
        }
    }
}