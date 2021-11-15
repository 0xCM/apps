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

    using C = AsciCode;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static C code(in asci2 src, Hex1Seq index)
            => (C)(src.Storage >> (byte)index);

        [MethodImpl(Inline), Op]
        public static C code(in asci4 src, Hex2Seq index)
            => (C)(src.Storage >> (byte)index);

        [MethodImpl(Inline), Op]
        public static C code(in asci8 src, Hex3Seq index)
            => (C)(src.Storage >> (byte)index);

        [MethodImpl(Inline), Op]
        public static C code(in asci16 src, Hex4Seq index)
            => (C)skip(bytes(src), (byte)index);

        [MethodImpl(Inline), Op]
        public static C code(in asci32 src, Hex5Seq index)
            => (C)skip(bytes(src), (byte)index);

        [MethodImpl(Inline), Op]
        public static C code(in asci64 src, Hex6Seq index)
            => (C)skip(bytes(src), (byte)index);

        [MethodImpl(Inline), Op]
        public static C code(in asci16 src, N4 index)
            => code<N4>(src, index);

        [MethodImpl(Inline)]
        public static C code<N>(in asci16 src, N index = default)
            where N : unmanaged, ITypeNat
                => (C)cpu.vextract(src.Storage, index);
    }
}