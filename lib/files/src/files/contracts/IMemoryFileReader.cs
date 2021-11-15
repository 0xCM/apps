//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IMemoryFileReader
    {
        /// <summary>
        /// Reads a specified count of parametrically-identified cells from a mapped file
        /// </summary>
        /// <param name="file">The source file</param>
        /// <param name="address">The address of the leading segment</param>
        /// <param name="count">The number of cells to read</param>
        /// <typeparam name="T">The cell type</typeparam>
        ReadOnlySpan<T> View<T>(in MemoryFile file, MemoryAddress address, uint count)
            where T : struct;

        ref readonly T View<T>(MemoryAddress src)
            where T : struct;

        MemoryFileInfo Describe(in MemoryFile src);

        /// <summary>
        /// Maps a single file into process memory
        /// </summary>
        /// <param name="src">The source path</param>
        MemoryFile Map(FS.FilePath src);

        /// <summary>
        /// Maps all of the files in a specified directory int process memory
        /// </summary>
        /// <param name="src">The source directory</param>
        MappedFiles Map(FS.FolderPath src);

        ReadOnlySpan<byte> Read(MemoryAddress src, ByteSize size);
    }
}