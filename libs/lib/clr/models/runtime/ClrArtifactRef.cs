//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ClrArtifactRef : IExpr2
    {
        public readonly ClrArtifactKind Kind;

        public readonly CliToken Token;

        public readonly string Name;

        [MethodImpl(Inline)]
        public ClrArtifactRef(CliToken id, ClrArtifactKind kind, string name)
        {
            Token = id;
            Kind = kind;
            Name = name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Token.IsEmpty;
        }
        public string Format()
            => string.Format(RP.PSx3, Kind, Token, Name);

        public override string ToString()
            => Format();
    }
}