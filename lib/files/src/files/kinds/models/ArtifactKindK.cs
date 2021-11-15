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
    /// Defines an artifact classifier
    /// </summary>
    public readonly struct ArtifactKind<K> : IArtifactKind<K>
        where K : unmanaged
    {
        public K Kind {get;}

        [MethodImpl(Inline)]
        public ArtifactKind(K kind)
        {
            Kind = kind;
        }

        public string Format()
            => Kind.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ArtifactKind<K>(K kind)
            => new ArtifactKind<K>(kind);
    }
}