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
    /// Specifies a kinded option
    /// </summary>
    public readonly struct CmdOptionSpec<K> : ICmdOptionSpec<K>
        where K : unmanaged
    {
        /// <summary>
        /// The option name
        /// </summary>
        public Name Name {get;}

        /// <summary>
        /// The option kind
        /// </summary>
        public K Kind {get;}

        /// <summary>
        /// A description for the option, if available
        /// </summary>
        public @string Description {get;}

        [MethodImpl(Inline)]
        public CmdOptionSpec(K kind)
        {
            Name = kind.ToString();
            Kind = kind;
            Description = EmptyString;
        }

        [MethodImpl(Inline)]
        public CmdOptionSpec(string name, K kind)
        {
            Name = name;
            Kind = kind;
            Description = EmptyString;
        }

        [MethodImpl(Inline)]
        public CmdOptionSpec(string name, K kind, string description)
        {
            Name = name;
            Kind = kind;
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
            => Name;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdOptionSpec(CmdOptionSpec<K> src)
            => new CmdOptionSpec(src.Name, src.Description);

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