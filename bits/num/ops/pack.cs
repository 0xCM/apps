//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

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

        [MethodImpl(Inline), Op]
        public static num2 pack(num2 a, num2 b)
            => (num2)((uint)a | (uint)b << num2.Width);

        [MethodImpl(Inline), Op]
        public static num6 pack(num3 a, num3 b)
            => (num6)((uint)a | (uint)b << num3.Width);

        [MethodImpl(Inline), Op]
        public static byte pack(num4 a, num4 b)
            => (byte)((uint)a | (uint)b << num4.Width);

        [MethodImpl(Inline), Op]
        public static num9 pack(num5 a, num4 b)
            => (num9)((uint)a | (uint)b << num5.Width);

        [MethodImpl(Inline), Op]
        public static num6 pack(num6 a, num6 b)
            => (num6)((uint)a | (uint)b << num6.Width);

        [MethodImpl(Inline), Op]
        public static num9 pack(num4 a, num5 b)
            => (num9)((uint)a | (uint)b << num4.Width);

        [MethodImpl(Inline), Op]
        public static num10 pack(num5 a, num5 b)
            => (num10)((uint)a | (uint)b << num5.Width);
    }
}