//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Describes a PE image from the perspective of process entry point
    /// </summary>
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ImageLocation : IComparable<ImageLocation>
    {
        const string TableId = "image.located";

        /// <summary>
        /// The image source path
        /// </summary>
        public FS.FilePath Path;

        /// <summary>
        /// The image part identifier, if any
        /// </summary>
        public string Name;

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
        public ImageLocation(FS.FilePath path, string name, MemoryAddress entry, MemoryAddress @base, uint size)
        {
            Path = path;
            Name = name;
            EntryAddress = entry;
            BaseAddress = @base;
            Size = size;
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

        [MethodImpl(Inline)]
        public int CompareTo(ImageLocation src)
            => BaseAddress.CompareTo(src.BaseAddress);
    }
}