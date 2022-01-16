//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;

    public class FileIndex : Dictionary<FS.FilePath, FileIndexRow>
    {
        public FileIndex()
        {

        }

        public FileIndex(FileIndexRow[] rows)
            : base(rows.Select(row => (row.Path,row)).ToDictionary())
        {
            Files = rows.Select(x => x.Path);
        }

        public FS.Files Files {get;}

        public static implicit operator FileIndex(FileIndexRow[] src)
            => new FileIndex(src);

        public static FileIndex Empty => new();
    }
}