//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    using static Root;

    public class FileIndex
    {
        readonly Dictionary<FS.FilePath,FileRef> Data;

        readonly Dictionary<uint, FileRef> Docs;

        public FileIndex()
        {

        }

        public FileIndex(FileRef[] src)
        {
            Data = src.Select(row => (row.Path,row)).ToDictionary();
            Files = src.Select(x => x.Path);
            Docs = src.Select(row => (row.DocId, row)).ToDictionary();
        }

        public FS.Files Files {get;}

        public FileRef this[FS.FilePath path]
        {
            get => Data[path];
        }

        public FileRef this[uint docid]
        {
            get => Docs[docid];
        }


        public static implicit operator FileIndex(FileRef[] src)
            => new FileIndex(src);

        public static FileIndex Empty => new();
    }
}