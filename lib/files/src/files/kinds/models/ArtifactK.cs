//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Artifact<K> : IArtifact<K,FS.FilePath>
        where K : unmanaged
    {
        public ArtifactKind<K> Kind {get;}

        public FS.FilePath Location {get;}

        [MethodImpl(Inline)]
        public Artifact(K kind, FS.FilePath locator)
        {
            Kind = kind;
            Location = locator;
        }

        public string Format()
            => Location.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Artifact<K>((K kind, FS.FilePath locator) src)
            => new Artifact<K>(src.kind, src.locator);
    }
}