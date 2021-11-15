//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System;
    using System.Runtime.CompilerServices;

    using Types;

    using static Root;

    [ApiHost]
    public readonly struct scalars
    {
        [MethodImpl(Inline), Op]
        public static ScalarType type(PrimalKind kind, ByteSize storage, BitWidth data)
            => new ScalarType(kind, storage,data);

        [MethodImpl(Inline), Op]
        public static u1<bit> uint1(bit src)
            => new u1<bit>(src);

        [MethodImpl(Inline), Op]
        public static u1<byte> uint1(byte src)
            => new u1<byte>(src);

        [MethodImpl(Inline), Op]
        public static u2<byte> uint2(byte src)
            => new u2<byte>(src);

        [MethodImpl(Inline), Op]
        public static u3<byte> uint3(byte src)
            => new u3<byte>(src);

        [MethodImpl(Inline), Op]
        public static u4<byte> uint4(byte src)
            => new u4<byte>(src);

        [MethodImpl(Inline), Op]
        public static u5<byte> uint5(byte src)
            => new u5<byte>(src);

        [MethodImpl(Inline), Op]
        public static u6<byte> uint6(byte src)
            => new u6<byte>(src);

        [MethodImpl(Inline), Op]
        public static u8 uint8(byte src)
            => new u8(src);

        [MethodImpl(Inline), Op]
        public static u16<ushort> uint16(ushort src)
            => new u16<ushort>(src);

        [MethodImpl(Inline), Op]
        public static u32<uint> uint32(uint src)
            => new u32<uint>(src);

        [MethodImpl(Inline), Op]
        public static u64<ulong> uint64(ulong src)
            => new u64<ulong>(src);
    }
}