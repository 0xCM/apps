//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LabelBuffer : IBufferAllocation
    {
        readonly Index<Label> _Labels;

        readonly StringBuffer Buffer;

        [MethodImpl(Inline)]
        internal LabelBuffer(StringBuffer buffer, Index<Label> labels)
        {
            Buffer = buffer;
            _Labels = labels;
        }

        public void Dispose()
        {
            Buffer.Dispose();
        }

        public ReadOnlySpan<Label> Labels
        {
            [MethodImpl(Inline)]
            get => _Labels.View;
        }

        public ref readonly Label this[int index]
        {
            [MethodImpl(Inline)]
            get => ref _Labels[index];
        }

        public ref readonly Label this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref _Labels[index];
        }

        public uint LabelCount
        {
            [MethodImpl(Inline)]
            get => _Labels.Count;
        }

        public ByteSize Capacity
        {
            [MethodImpl(Inline)]
            get => Buffer.Capacity;
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Buffer.BaseAddress;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Buffer.Capacity;
        }
    }
}