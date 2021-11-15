//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IArtifact
    {
        string Locator {get;}

        string Classifier {get;}
    }

    public interface IArtifact<K> : IArtifact
        where K : unmanaged
    {
        ArtifactKind<K> Kind {get;}

        string IArtifact.Classifier
            => Kind.Format();
    }

    public interface IArtifact<K,T> : IArtifact<K>
        where K : unmanaged
    {
        T Location {get;}

        string IArtifact.Locator
            => Location.ToString();
    }
}