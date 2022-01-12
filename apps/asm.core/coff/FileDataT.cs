//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class FileData<T>
    {
        readonly Dictionary<FS.FilePath,T> Data;

        public FileData()
        {
            Data = new();
        }

        protected FileData(Dictionary<FS.FilePath,T> src)
        {
            Data = src;
        }

        public ICollection<FS.FilePath> Paths
        {
            [MethodImpl(Inline)]
            get => Data.Keys;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Count;
        }

        public T this[FS.FilePath path]
        {
            [MethodImpl(Inline)]
            get => Data[path];
        }

        public ConstLookup<string,T> ToLookup(FileKind kind)
            => Data.Map(x => ((string)x.Key.SrcId(kind), x.Value)).ToDictionary();

        public Index<Paired<FS.FilePath,T>> Entries
            => Data.Map(x => core.paired(x.Key,x.Value));
    }
}