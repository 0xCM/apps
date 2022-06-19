//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IClrArtifact : ITextual
    {
        /// <summary>
        /// The artifact metadata token
        /// </summary>
        CliToken Token {get;}

        /// <summary>
        /// The artifact name
        /// </summary>
        string Name {get;}

        /// <summary>
        /// The artifact classifier
        /// </summary>
        ClrArtifactKind Kind {get;}

        ClrArtifactRef Ref
            => new ClrArtifactRef(Token, Kind ,Name);

        string ITextual.Format()
            => Name;
    }

    [Free]
    public interface IClrArtifact<A> : IClrArtifact
        where A : struct, IClrArtifact<A>
    {

    }
}