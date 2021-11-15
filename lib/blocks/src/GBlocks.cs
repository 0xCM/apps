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

    [ApiHost]
    public readonly struct GBlocks
    {
        const NumericKind Closure = UnsignedInts;

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
        public static ref GBlock2<T> load<T>(ReadOnlySpan<T> src, ref GBlock2<T> dst)
            where T : unmanaged
        {
            dst = first(recover<T,GBlock2<T>>(src));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock3<T> load<T>(ReadOnlySpan<T> src, ref GBlock3<T> dst)
            where T : unmanaged
        {
            dst = first(recover<T,GBlock3<T>>(src));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock4<T> load<T>(ReadOnlySpan<T> src, ref GBlock4<T> dst)
            where T : unmanaged
        {
            dst = first(recover<T,GBlock4<T>>(src));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock5<T> load<T>(ReadOnlySpan<T> src, ref GBlock5<T> dst)
            where T : unmanaged
        {
            dst = first(recover<T,GBlock5<T>>(src));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock6<T> load<T>(ReadOnlySpan<T> src, ref GBlock6<T> dst)
            where T : unmanaged
        {
            dst = first(recover<T,GBlock6<T>>(src));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock7<T> load<T>(ReadOnlySpan<T> src, ref GBlock7<T> dst)
            where T : unmanaged
        {
            dst = first(recover<T,GBlock7<T>>(src));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock8<T> load<T>(ReadOnlySpan<T> src, ref GBlock8<T> dst)
            where T : unmanaged
        {
            dst = first(recover<T,GBlock8<T>>(src));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock12<T> load<T>(ReadOnlySpan<T> src, ref GBlock12<T> dst)
            where T : unmanaged
        {
            dst = first(recover<T,GBlock12<T>>(src));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref GBlock16<T> load<T>(ReadOnlySpan<T> src, ref GBlock16<T> dst)
            where T : unmanaged
        {
            dst = first(recover<T,GBlock16<T>>(src));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly GBlock2<T> store<T>(in GBlock2<T> src, Span<T> dst)
            where T : unmanaged
        {
            first(recover<T,GBlock2<T>>(dst)) = src;
            return ref src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly GBlock3<T> store<T>(in GBlock3<T> src, Span<T> dst)
            where T : unmanaged
        {
            first(recover<T,GBlock3<T>>(dst)) = src;
            return ref src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly GBlock4<T> store<T>(in GBlock4<T> src, Span<T> dst)
            where T : unmanaged
        {
            first(recover<T,GBlock4<T>>(dst)) = src;
            return ref src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly GBlock5<T> store<T>(in GBlock5<T> src, Span<T> dst)
            where T : unmanaged
        {
            first(recover<T,GBlock5<T>>(dst)) = src;
            return ref src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly GBlock6<T> store<T>(in GBlock6<T> src, Span<T> dst)
            where T : unmanaged
        {
            first(recover<T,GBlock6<T>>(dst)) = src;
            return ref src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly GBlock7<T> store<T>(in GBlock7<T> src, Span<T> dst)
            where T : unmanaged
        {
            first(recover<T,GBlock7<T>>(dst)) = src;
            return ref src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly GBlock8<T> store<T>(in GBlock8<T> src, Span<T> dst)
            where T : unmanaged
        {
            first(recover<T,GBlock8<T>>(dst)) = src;
            return ref src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly GBlock12<T> store<T>(in GBlock12<T> src, Span<T> dst)
            where T : unmanaged
        {
            first(recover<T,GBlock12<T>>(dst)) = src;
            return ref src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly GBlock16<T> store<T>(in GBlock16<T> src, Span<T> dst)
            where T : unmanaged
        {
            first(recover<T,GBlock16<T>>(dst)) = src;
            return ref src;
        }
    }
}