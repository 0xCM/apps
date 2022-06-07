//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct FileSplitSpec
    {
        public FS.FilePath SourcePath {get;}

        public Count MaxLineCount {get;}

        public FS.FolderPath TargetDir {get;}

        public TextEncodingKind TargetEncoding {get;}

        [MethodImpl(Inline)]
        public FileSplitSpec(FS.FilePath src, Count maxlines, FS.FolderPath dst, TextEncodingKind encoding)
        {
            SourcePath = src;
            MaxLineCount = maxlines;
            TargetDir = dst;
            TargetEncoding = encoding;
        }
    }
}