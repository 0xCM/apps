//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ListedFiles : IIndex<ListedFile>
    {
        readonly Index<ListedFile> Data;

        [MethodImpl(Inline)]
        public ListedFiles(ListedFile[] src)
            => Data = src;

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }

        public ReadOnlySpan<ListedFile> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public Span<ListedFile> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ListedFile[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref ListedFile this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref ListedFile this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref ListedFile First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        [MethodImpl(Inline)]
        public static implicit operator ListedFiles(ListedFile[] src)
            => new ListedFiles(src);

        [MethodImpl(Inline)]
        public static implicit operator ListedFile[](ListedFiles src)
            => src.Storage;
    }
}