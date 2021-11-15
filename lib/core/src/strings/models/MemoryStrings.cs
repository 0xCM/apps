//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct MemoryStrings
    {
        public readonly uint EntryCount;

        public readonly uint CharCount;

        public readonly MemoryAddress OffsetBase;

        public readonly MemoryAddress CharBase;

        [MethodImpl(Inline)]
        public MemoryStrings(uint entries, uint chars, MemoryAddress offsetbase, MemoryAddress charbase)
        {
            EntryCount = entries;
            CharCount = chars;
            OffsetBase = offsetbase;
            CharBase = charbase;
        }

        public ReadOnlySpan<char> this[int index]
        {
            [MethodImpl(Inline)]
            get => strings.chars(this, index);
        }

        public ReadOnlySpan<char> this[uint index]
        {
            [MethodImpl(Inline)]
            get => strings.chars(this, index);
        }

        [MethodImpl(Inline)]
        public Label Label(uint index)
            => strings.label(this[index]);

        [MethodImpl(Inline)]
        public Label Label(int index)
            => strings.label(this[index]);

        [MethodImpl(Inline)]
        public MemoryAddress Address(uint index)
            => strings.address(this, index);

        [MethodImpl(Inline)]
        public MemoryAddress Address(int index)
            => strings.address(this, index);

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => strings.chars(this);
        }

        public unsafe ReadOnlySpan<uint> Offsets
        {
            [MethodImpl(Inline)]
            get => strings.offsets(this);
        }
    }
}