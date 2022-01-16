//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    public readonly struct DocPath
    {
        public readonly uint DocId;

        public readonly FS.FilePath Path;

        [MethodImpl(Inline)]
        public DocPath(uint id, FS.FilePath path)
        {
            DocId = id;
            Path = path;
        }

        [MethodImpl(Inline)]
        public static implicit operator DocPath((uint id, FS.FilePath path) src)
            => new DocPath(src.id, src.path);
    }
}