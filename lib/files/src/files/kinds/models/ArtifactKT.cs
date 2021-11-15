//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Artifact<K,T> : IArtifact<K,T>
        where K : unmanaged
        where T : unmanaged
    {
        public ArtifactKind<K> Kind {get;}

        public T Location {get;}

        [MethodImpl(Inline)]
        public Artifact(K kind, T locator)
        {
            Kind = kind;
            Location = locator;
        }

        public string Format()
            => Location.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Artifact<K,T>((K kind, T locator) src)
            => new Artifact<K,T>(src.kind, src.locator);
    }
}