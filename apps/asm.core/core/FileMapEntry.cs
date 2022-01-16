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

    public readonly struct FileMapEntry : IArrow<FS.FilePath,FS.FilePath>
    {
        public FS.FilePath Source {get;}

        public FileKind SourceKind {get;}

        public FS.FilePath Target {get;}

        public FileKind TargetKind {get;}

        public FileMapEntry(FS.FilePath src, FileKind srckind, FS.FilePath dst, FileKind dstkind)
        {
            Source = src;
            SourceKind = srckind;
            Target = dst;
            TargetKind = dstkind;
        }
    }
}