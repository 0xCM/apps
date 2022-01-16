//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    using static Root;

    public class FileIndex : Dictionary<FS.FilePath, FileRef>
    {
        public FileIndex()
        {

        }

        public FileIndex(FileRef[] src)
            : base(src.Select(row => (row.Path,row)).ToDictionary())
        {
            Files = src.Select(x => x.Path);
        }

        public FS.Files Files {get;}

        public static implicit operator FileIndex(FileRef[] src)
            => new FileIndex(src);

        public static FileIndex Empty => new();
    }
}