//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct FileMap : IArrow<FS.FilePath, FS.FilePath>
    {
        public FS.FilePath Source {get;}

        public FileKind SourceKind;

        public FS.FilePath Target {get;}

        public FileKind TargetKind;

        public FileMap(FS.FilePath src, FileKind srckind, FS.FilePath dst, FileKind dstkind)
        {
            Source = src;
            SourceKind = srckind;
            Target = dst;
            TargetKind = dstkind;
        }
    }
}