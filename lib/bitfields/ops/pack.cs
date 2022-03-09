//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Bitfields
    {
        [MethodImpl(Inline), Op]
        public static ref byte pack4x2(byte a, byte b, ref byte dst)
        {
            dst = (byte)((a & 0xF) | (b >> 4));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ushort pack4x3(byte a0, byte a1, byte a2, ref ushort dst)
        {
            dst = (ushort)((a0 & 0xF) | ((a1 & 0xF0) >> 4)  | ((a2 & 0xF00) >> 8));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ushort pack4x4(byte a0, byte a1, byte a2, byte a3, ref ushort dst)
        {
            dst = (ushort)((a0 & 0xF) | ((a1 & 0xF0) >> 4)  | ((a2 & 0xF00) >> 8)  | ((a3 & 0xF000) >> 12));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ushort pack8x2(ushort a, ushort b, ref ushort dst)
        {
            dst = (ushort)((a & 0xFF) | (b >> 8));
            return ref dst;
        }
    }
}