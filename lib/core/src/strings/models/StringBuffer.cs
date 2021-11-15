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

    /// <summary>
    /// Defines a character string allocated over a native buffer
    /// </summary>
    public unsafe struct StringBuffer : IDisposable
    {
        readonly NativeBuffer<char> Buffer;

        public StringBuffer(uint count)
        {
            Buffer = memory.native<char>(count);
        }

        public StringBuffer(int count)
        {
            Buffer = memory.native<char>((uint)count);
        }

        public void Dispose()
        {
            Buffer.Dispose();
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Buffer.Address;
        }

        /// <summary>
        /// The maximum number of symbols in the string
        /// </summary>
        public uint Length
        {
            [MethodImpl(Inline)]
            get => Buffer.Count;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Length*size<char>();
        }

        [MethodImpl(Inline)]
        public MemoryAddress Address(ulong index)
            => Buffer.Address + index*2;

        [MethodImpl(Inline)]
        public MemoryAddress Address(long index)
            => Address((ulong)index);

        [MethodImpl(Inline)]
        public ref char Symbol(ulong index)
            => ref seek(Buffer.Edit,index);

        [MethodImpl(Inline)]
        public ref char Symbol(long index)
            => ref seek(Buffer.Edit,index);

        public ref char this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Symbol(index);
        }

        public ref char this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Symbol(index);
        }

        [MethodImpl(Inline)]
        public bool Store(ReadOnlySpan<char> src, uint offset)
            => strings.store(src, offset, this);

        [MethodImpl(Inline)]
        public Label StoreLabel(ReadOnlySpan<char> src, uint offset)
            => strings.label(src, offset, this);

        [MethodImpl(Inline)]
        public StringRef StoreString(ReadOnlySpan<char> src, uint offset)
            => strings.@string(src, offset, this);

        public Span<char> Edit
        {
            [MethodImpl(Inline)]
            get => Buffer.Edit;
        }

        public ReadOnlySpan<char> View
        {
            [MethodImpl(Inline)]
            get => Buffer.View;
        }

        public StringAllocator Allocator()
            => new StringAllocator(this);

        public LabelAllocator LabelAllocator()
            => new LabelAllocator(this);
    }
}