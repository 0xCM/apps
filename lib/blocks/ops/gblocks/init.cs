//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct GBlocks
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock2<T> init<T>(N2 n, out GBlock2<T> dst)
            where T : unmanaged
        {
            dst = default;
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock3<T> init<T>(N3 n, out GBlock3<T> dst)
            where T : unmanaged
        {
            dst = default;
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock4<T> init<T>(N4 n, out GBlock4<T> dst)
            where T : unmanaged
        {
            dst = default;
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock5<T> init<T>(N5 n, out GBlock5<T> dst)
            where T : unmanaged
        {
            dst = default;
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock6<T> init<T>(N6 n, out GBlock6<T> dst)
            where T : unmanaged
        {
            dst = default;
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock7<T> init<T>(N7 n, out GBlock7<T> dst)
            where T : unmanaged
        {
            dst = default;
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock8<T> init<T>(N8 n, out GBlock8<T> dst)
            where T : unmanaged
        {
            dst = default;
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock9<T> init<T>(N9 n, out GBlock9<T> dst)
            where T : unmanaged
        {
            dst = default;
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock10<T> init<T>(N10 n, out GBlock10<T> dst)
            where T : unmanaged
        {
            dst = default;
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock11<T> init<T>(N11 n, out GBlock11<T> dst)
            where T : unmanaged
        {
            dst = default;
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock12<T> init<T>(N12 n, out GBlock12<T> dst)
            where T : unmanaged
        {
            dst = default;
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock16<T> init<T>(N16 n, out GBlock16<T> dst)
            where T : unmanaged
        {
            dst = default;
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock32<T> init<T>(N32 n, out GBlock32<T> dst)
            where T : unmanaged
        {
            dst = default;
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock64<T> init<T>(N64 n, out GBlock64<T> dst)
            where T : unmanaged
        {
            dst = default;
            return ref dst;
        }
    }
}