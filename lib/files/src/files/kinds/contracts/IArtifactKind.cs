//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IArtifactKind : ITextual
    {
        Type KindType {get;}
    }

    public interface IArtifactKind<K> : IArtifactKind
        where K : unmanaged
    {
        K Kind {get;}

        Type IArtifactKind.KindType
            => typeof(K);

        string ITextual.Format()
            => Kind.ToString();
    }
}