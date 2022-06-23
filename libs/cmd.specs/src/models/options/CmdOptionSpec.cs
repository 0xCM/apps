//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => core.hash(Name.Hash, core.hash(Description));
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
            => IsEmpty ? EmptyString : string.Format("{0,-32}:{1}", Name, Description);

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