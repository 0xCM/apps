//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    /// <summary>
    /// Defines a command option
    /// </summary>
    public readonly struct CmdOptionSpec : ICmdOptionSpec
    {
        /// <summary>
        /// The option name
        /// </summary>
        public Name Name {get;}

        /// <summary>
        /// The option's use
        /// </summary>
        public @string Description {get;}

        [MethodImpl(Inline)]
        public CmdOptionSpec(string name)
        {
            Name = name;
            Description = EmptyString;
        }

        [MethodImpl(Inline)]
        public CmdOptionSpec(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Cmd.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdOptionSpec(string src)
            => new CmdOptionSpec(src);

        public static CmdOptionSpec Empty
        {
            [MethodImpl(Inline)]
            get => new CmdOptionSpec(EmptyString);
        }
    }
}