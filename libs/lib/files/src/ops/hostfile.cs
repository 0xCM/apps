//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;

    partial struct FS
    {
        [Op]
        public static FS.FileName hostfile(ApiHostUri uri, FS.FileExt ext)
            => file(string.Format("{0}.{1}", uri.Part.Format(), uri.HostName), ext);
    }
}