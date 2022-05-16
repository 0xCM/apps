//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Numbers
    {
        [MethodImpl(Inline), Op]
        public static num16 pack(num8 a, bit b)
            => (num16)a | ((num16)b << num8.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num8 a, num2 b)
            => (num16)a | ((num16)b << num8.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num8 a, num3 b)
            => (num16)a | ((num16)b << num8.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num8 a, num4 b)
            => (num16)a | ((num16)b << num8.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num8 a, num5 b)
            => (num16)a | ((num16)b << num8.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num8 a, num6 b)
            => (num16)a | ((num16)b << num8.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num8 a, num7 b)
            => (num16)a | ((num16)b << num8.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(num8 a, num8 b)
            => (num16)a | ((num16)b << num8.Width);

        [MethodImpl(Inline), Op]
        public static num16 pack(byte a, byte b)
            => (num16)a | ((num16)b << num8.Width);
    }
}