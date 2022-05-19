//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Numbers
    {
        [MethodImpl(Inline), Op]
        public static num32 pack(num16 a, num16 b)
            => (num32)((uint)a | (uint)b << num16.Width);

        [MethodImpl(Inline), Op]
        public static num32 pack(num3 a, num7 b, num2 c, num16 d)
            => (num32)a
            | ((num32)b << num3.Width)
            | ((num32)c << (num3.Width + num7.Width))
            | (num32)d << (num3.Width + num7.Width + num2.Width);
    }
}