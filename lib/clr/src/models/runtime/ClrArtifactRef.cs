//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ClrArtifactRef : ITextual
    {
        public ClrArtifactKind Kind {get;}

        public CliToken Token {get;}

        public Name Name {get;}

        [MethodImpl(Inline)]
        public ClrArtifactRef(CliToken id, ClrArtifactKind kind, Name name)
        {
            Token = id;
            Kind = kind;
            Name = name;
        }

        public string Format()
            => string.Format(RP.PSx3, Kind, Token, Name);

        public override string ToString()
            => Format();
    }
}