//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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