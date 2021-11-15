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
    /// Defines a tool flag argument
    /// </summary>
    public readonly struct CmdFlagSpec
    {
        /// <summary>
        /// The flag name
        /// </summary>
        public string Name {get;}

        /// <summary>
        /// The flag description
        /// </summary>
        public string Description {get;}

        [MethodImpl(Inline)]
        public CmdFlagSpec(string name, string desc)
        {
            Name = name;
            Description = desc;
        }

        public string Format()
            => Cmd.format(this);

        public override string ToString()
            => Format();
    }
}