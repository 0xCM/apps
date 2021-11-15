//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines the usage syntax of a command or tool
    /// </summary>
    public readonly struct CmdUsage : ITextual, IContented<string>
    {
        public string Content {get;}

        [MethodImpl(Inline)]
        public CmdUsage(string content)
            => Content = content;

        [MethodImpl(Inline)]
        public string Format()
            => Content;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdUsage(string src)
            => new CmdUsage(src);

        [MethodImpl(Inline)]
        public static implicit operator string(CmdUsage src)
            => src.Content;
    }
}