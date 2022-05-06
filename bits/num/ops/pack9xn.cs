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
        public static num10 pack(num9 a, bit b)
            => (num10)((uint)a |((uint)b << num9.PackedWidth));

        [MethodImpl(Inline), Op]
        public static num11 pack(num9 a, num2 b)
            => (num11)((uint)a |((uint)b << num9.PackedWidth));

        [MethodImpl(Inline), Op]
        public static num12 pack(num9 a, num3 b)
            => (num12)((uint)a |((uint)b << num9.PackedWidth));

        [MethodImpl(Inline), Op]
        public static num13 pack(num9 a, num4 b)
            => (num13)((uint)a |((uint)b << num9.PackedWidth));

        [MethodImpl(Inline), Op]
        public static num14 pack(num9 a, num5 b)
            => (num14)((uint)a |((uint)b << num9.PackedWidth));

        [MethodImpl(Inline), Op]
        public static num15 pack(num9 a, num6 b)
            => (num15)((uint)a |((uint)b << num9.PackedWidth));

        [MethodImpl(Inline), Op]
        public static ushort pack(num9 a, num7 b)
            => (ushort)((uint)a |((uint)b << num9.PackedWidth));

    }
}