//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct ManagedBuffer<T> :  IBufferAllocation
        where T : unmanaged
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

        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref @ref<T>(BaseAddress);
        }

        public Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => cover<T>(BaseAddress, _Size);
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => cover<T>(BaseAddress, _Size);
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => _Size;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => _Size;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Size/size<T>();
        }


        public void Dispose()
        {
            _Handle.Free();
        }
    }
}