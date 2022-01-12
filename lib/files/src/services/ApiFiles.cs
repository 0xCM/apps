//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ApiFiles
    {
        public static FS.FileName filename(ApiHostUri host, FS.FileExt ext)
            => FS.file(host.Id.Format(), ext);

        public static FS.FileName filename(ApiHostUri host, FS.FileExt a, FS.FileExt b)
            => FS.file(text.concat(host.Id.Format(), a), b);

        [MethodImpl(Inline), Op]
        public static FS.FolderName folder(ApiHostUri host)
            => FS.folder(host.HostName);

        [MethodImpl(Inline), Op]
        public static FS.FolderName folder(PartId part)
            => FS.folder(part.Format());
    }
}