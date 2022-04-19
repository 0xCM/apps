//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct FileArtifact<K> : IFileArtifact<FileArtifact<K>,K>
        where K : unmanaged
    {
        public K Kind {get;}

        public FS.FileUri Location {get;}


        [MethodImpl(Inline)]
        public FileArtifact(K kind, FS.FileUri location)
        {
            Kind = kind;
            Location = location;
        }

        public FS.PathPart Name
            => Location.Format();

        public string Format()
            => Location.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator FileArtifact<K>((K kind, FS.FileUri locator) src)
            => new FileArtifact<K>(src.kind, src.locator);
    }
}