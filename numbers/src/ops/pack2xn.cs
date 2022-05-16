//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Numbers
    {
        [MethodImpl(Inline), Op]
        public static num3 pack(num2 a, bit b)
            => (num3)((uint)a | (uint)b << num2.Width);

        [MethodImpl(Inline), Op]
        public static num4 pack(num2 a, num2 b)
            => (num4)((uint)a | (uint)b << num2.Width);

        [MethodImpl(Inline), Op]
        public static num6 pack(num2 a, num2 b, num2 c)
            => (num6)((uint)a | (uint)b << num2.Width | (uint)c << num4.Width);

        [MethodImpl(Inline), Op]
        public static num5 pack(num2 a, num3 b)
            => (num5)((uint)a | (uint)b << num2.Width);

        [MethodImpl(Inline), Op]
        public static num6 pack(num2 a, num4 b)
            => (num6)((uint)a | (uint)b << num2.Width);

        [MethodImpl(Inline), Op]
        public static num7 pack(num2 a, num5 b)
            => (num7)((uint)a | (uint)b << num2.Width);

        [MethodImpl(Inline), Op]
        public static byte pack(num2 a, num6 b)
            => (byte)((uint)a | (uint)b << num2.Width);

        [MethodImpl(Inline), Op]
        public static num9 pack(num2 a, num7 b)
            => (num9)((uint)a | (uint)b << num2.Width);

        [MethodImpl(Inline), Op]
        public static num10 pack(num2 a, byte b)
            => (num10)((uint)a | (uint)b << num2.Width);

        [MethodImpl(Inline), Op]
        public static num11 pack(num2 a, num9 b)
            => (num11)((uint)a |((uint)b << num2.Width));

        [MethodImpl(Inline), Op]
        public static num12 pack(num2 a, num10 b)
            => (num12)((uint)a | (uint)b << num2.Width);

        [MethodImpl(Inline), Op]
        public static num13 pack(num2 a, num11 b)
            => (num13)((uint)a | (uint)b << num2.Width);

        [MethodImpl(Inline), Op]
        public static num14 pack(num2 a, num12 b)
            => (num14)((uint)a | (uint)b << num2.Width);
    }
}