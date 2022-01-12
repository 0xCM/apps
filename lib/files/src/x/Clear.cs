//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    partial class XFs
    {
        [Op]
        public static FS.FilePath PartPath(this IPart part)
            => FS.path(part.Owner.Location);

        [Op]
        public static FS.FolderPath Clear(this FS.FolderPath src, bool recurse = false)
        {
            FS.clear(src, recurse);
            return src;
        }

        [Op]
        public static List<FS.FilePath> Clear(this FS.FolderPath src, List<FS.FilePath> dst, bool recurse = false)
            => FS.clear(src, dst, recurse);

        [Op]
        public static FS.FilePath CopyTo(this FS.FilePath src, FS.FolderPath dst, bool overwrite = true)
        {
            if(src.Exists)
            {
                dst.Create();
                var path = dst + src.FileName;
                File.Copy(src.Name, path.Name, overwrite);
                return path;
            }
            else
                return FS.FilePath.Empty;
        }

        [Op]
        public static FS.Files Clear(this FS.Files src)
            => FS.clear(src);

    }
}