//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public readonly struct Artifacts
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Artifact<K> artifact<K>(K kind, FS.FilePath src)
            where K : unmanaged
                => new Artifact<K>(kind,src);

        [MethodImpl(Inline), Op]
        public static Artifact artifact(string @class, string locator)
            => new Artifact(@class,locator);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ArtifactKind<K> kind<K>(K kind)
            where K : unmanaged
                => kind;
    }
}