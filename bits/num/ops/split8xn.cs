//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct num
    {
        [MethodImpl(Inline), Op]
        public static void split(byte src, out num4 a, out num4 b)
        {
            a = (num4)src;
            b = (num4)(src >> num4.PackedWidth);
        }

        [MethodImpl(Inline), Op]
        public static void split(byte src, out num5 a, out num3 b)
        {
            a = (num5)src;
            b = (num3)(src >> num5.PackedWidth);
        }

        [MethodImpl(Inline), Op]
        public static void split(byte src, out num6 a, out num2 b)
        {
            a = (num6)src;
            b = (num2)(src >> num6.PackedWidth);
        }

        [MethodImpl(Inline), Op]
        public static void split(byte src, out num7 a, out bit b)
        {
            a = (num7)src;
            b = (bit)(src >> num7.PackedWidth);
        }

        [MethodImpl(Inline), Op]
        public static void split(byte src, out num2 a, out num2 b, num2 c, num2 d)
        {
            a = (num2)src;
            b = (num2)(src >> num2.PackedWidth);
            c = (num2)(src >> num2.PackedWidth);
            d = (num2)(src >> num2.PackedWidth);
        }
    }
}