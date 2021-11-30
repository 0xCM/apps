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
        public string ArgName {get;}

        public dynamic ArgValue {get;}

        [MethodImpl(Inline)]
        public ToolArg(string name, dynamic value)
        {
            ArgName = name;
            ArgValue = value;
        }
    }
}