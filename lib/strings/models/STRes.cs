//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(StructLayout,Pack=1,Size = Size)]
    public unsafe readonly struct STRes : ISTRes
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> chars(in STRes src)
            => cover(src.CharBase.Pointer<char>(), src.EntryCount);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<uint> offsets(in STRes src)
            => cover(src.OffsetBase.Pointer<uint>(), src.EntryCount);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> chars(in STRes src, int i)
        {
            var offsets = src.Offsets;
            var i0 = bw32(skip(offsets, i));
            var count = src.EntryCount;
            var data = src.Chars;
            if(i < count - 1)
            {
                var i1 = bw32(skip(offsets, i + 1));
                var length = i1 - i0;
                return slice(data, i0, length);
            }
            else
                return slice(data,i0);
        }

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
    }
}