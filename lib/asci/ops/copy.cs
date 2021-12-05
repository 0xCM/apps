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

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci2 src, ref byte dst)
            => @as<byte,ushort>(dst) = src.Storage;

        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci4 src, ref byte dst)
            => @as<byte,uint>(dst) = src.Storage;

        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci8 src, ref byte dst)
            => @as<byte,ulong>(dst) = src.Storage;

        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci16 src, ref byte dst)
            => cpu.vstore(src.Storage, ref dst);

        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci32 src, ref byte dst)
            => cpu.vstore(src.Storage, ref dst);

        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci64 src, ref byte dst)
            => cpu.vstore(src.Storage, ref dst);

        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci16 src, Span<byte> dst)
            => cpu.vstore(src.Storage, dst);

        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci32 src, Span<byte> dst)
            => cpu.vstore(src.Storage, dst);

        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci64 src, Span<byte> dst)
            => cpu.vstore(src.Storage, dst);
    }
}