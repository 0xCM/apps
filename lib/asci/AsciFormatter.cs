//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    [ApiHost]
    public unsafe readonly struct AsciFormatter
    {
        [MethodImpl(Inline), Op]
        public static string format(in asci2 src)
            => format(src, n2);

        [MethodImpl(Inline), Op]
        public static string format(in asci4 src)
            => format(src, n4);

        [MethodImpl(Inline), Op]
        public static string format(in asci8 src)
            => format(src, n8);

        [MethodImpl(Inline), Op]
        public static string format(in asci16 src)
            => format(src, n16);

        [MethodImpl(Inline), Op]
        public static string format(in asci32 src)
            => format(src, n32);

        [MethodImpl(Inline), Op]
        public static string format(in asci64 src)
            => format(src, n64);

        [MethodImpl(Inline)]
        static unsafe string format<A,N>(in A src, N n = default)
            where A : unmanaged, IBytes<A,N>
            where N : unmanaged, ITypeNat
        {
            buffer<A,N>(src, out var target, out var pSrc);
            var pDst = pchar(target);
            var len = nat64u(n);
            for(var i=0u; i<len; i++)
                *pDst++ = (char)*pSrc++;
            return target;
        }

        [MethodImpl(Inline)]
        static char* buffer<A,N>(in A src, out string target, out byte* pSrc)
            where A : unmanaged, IBytes<A,N>
            where N : unmanaged, ITypeNat
        {
            if(typeof(N) == typeof(N2))
            {
                target = Buffer2;
                pSrc = gptr(first(@as<A,asci2>(edit(src)).View));
                return pchar(target);
            }
            else if(typeof(N) == typeof(N4))
            {
                target = Buffer4;
                pSrc = (byte*)pvoid(src);
                return pchar(target);
            }
            else if(typeof(N) == typeof(N8))
            {
                target = Buffer8;
                pSrc = (byte*)pvoid(src);
                return pchar(target);
            }
            else if(typeof(N) == typeof(N16))
            {
                target = Buffer16;
                pSrc = (byte*)pvoid(src);
                return pchar(target);
            }
            else if(typeof(N) == typeof(N32))
            {
                target = Buffer32;
                pSrc = (byte*)pvoid(src);
                return pchar(target);
            }
            else if(typeof(N) == typeof(N64))
            {
                target = Buffer64;
                pSrc = (byte*)pvoid(src);
                return pchar(target);
            }
            else
            {
                target = Buffer0;
                pSrc = (byte*)pvoid(src);
                return pchar(target);
            }
        }

        const string Buffer0 = "";

        const string Buffer2 = "  ";

        const string Buffer4 = "    ";

        const string Buffer8 = "        ";

        const string Buffer16 = "0000000000000000";

        const string Buffer32 = "                                ";

        const string Buffer64 = "                                                                ";
    }
}