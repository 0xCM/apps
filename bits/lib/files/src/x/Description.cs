//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XFs
    {
        public static FileDescription Description(this FS.FilePath src)
            => FS.describe(src);

        public static Index<FileDescription> Descriptions(this FS.Files src)
            => src.Map(FS.describe);
    }
}