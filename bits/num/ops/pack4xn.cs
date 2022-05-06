//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct num
    {
        [MethodImpl(Inline), Op]
        public static byte pack(num4 a, num4 b)
            => (byte)((uint)a | (uint)b << num4.PackedWidth);

        [MethodImpl(Inline), Op]
        public static num9 pack(num4 a, num5 b)
            => (num9)((uint)a | (uint)b << num4.PackedWidth);

        [MethodImpl(Inline), Op]
        public static num6 pack(num6 a, num6 b)
            => (num6)((uint)a | (uint)b << num6.PackedWidth);
    }
}