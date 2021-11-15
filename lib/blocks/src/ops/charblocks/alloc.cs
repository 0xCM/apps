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

    readonly partial struct CharBlocks
    {
        [MethodImpl(Inline), Op]
        public static CharBlock1 alloc(N1 n)
            => default;

        [MethodImpl(Inline), Op]
        public static CharBlock2 alloc(N2 n)
            => default;

        [MethodImpl(Inline), Op]
        public static CharBlock3 alloc(N3 n)
            => default;

        [MethodImpl(Inline), Op]
        public static CharBlock4 alloc(N4 n)
            => default;

        [MethodImpl(Inline), Op]
        public static CharBlock5 alloc(N5 n)
            => default;

        [MethodImpl(Inline), Op]
        public static CharBlock6 alloc(N6 n)
            => default;

        [MethodImpl(Inline), Op]
        public static CharBlock7 alloc(N7 n)
            => default;

        [MethodImpl(Inline), Op]
        public static CharBlock8 alloc(N8 n)
            => default;

        [MethodImpl(Inline), Op]
        public static CharBlock9 alloc(N9 n)
            => default;

        [MethodImpl(Inline), Op]
        public static CharBlock10 alloc(N10 n)
            => default;

        [MethodImpl(Inline), Op]
        public static CharBlock11 alloc(N11 n)
            => default;

        [MethodImpl(Inline), Op]
        public static CharBlock12 alloc(N12 n)
            => default;

        [MethodImpl(Inline), Op]
        public static CharBlock13 alloc(N13 n)
            => default;

        [MethodImpl(Inline), Op]
        public static CharBlock14 alloc(N14 n)
            => default;

        [MethodImpl(Inline), Op]
        public static CharBlock15 alloc(N15 n)
            => default;

        [MethodImpl(Inline), Op]
        public static CharBlock16 alloc(N16 n)
            => default;

        [MethodImpl(Inline), Op]
        public static CharBlock32 alloc(N32 n)
            => default;

        [MethodImpl(Inline), Op]
        public static CharBlock64 alloc(N64 n)
            => default;

        [MethodImpl(Inline), Op]
        public static CharBlock128 alloc(N128 n)
            => default;

        [MethodImpl(Inline), Op]
        public static CharBlock256 alloc(N256 n)
            => default;

        [MethodImpl(Inline), Op]
        public static ref char alloc(out CharBlock2 dst)
        {
            dst = default;
            return ref c16(dst);
        }

        [MethodImpl(Inline), Op]
        public static ref char alloc(out CharBlock3 dst)
        {
            dst = default;
            return ref c16(dst);
        }

        [MethodImpl(Inline), Op]
        public static ref char alloc(out CharBlock4 dst)
        {
            dst = default;
            return ref c16(dst);
        }

        [MethodImpl(Inline), Op]
        public static ref char alloc(out CharBlock5 dst)
        {
            dst = default;
            return ref c16(dst);
        }

        [MethodImpl(Inline), Op]
        public static ref char alloc(out CharBlock6 dst)
        {
            dst = default;
            return ref c16(dst);
        }

        [MethodImpl(Inline), Op]
        public static ref char alloc(out CharBlock7 dst)
        {
            dst = default;
            return ref c16(dst);
        }

        [MethodImpl(Inline), Op]
        public static ref char alloc(out CharBlock8 dst)
        {
            dst = default;
            return ref c16(dst);
        }

        [MethodImpl(Inline), Op]
        public static ref char alloc(out CharBlock16 dst)
        {
            dst = default;
            return ref c16(dst);
        }

        [MethodImpl(Inline), Op]
        public static ref char alloc(out CharBlock32 dst)
        {
            dst = default;
            return ref c16(dst);
        }

        [MethodImpl(Inline), Op]
        public static ref char alloc(out CharBlock64 dst)
        {
            dst = default;
            return ref c16(dst);
        }

        [MethodImpl(Inline), Op]
        public static ref char alloc(N64 n, out CharBlock64 dst)
        {
            dst = default;
            return ref c16(dst);
        }

        [MethodImpl(Inline), Op]
        public static ref char alloc(N128 n, out CharBlock128 dst)
        {
            dst = default;
            return ref c16(dst);
        }

        [MethodImpl(Inline), Op]
        public static ref char alloc(N256 n, out CharBlock256 dst)
        {
            dst = default;
            return ref c16(dst);
        }

        [MethodImpl(Inline), Op]
        public static void alloc(out CharBlock64 a, out CharBlock64 b)
        {
            a = default;
            b = default;
        }

        [MethodImpl(Inline), Op]
        public static void alloc(out CharBlock64 a, out CharBlock64 b, out CharBlock64 c)
        {
            a = default;
            b = default;
            c = default;
        }

        [MethodImpl(Inline), Op]
        public static void alloc(out CharBlock64 a, out CharBlock64 b, out CharBlock64 c, out CharBlock64 d)
        {
            a = default;
            b = default;
            c = default;
            d = default;
        }
    }
}