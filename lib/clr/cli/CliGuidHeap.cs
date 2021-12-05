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

    public readonly struct CliGuidHeap : ICliHeap<CliGuidHeap>
    {
        public MemoryAddress BaseAddress {get;}

        public ByteSize Size {get;}

        [MethodImpl(Inline)]
        public CliGuidHeap(MemoryAddress @base, ByteSize size)
        {
            BaseAddress = @base;
            Size = size;
        }

        public CliHeapKind HeapKind => CliHeapKind.Guid;

        public unsafe ReadOnlySpan<byte> Data
        {
            [MethodImpl(Inline)]
            get => cover<byte>(BaseAddress, Size);
        }

        public string Format()
            => string.Format(MemoryRange.define(BaseAddress, Size).Format());

        public override string ToString()
            => Format();
    }
}