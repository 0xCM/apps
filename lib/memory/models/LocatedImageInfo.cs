//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Describes a PE image from the perspective of process entry point
    /// </summary>
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct LocatedImageInfo : IRecord<LocatedImageInfo>
    {
        public const string TableId = "image.located";

        /// <summary>
        /// The image source path
        /// </summary>
        public FS.FilePath ImagePath;

        /// <summary>
        /// The image part identifier, if any
        /// </summary>
        public PartId PartId;

        /// <summary>
        /// The image's memory base
        /// </summary>
        public MemoryAddress BaseAddress;

        /// <summary>
        /// The process entry point
        /// </summary>
        public MemoryAddress EntryAddress;

        /// <summary>
        /// The image size
        /// </summary>
        public ByteSize Size;

        [MethodImpl(Inline)]
        public LocatedImageInfo(FS.FilePath path, PartId part, MemoryAddress entry, MemoryAddress @base, uint size)
        {
            ImagePath = path;
            PartId = part;
            EntryAddress = entry;
            BaseAddress = @base;
            Size = size;
        }

        /// <summary>
        /// The <see cref='ImagePath'/> filename without the extension
        /// </summary>
        public string Name
        {
            [MethodImpl(Inline)]
            get => ImagePath.FileName.WithoutExtension.Name;
        }

        /// <summary>
        /// The terminal address as determined by <see cref='BaseAddress'/> + <see cref='Size'/>
        /// </summary>
        public MemoryAddress EndAddress
        {
            [MethodImpl(Inline)]
            get => BaseAddress + Size;
        }

        /// <summary>
        /// The memory range occupied by the image
        /// </summary>
        public MemoryRange Range
        {
            [MethodImpl(Inline)]
            get => (BaseAddress, EndAddress);
        }

        public int CompareTo(LocatedImageInfo src)
            => BaseAddress.CompareTo(src.BaseAddress);
    }
}