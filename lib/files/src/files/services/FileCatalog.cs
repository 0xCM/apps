//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public class FileCatalog
    {
        int FileId;

        [MethodImpl(Inline)]
        uint NextId()
            => (uint)inc(ref FileId);

        readonly PllMap<uint,FS.FilePath> IdMap;

        readonly PllMap<FS.FilePath,uint> PathMap;

        public FileCatalog()
        {
            IdMap = new();
            PathMap = new();
        }

        public bool Include(FS.FilePath src)
            => IdMap.Include(PathMap.Include(src, _ => NextId()),src);

        public uint Include(ReadOnlySpan<FS.FilePath> src)
        {
            var counter = 0u;
            foreach(var path in src)
            {
                if(Include(path))
                    counter++;
            }
            return counter;
        }

        FileCatalogEntry Entry(uint id)
        {
            IdMap.Find(id, out var path);
            var dst = new FileCatalogEntry();
            dst.Id = id;
            dst.Path = path;
            return dst;
        }

        public Index<FileCatalogEntry> Entries()
            => map(IdMap.Keys, Entry);
    }
}