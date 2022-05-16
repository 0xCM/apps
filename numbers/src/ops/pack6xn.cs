//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Numbers
    {
        [MethodImpl(Inline), Op]
        public static num8 pack(num6 a, bit b)
            => (num8)a | ((num8)b << num6.Width);

        [MethodImpl(Inline), Op]
        public static num8 pack(num6 a, num2 b)
            => (num8)a | ((num8)b << num6.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num6 a, num3 b)
            => (num16)a | ((num16)b << num6.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num6 a, num4 b)
            => (num16)a | ((num16)b << num6.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num6 a, num5 b)
            => (num16)a | ((num16)b << num6.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num6 a, num7 b)
            => (num16)a | ((num16)b << num6.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num6 a, num8 b)
            => (num16)a | ((num16)b << num6.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num6 a, num9 b)
            => (num16)a | ((num16)b << num6.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num6 a, num10 b)
            => (num16)a | ((num16)b << num6.Width);

        [MethodImpl(Inline), Op]
        public static num17 pack(num6 a, num11 b)
            => (num17)a | ((num17)b << num6.Width);
    }
}