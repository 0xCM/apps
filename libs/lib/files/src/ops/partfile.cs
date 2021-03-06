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
        public static FS.FileName partfile(PartId part, FS.FileExt ext)
            => file(part.Format(), ext);
    }
}