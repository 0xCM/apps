//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using api = PageBlocks;

    [ApiComplete]
    public unsafe struct PageBlock
    {
        /// <summary>
        /// Windows page size = 4096 bytes
        /// </summary>
        public const uint PageSize = Pow2.T12;

        public readonly MemoryRange Range;

        [MethodImpl(Inline)]
        public PageBlock(MemoryRange range)
        {
            Range = range;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Range.Size;
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => cover<byte>(Range.Min.Pointer<byte>(), Range.Size);
        }

        public ref byte First
        {
            [MethodImpl(Inline)]
            get => ref first(Bytes);
        }

        public ref byte this[int index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,index);
        }

        public ref byte this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,index);
        }

        [MethodImpl(Inline)]
        public Span<T> Storage<T>()
            where T : unmanaged
                => recover<T>(Bytes);

        [MethodImpl(Inline)]
        public ref T Cell<T>(int index)
            where T : unmanaged
                => ref seek(Storage<T>(), index);

        [MethodImpl(Inline)]
        public ref T Cell<T>(uint index)
            where T : unmanaged
                => ref seek(Storage<T>(), index);


        [MethodImpl(Inline)]
        public ref T Segment<T>(ByteSize offset)
            where T : unmanaged
                => ref @as<T>(seek(Bytes,offset));

        public uint PageCount
        {
            [MethodImpl(Inline)]
            get => Range.Size/api.PageSize;
        }

        [MethodImpl(Inline)]
        public PageBlockInfo Describe()
            => api.describe(this);

        [MethodImpl(Inline)]
        public Span<T> Cells<T>()
            where T : unmanaged
                => recover<T>(Bytes);
    }
}