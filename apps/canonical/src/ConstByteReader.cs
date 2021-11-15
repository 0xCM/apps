//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public unsafe readonly partial struct ConstBytesReader
    {
        public static ReadOnlySpan<Utf8Point> Utf8Points
        {
            [MethodImpl(Inline)]
            get => core.recover<byte,Utf8Point>(ConstBytes256.Storage.Seg(n7, n0));
        }

        readonly ConstBytes256 Data;

        [MethodImpl(Inline)]
        internal ConstBytesReader(ConstBytes256 data)
            => Data = data;

        public MemorySeg[] Refs
        {
            [MethodImpl(Inline)]
            get => Data.SegRefs();
        }

        [MethodImpl(Inline), Op]
        public Index<MemorySeg> Segments()
            => segments(Data);

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<byte> Leads()
            => leads(Data);

        [Op]
        public ReadOnlySpan<MemoryAddress> Locations(Index<MemorySeg> store)
            => addresses(Data, store);

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Span(byte n)
            => span(Data, n);

        [MethodImpl(Inline)]
        public MemorySeg Segment(byte n)
            => segment(Data, n);

        [MethodImpl(Inline)]
        public ref readonly byte Cell(byte n, int i)
            => ref cell(Data, n, i);

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Span<N>(N n)
            where N : unmanaged, ITypeNat
            => span(Data, n);

        [MethodImpl(Inline)]
        public ref readonly byte First<N>(N n)
            where N : unmanaged, ITypeNat
                => ref first(Data, n);

        [MethodImpl(Inline)]
        public ref readonly byte Cell<N>(N n, int i)
            where N : unmanaged, ITypeNat
                => ref cell(Data, n, i);

        [MethodImpl(Inline)]
        public unsafe MemorySeg Segment<N>(N n = default)
            where N : unmanaged, ITypeNat
                => segment(Data, n);
    }
}