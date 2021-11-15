//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines an entry in list of files
    /// </summary>
    [Record(TableId)]
    public struct ListedFile : ITextual, IRecord<ListedFile>
    {
        public const string TableId = "files";

        public uint Index;

        public FS.FileUri Path;

        [MethodImpl(Inline)]
        public ListedFile(uint index, FS.FilePath path)
        {
            Index = index;
            Path = path;
        }

        [MethodImpl(Inline)]
        public ListedFile(int index, FS.FilePath path)
        {
            Index = (uint)index;
            Path = path;
        }

        [MethodImpl(Inline)]
        public string Format()
            => text.format("{0,-10} | {1}", Index, Path);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ListedFile((uint index, FS.FilePath path) src)
            => new ListedFile(src.index, src.path);

        [MethodImpl(Inline)]
        public static implicit operator ListedFile((int index, FS.FilePath path) src)
            => new ListedFile(src.index, src.path);
    }
}