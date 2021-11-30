//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ToolArg<T> : IToolArg<T>
    {
        public string ArgName {get;}

        public T ArgValue {get;}

        [MethodImpl(Inline)]
        public ToolArg(string name, T value)
        {
            ArgName = name;
            ArgValue = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator ToolArg(ToolArg<T> src)
            => new ToolArg(src.ArgName, src.ArgValue);
    }
}