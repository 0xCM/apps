//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.Vector128;
    using static Root;
    using static core;

    using api = MemorySegs;

    /// <summary>
    /// Defines a reference to a (live) memory segment
    /// </summary>
    public readonly struct MemorySeg : IMemorySegment, ITextual, IEquatable<MemorySeg>, IHashed
    {
        public const byte SZ = 16;

        readonly Vector128<ulong> Segment;

        [MethodImpl(Inline)]
        public unsafe MemorySeg(byte* src, ByteSize size)
            => Segment = Create((ulong)src, (ulong)size);

        [MethodImpl(Inline)]
        public MemorySeg(MemoryAddress src, ByteSize size)
            => Segment = Create((ulong)src, (ulong)size);

        [MethodImpl(Inline)]
        public MemorySeg(MemoryRange range)
            : this(range.Min, range.Size)
        {

        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Segment.GetElement(0);
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Segment.GetElement(1);
        }

        /// <summary>
        /// Specifies the segment byte count
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        public uint Length
        {
            [MethodImpl(Inline)]
            get => (uint)Segment.GetElement(1);
        }

        public Span<byte> Edit
        {
            [MethodImpl(Inline)]
            get => cover<byte>(BaseAddress, Length);
        }

        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => cover<byte>(BaseAddress, Length);
        }

        public MemoryAddress LastAddress
        {
            [MethodImpl(Inline)]
            get => BaseAddress + Length;
        }

        public MemoryRange Range
        {
            [MethodImpl(Inline)]
            get => new MemoryRange(BaseAddress, BaseAddress + Length);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Segment.Equals(default);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !Segment.Equals(default);
        }

        [MethodImpl(Inline)]
        public bool Contains(MemoryAddress src)
            => src >= BaseAddress && src <= LastAddress;

        [MethodImpl(Inline)]
        public unsafe ref byte Cell(int offset)
            => ref @ref<byte>((void*)(BaseAddress + offset));

        [MethodImpl(Inline)]
        public unsafe byte* Pointer(uint offset = 0)
            => BaseAddress.Pointer<byte>() + offset;

        public ref byte this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Cell(index);
        }

        /// <summary>
        /// Computes the whole number of T-cells covered by segment
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public uint CellCount<T>()
            => api.count<T>(this);

        public string Format()
            => Range.Format();

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Load()
            => api.view<byte>(this);

        [MethodImpl(Inline)]
        public ReadOnlySpan<T> Load<T>()
            => api.view<T>(this);

        [MethodImpl(Inline)]
        public uint Hash()
            => alg.hash.calc(Segment);

        [MethodImpl(Inline)]
        public bool Equals(MemorySeg src)
            => src.Segment.Equals(Segment);

        [MethodImpl(Inline)]
        public unsafe MemorySpan ToSpan()
            => new MemorySpan(Range, api.edit(BaseAddress, Size));

        [MethodImpl(Inline)]
        public static implicit operator Vector128<ulong>(in MemorySeg src)
            => src.Segment;

        uint IHashed.Hash
            => Hash();

        bool IEquatable<MemorySeg>.Equals(MemorySeg src)
            => Equals(src);

        public override bool Equals(object src)
            => src is MemorySeg x && Equals(x);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash();

        public static MemorySeg Empty
            => default;
    }
}