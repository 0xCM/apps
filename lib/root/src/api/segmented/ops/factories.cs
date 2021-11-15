//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class NativeSegKinds
    {
        [KindFactory]
        public static Seg16 seg16()
            => default;

        [KindFactory]
        public static Seg32 seg32()
            => default;

        [KindFactory]
        public static Seg64 seg64()
            => default;

        [KindFactory]
        public static Seg128 seg128()
            => default;

        [KindFactory]
        public static Seg256 seg256()
            => default;

        [KindFactory]
        public static Seg512 seg512()
            => default;

        [KindFactory]
        public static Seg16x8u seg16x8u()
            => default;

        [KindFactory]
        public static Seg16x8i seg16x8i()
            => default;

        [KindFactory]
        public static Seg16x16u seg16x16u()
            => default;

        [KindFactory]
        public static Seg16x16i seg16x16i()
            => default;

        [KindFactory]
        public static Seg32x8u seg32x8u()
            => default;

        [KindFactory]
        public static Seg32x8i seg32x8i()
            => default;

        [KindFactory]
        public static Seg32x16u seg32x16u()
            => default;

        [KindFactory]
        public static Seg32x16i seg32x16i()
            => default;

        [KindFactory]
        public static Seg32x32u seg32x32u()
            => default;

        [KindFactory]
        public static Seg32x32i seg32x32i()
            => default;

        [KindFactory]
        public static Seg64x8u seg64x8u()
            => default;

        [KindFactory]
        public static Seg64x8i seg64x8i()
            => default;

        [KindFactory]
        public static Seg64x16u seg64x16u()
            => default;

        [KindFactory]
        public static Seg64x16i seg64x16i()
            => default;

        [KindFactory]
        public static Seg64x32u seg64x32u()
            => default;

        [KindFactory]
        public static Seg64x32i seg64x32i()
            => default;

        [KindFactory]
        public static Seg64x64u seg64x64u()
            => default;

        [KindFactory]
        public static Seg64x64i seg64x64i()
            => default;

        [KindFactory]
        public static Seg128x8u seg128x8u()
            => default;

        [KindFactory]
        public static Seg128x8i seg128x8i()
            => default;

        [KindFactory]
        public static Seg128x16u seg128x16u()
            => default;

        [KindFactory]
        public static Seg128x16i seg128x16i()
            => default;

        [KindFactory]
        public static Seg128x32u seg128x32u()
            => default;

        [KindFactory]
        public static Seg128x32i seg128x32i()
            => default;

        [KindFactory]
        public static Seg128x64u seg128x64u()
            => default;

        [KindFactory]
        public static Seg128x64i seg128x64i()
            => default;

        [KindFactory]
        public static Seg128x32f seg128x32f()
            => default;

        [KindFactory]
        public static Seg128x64f seg128x64f()
            => default;

        [KindFactory]
        public static Seg256x8u seg256x8u()
            => default;

        [KindFactory]
        public static Seg256x8i seg256x8i()
            => default;

        [KindFactory]
        public static Seg256x16u seg256x16u()
            => default;

        [KindFactory]
        public static Seg256x16i seg256x16i()
            => default;

        [KindFactory]
        public static Seg256x32u seg256x32u()
            => default;

        [KindFactory]
        public static Seg256x32i seg256x32i()
            => default;

        [KindFactory]
        public static Seg256x64u seg256x64u()
            => default;

        [KindFactory]
        public static Seg256x64i seg256x64i()
            => default;

        [KindFactory]
        public static Seg256x32f seg256x32f()
            => default;

        [KindFactory]
        public static Seg256x64f seg256x64f()
            => default;

        [KindFactory]
        public static Seg512x8u seg512x8u()
            => default;

        [KindFactory]
        public static Seg512x8i seg512x8i()
            => default;

        [KindFactory]
        public static Seg512x16u seg512x16u()
            => default;

        [KindFactory]
        public static Seg512x16i seg512x16i()
            => default;

        [KindFactory]
        public static Seg512x32u seg512x32u()
            => default;

        [KindFactory]
        public static Seg512x32i seg512x32i()
            => default;

        [KindFactory]
        public static Seg512x64u seg512x64u()
            => default;

        [KindFactory]
        public static Seg512x64i seg512x64i()
            => default;

        [KindFactory]
        public static Seg512x32f seg512x32f()
            => default;

        [KindFactory]
        public static Seg512x64f seg512x64f()
            => default;

        [KindFactory, Closures(Closure)]
        public static SegmentedKind<T> generic<T>(T t = default)
            where T : unmanaged
                => default;
   }
}