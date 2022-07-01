//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ClrArtifactRef : ITextual
    {
        public ClrArtifactKind Kind {get;}

        public CliToken Token {get;}

        public NameOld Name {get;}

        [MethodImpl(Inline)]
        public ClrArtifactRef(CliToken id, ClrArtifactKind kind, NameOld name)
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