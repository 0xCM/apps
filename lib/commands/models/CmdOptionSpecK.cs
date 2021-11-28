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
    /// Specifies a kinded option
    /// </summary>
    public readonly struct CmdOptionSpec<K> : IToolOptionSpec<K>
        where K : unmanaged
    {
        /// <summary>
        /// The option name
        /// </summary>
        public string Name {get;}

        /// <summary>
        /// The option kind
        /// </summary>
        public K Kind {get;}

        /// <summary>
        /// A description for the option, if available
        /// </summary>
        public string Description {get;}

        /// <summary>
        /// The option protocol
        /// </summary>
        public ArgProtocol Protocol {get;}

        [MethodImpl(Inline)]
        public CmdOptionSpec(K kind)
        {
            Name = kind.ToString();
            Kind = kind;
            Description = EmptyString;
            Protocol = new ArgProtocol(ArgPrefix.Default);
        }

        [MethodImpl(Inline)]
        public CmdOptionSpec(string name, K kind)
        {
            Name = name;
            Kind = kind;
            Description = EmptyString;
            Protocol = new ArgProtocol(ArgPrefix.Default);
        }

        [MethodImpl(Inline)]
        public CmdOptionSpec(string name, K kind, string purpose, ArgProtocol protocol)
        {
            Name = name;
            Kind = kind;
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
            => Name;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdOptionSpec(CmdOptionSpec<K> src)
            => new CmdOptionSpec(src.Name, src.Description, src.Protocol);

        /// <summary>
        /// Specifies the empty option
        /// </summary>
        public static CmdOptionSpec<K> Empty
        {
            [MethodImpl(Inline)]
            get => new CmdOptionSpec<K>(EmptyString, default(K));
        }
    }
}