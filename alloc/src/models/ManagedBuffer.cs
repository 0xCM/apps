//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct ManagedBuffer : IBufferAllocation
    {
        [Op]
        public static ManagedBuffer alloc(ByteSize size)
            => new ManagedBuffer(GCHandle.Alloc(new byte[size], GCHandleType.Pinned), size);

        public static ManagedBuffer pin(byte[] src)
            => new ManagedBuffer(GCHandle.Alloc(src, GCHandleType.Pinned), (uint)src.Length);

        public static ManagedBuffer<T> pin<T>(T[] src)
            where T : unmanaged
                => new ManagedBuffer<T>(GCHandle.Alloc(src, GCHandleType.Pinned), (uint)src.Length*core.size<T>());

        public static ManagedBuffer<T> alloc<T>(ulong count)
            where T : unmanaged
                => new ManagedBuffer<T>(GCHandle.Alloc(new T[count], GCHandleType.Pinned), (uint)count*core.size<T>());

        public static ManagedBuffer<T> alloc<T>(long count)
            where T : unmanaged
                => alloc<T>((ulong)count);

        readonly GCHandle _Handle;

        readonly uint _Size;

        [MethodImpl(Inline)]
        public ManagedBuffer(GCHandle handle, uint size)
        {
            _Handle = handle;
            _Size = size;
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => _Handle.AddrOfPinnedObject();
        }

        public ref byte First
        {
            [MethodImpl(Inline)]
            get => ref  @ref<byte>(BaseAddress);
        }

        public Span<byte> Edit
        {
            [MethodImpl(Inline)]
            get => cover<byte>(BaseAddress, _Size);
        }

        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => cover<byte>(BaseAddress, _Size);
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => _Size;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Size;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Size;
        }

        public void Dispose()
        {
            _Handle.Free();
        }
    }
}