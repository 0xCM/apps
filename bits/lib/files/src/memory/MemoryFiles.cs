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

    partial class XTend
    {
        public static MemoryFile MemoryMap(this FS.FilePath src)
            => MemoryFiles.map(src);
    }

    [ApiHost]
    public readonly struct MemoryFiles : IMemoryFileReader
    {
        const NumericKind Closure = UnsignedInts;

        public ReadOnlySpan<byte> Read(MemoryAddress src, ByteSize size)
            => core.view(src, size);

        public ReadOnlySpan<T> View<T>(in MemoryFile file, MemoryAddress src, uint count)
            where T : struct
                => view<T>(file, src, count);

        public ref readonly T View<T>(MemoryAddress src)
            where T : struct
                => ref core.view<T>(src);

        public MemoryFileInfo Describe(in MemoryFile src)
            => describe(src);

        public MemoryFile Map(FS.FilePath src)
            => map(src);

        public MappedFiles Map(FS.FolderPath src)
            => map(src);

        [MethodImpl(Inline), Op]
        public static MemoryFile map(FS.FilePath path)
            => new MemoryFile(path);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ReadOnlySpan<T> view<T>(in MemoryFile file, MemoryAddress start, uint count)
            where T : struct
                => cover<T>(start + file.BaseAddress, count);

        /// <summary>
        /// Creates a <see cref='MappedFiles'/> that covers the first level of a specified directory
        /// </summary>
        /// <param name="src">The source directory</param>
        [Op]
        public static MappedFiles map(FS.FolderPath src)
        {
            var files = src.EnumerateFiles(false).Array();
            if(files.Length != 0)
                return new MappedFiles(files.Select(map));
            else
                return MappedFiles.Empty;
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> view(MemoryAddress @base, ulong offset, ByteSize size)
            => cover<byte>(@base + offset, size);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> view(in MemoryFile src)
            => cover<byte>(src.BaseAddress, src.Size);

        /// <summary>
        /// Presents file content as a readonly sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> view<T>(in MemoryFile src)
            => cover<T>(src.BaseAddress, src.Size/core.size<T>());

        /// <summary>
        /// Presents file content segment as a readonly sequence of <typeparamref name='T'/> cells beginning
        /// at a <typeparamref name='T'/> measured offset and continuing to the end of the file
        /// </summary>
        /// <param name="tOffset">The number of cells to advance from the base address</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> view<T>(in MemoryFile src, uint tOffset)
            => slice(view<T>(src), tOffset);

        /// <summary>
        /// Presents file content segment as a readonly sequence of <typeparamref name='T'/> cells beginning
        /// at a <typeparamref name='T'/> measured offset and continuing to the end of the file
        /// </summary>
        /// <param name="tOffset">The number of cells to advance from the base address</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T one<T>(in MemoryFile src, uint tOffset)
            => ref first(view<T>(src, tOffset));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> view<T>(in MemoryFile src, uint tOffset, uint tCount)
            => slice(view<T>(src), tOffset, tCount);

        [Op]
        public static MemoryFileInfo describe(MemoryFile src)
        {
            var dst = new MemoryFileInfo();
            var fi = src.Path.Info;
            dst.BaseAddress = src.BaseAddress;
            dst.Size = src.Size;
            dst.EndAddress = dst.BaseAddress + dst.Size;
            dst.Path = src.Path;
            dst.CreateTS = fi.CreationTime;
            dst.UpdateTS = fi.LastWriteTime;
            dst.Attributes = fi.Attributes;
            return dst;
        }
    }
}