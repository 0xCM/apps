//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct num
    {
        [MethodImpl(Inline), Op]
        public static num7 pack(num5 a, num2 b)
            => (num7)((uint)a | (uint)b << num5.PackedWidth);

        [MethodImpl(Inline), Op]
        public static byte pack(num5 a, num3 b)
            => (byte)((uint)a | (uint)b << num5.PackedWidth);

        [MethodImpl(Inline), Op]
        public static num9 pack(num5 a, num4 b)
            => (num9)((uint)a | (uint)b << num5.PackedWidth);

        [MethodImpl(Inline), Op]
        public static num10 pack(num5 a, num5 b)
            => (num10)((uint)a | (uint)b << num5.PackedWidth);
    }
}