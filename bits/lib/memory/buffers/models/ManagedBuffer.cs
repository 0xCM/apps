//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct ManagedBuffer : IBufferAllocation
    {
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