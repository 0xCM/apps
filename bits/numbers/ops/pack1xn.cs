//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct num
    {
        [MethodImpl(Inline), Op]
        public static num2 pack(bit a, bit b)
            => (num2)((uint)a | (uint)b << 1);

        [MethodImpl(Inline), Op]
        public static num3 pack(bit a, num2 b)
            => (num3)((uint)a | (uint)b << 1);

        [MethodImpl(Inline), Op]
        public static num4 pack(bit a, num3 b)
            => (num4)((uint)a | (uint)b << 1);

        [MethodImpl(Inline), Op]
        public static num5 pack(bit a, num4 b)
            => (num5)((uint)a | (uint)b << 1);

        [MethodImpl(Inline), Op]
        public static num6 pack(bit a, num5 b)
            => (num6)((uint)a | (uint)b << 1);

        [MethodImpl(Inline), Op]
        public static num3 pack(bit a, bit b, bit c)
            => (num3)((uint)a | (uint)b << 1 | (uint)c << 2);

        [MethodImpl(Inline), Op]
        public static num4 pack(bit a, bit b, bit c, bit d)
            => (num4)((uint)a | (uint)b << 1 | (uint)c << 2 | (uint)d << 3);

        [MethodImpl(Inline), Op]
        public static num11 pack(bit a, bit b, num9 c)
            => (num11)((uint)a | (uint)b << 1 | (uint)c << 2);
    }
}