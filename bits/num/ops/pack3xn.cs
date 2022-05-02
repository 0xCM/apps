//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct num
    {
        [MethodImpl(Inline), Op]
        public static num4 pack(num3 a, bit b)
            => (num4)((uint)a | (uint)b << num3.Width);

        [MethodImpl(Inline), Op]
        public static num5 pack(num3 a, num2 b)
            => (num5)((uint)a | (uint)b << num3.Width);

        [MethodImpl(Inline), Op]
        public static num6 pack(num3 a, num3 b)
            => (num6)((uint)a | (uint)b << num3.Width);

        [MethodImpl(Inline), Op]
        public static num7 pack(num3 a, num4 b)
            => (num7)((uint)a | (uint)b << num3.Width);

        [MethodImpl(Inline), Op]
        public static byte pack(num3 a, num5 b)
            => (byte)((uint)a | (uint)b << num3.Width);

        [MethodImpl(Inline), Op]
        public static num9 pack(num3 a, num6 b)
            => (num9)((uint)a | (uint)b << num3.Width);

        [MethodImpl(Inline), Op]
        public static num11 pack(num3 a, byte b)
            => (num11)((uint)a | (uint)b << num3.Width);

        [MethodImpl(Inline), Op]
        public static num12 pack(num3 a, num9 b)
            => (num12)((uint)a |((uint)b << num3.Width));
    }
}