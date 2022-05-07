//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct num
    {
        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static num2 force<T>(T src, N2 dst)
            where T : unmanaged
                => num2.crop(bw8(src));

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static num3 force<T>(T src, N3 dst)
            where T : unmanaged
                => num3.crop(bw8(src));

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static num4 force<T>(T src, N4 dst)
            where T : unmanaged
                => num4.crop(bw8(src));

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static num5 force<T>(T src, N5 dst)
            where T : unmanaged
                => num5.crop(bw8(src));

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static num7 force<T>(T src, N7 dst)
            where T : unmanaged
                => num7.crop(bw8(src));

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static num9 force<T>(T src, N9 dst)
            where T : unmanaged
                => num9.crop(bw16(src));

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static num10 force<T>(T src, N10 dst)
            where T : unmanaged
                => num10.crop(bw16(src));

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static num12 force<T>(T src, N12 dst)
            where T : unmanaged
                => num12.crop(bw16(src));

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static num13 force<T>(T src, N13 dst)
            where T : unmanaged
                => num13.crop(bw16(src));

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static num14 force<T>(T src, N14 dst)
            where T : unmanaged
                => num14.crop(bw16(src));

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static num15 force<T>(T src, N15 dst)
            where T : unmanaged
                => num15.crop(bw16(src));
   }
}