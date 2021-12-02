//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    public static partial class XTend
    {
        public static LlvmList ToLlvmList(this LlvmListItem[] items, FS.FilePath path)
            => new LlvmList(path,items);
    }

    public readonly struct LlvmList : IIndex<LlvmListItem>
    {
        readonly Index<LlvmListItem> Data;

        public FS.FilePath Path {get;}

        [MethodImpl(Inline)]
        public LlvmList(FS.FilePath path, LlvmListItem[] items)
        {
            Path = path;
            Data = items;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public string ListId
        {
            get => Path.FileName.WithoutExtension.Format();
        }

        public uint ItemCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public LlvmListItem[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<LlvmListItem> Items
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public static implicit operator LlvmList((FS.FilePath path, LlvmListItem[] items) src)
            => new LlvmList(src.path, src.items);

        public static LlvmList Empty => new LlvmList(FS.FilePath.Empty, sys.empty<LlvmListItem>());
    }
}