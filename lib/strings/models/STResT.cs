//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(StructLayout,Pack=1,Size = Size)]
    public unsafe readonly struct STRes<T> : ISTRes<T>, ISTRes<STRes<T>,T>
        where T : unmanaged
    {
        public const ushort Size = 2*4 + 2*MemoryAddress.Size + MemoryStrings.Size;

        public readonly uint EntryCount;

        public readonly uint CharCount;

        public readonly MemoryAddress CharBase;

        public readonly MemoryAddress OffsetBase;

        public readonly MemoryStrings Strings;

        [MethodImpl(Inline)]
        public STRes(uint entries, uint chars, MemoryAddress charbase, MemoryAddress offsetbase, MemoryStrings strings)
        {
            EntryCount = entries;
            CharCount = chars;
            CharBase = charbase;
            OffsetBase = offsetbase;
            Strings = strings;
        }

        public ReadOnlySpan<uint> Offsets
        {
            [MethodImpl(Inline), Op]
            get => STRes.offsets(this);
        }

        public ReadOnlySpan<char> Chars
        {
            [MethodImpl(Inline), Op]
            get => STRes.chars(this);
        }

        public ReadOnlySpan<char> this[int i]
        {
            [MethodImpl(Inline), Op]
            get => STRes.chars(this,i);
        }

        public ReadOnlySpan<char> this[uint i]
        {
            [MethodImpl(Inline), Op]
            get => STRes.chars(this,(int)i);
        }

        public ReadOnlySpan<char> this[T k]
        {
            [MethodImpl(Inline)]
            get => this[core.bw32(k)];
        }

        uint ISTRes.EntryCount
            => EntryCount;

        uint ISTRes.CharCount
            => CharCount;

        MemoryAddress ISTRes.CharBase
            => CharBase;

        MemoryAddress ISTRes.OffsetBase
            => OffsetBase;

        MemoryStrings ISTRes.Strings
            => Strings;


        [MethodImpl(Inline)]
        public static implicit operator STRes(STRes<T> src)
            => core.@as<STRes<T>,STRes>(src);

        [MethodImpl(Inline), Op]
        public static implicit operator STRes<T>(STRes src)
            => core.@as<STRes,STRes<T>>(src);
    }
}