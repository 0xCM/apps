//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout,Pack=1, Size=Size)]
    public readonly struct MemoryStrings
    {
        [MethodImpl(Inline), Op]
        public static uint count(ReadOnlySpan<byte> offsets)
            => (uint)(offsets.Length/4);

        public const ushort Size = 8 + 16;

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

        public MemoryStrings<K> Kinded<K>()
            where K : unmanaged
                =>  core.@as<MemoryStrings,MemoryStrings<K>>(this);
    }
}