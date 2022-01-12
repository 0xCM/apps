//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;
    using System.IO.MemoryMappedFiles;

    using static Root;
    using static core;

    using api = MemoryFiles;

    public unsafe readonly struct MemoryFile : IMemoryFile<MemoryFile>
    {
        readonly byte* Base;

        readonly MemoryMappedFile File;

        readonly MemoryMappedViewAccessor Accessor;

        public FS.FilePath Path {get;}

        public ByteSize Size {get;}

        internal MemoryFile(FS.FilePath path)
        {
            Path = path;
            if(Path.IsNonEmpty)
            {
                File = MemoryMappedFile.CreateFromFile(path.Name, FileMode.Open, null, 0);
                Accessor = File.CreateViewAccessor(0, 0);
                var @base = default(byte*);
                Accessor.SafeMemoryMappedViewHandle.AcquirePointer(ref @base);
                Base = @base;
                Size = (ulong)Path.Info.Length;
            }
            else
            {
                File = default;
                Accessor = default;
                Size = 0;
                Base = null;
            }
        }

        public void Dispose()
        {
            if(IsNonEmpty)
            {
                Accessor?.Dispose();
                File?.Dispose();
            }
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Base;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline), Op]
            get => Base == null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline), Op]
            get => Base != null;
        }

        [MethodImpl(Inline)]
        public MemorySeg Segment()
            => new MemorySeg(Base,Size);

        public MemoryFileInfo Description
            => api.describe(this);

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> View(ulong offset, ByteSize size)
            => view(BaseAddress, offset, size);

        /// <summary>
        /// Presents file content as a readonly sequence of <see cref='byte'/> cells
        /// </summary>
        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> View()
            => api.view(this);

        /// <summary>
        /// Presents file content as a readonly sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public ReadOnlySpan<T> View<T>()
            => api.view<T>(this);

        /// <summary>
        /// Presents a single cell from the underlying source located at a <typeparamref name='T'/> measured offset
        /// </summary>
        /// <param name="tOffset">The number of cells to advance from the base address</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public ref readonly T One<T>(uint tOffset)
            => ref first(View<T>(tOffset));

        /// <summary>
        /// Presents file content segment as a readonly sequence of <typeparamref name='T'/> cells beginning
        /// at a <typeparamref name='T'/> measured offset and continuing to the end of the file
        /// </summary>
        /// <param name="tOffset">The number of cells to advance from the base address</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public ReadOnlySpan<T> View<T>(uint tOffset)
            => api.view<T>(this, tOffset);

        [MethodImpl(Inline)]
        public ReadOnlySpan<T> View<T>(uint tOffset, uint tCount)
            => api.view<T>(this,tOffset, tCount);

        [MethodImpl(Inline), Op]
        MemoryMappedViewStream Stream()
            => File.CreateViewStream();

        [MethodImpl(Inline), Op]
        MemoryMappedViewStream Stream(MemoryAddress src, ByteSize size)
            => File.CreateViewStream(src, (int)size);

        [MethodImpl(Inline)]
        public int CompareTo(MemoryFile src)
            => BaseAddress.CompareTo(src.BaseAddress);

        public static MemoryFile Empty
        {
            [MethodImpl(Inline)]
            get => new MemoryFile(FS.FilePath.Empty);
        }
    }
}