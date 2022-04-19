//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct FileSplitInfo
    {
        public FileSplitSpec Spec {get;}

        public FS.Files TargetFiles {get;}

        public Count TotalLineCount {get;}

        [MethodImpl(Inline)]
        public FileSplitInfo(FileSplitSpec spec, FS.Files dst, Count total)
        {
            Spec = spec;
            TargetFiles = dst;
            TotalLineCount = total;
        }
    }
}