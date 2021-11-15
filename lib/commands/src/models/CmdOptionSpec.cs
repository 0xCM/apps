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
    public readonly struct CmdOptionSpec : IToolOptionSpec
    {
        /// <summary>
        /// The option name
        /// </summary>
        public string Name {get;}

        /// <summary>
        /// The option's use
        /// </summary>
        public string Description {get;}

        /// <summary>
        /// The option protocol
        /// </summary>
        public ArgProtocol Protocol {get;}

        [MethodImpl(Inline)]
        public CmdOptionSpec(string name)
        {
            Name = name;
            Description = EmptyString;
            Protocol = new ArgProtocol(ArgPrefix.Default);
        }

        [MethodImpl(Inline)]
        public CmdOptionSpec(string name, string purpose)
        {
            Name = name;
            Description = purpose;
            Protocol = new ArgProtocol(ArgPrefix.Default);
        }

        [MethodImpl(Inline)]
        public CmdOptionSpec(string name, string purpose, ArgProtocol protocol)
        {
            Name = name;
            Description = purpose;
            Protocol = protocol;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => empty(Name);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(Name);
        }

        public bool IsAnonymous
        {
            [MethodImpl(Inline)]
            get => empty(Name);
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