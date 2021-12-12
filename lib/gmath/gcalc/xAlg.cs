//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public static partial class xAlg
    {
        [MethodImpl(Inline), Op]
        public static byte Sum(this ReadOnlySpan<byte> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static ushort Sum(this ReadOnlySpan<ushort> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static uint Sum(this ReadOnlySpan<uint> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static ulong Sum(this ReadOnlySpan<ulong> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static sbyte Sum(this ReadOnlySpan<sbyte> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static short Sum(this ReadOnlySpan<short> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static int Sum(this ReadOnlySpan<int> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static long Sum(this ReadOnlySpan<long> src)
            => gcalc.sum(src);

        [MethodImpl(Inline)]
        public static double Sum(this ReadOnlySpan<double> src)
            => gcalc.sum(src);

        [MethodImpl(Inline)]
        public static double Sum(this Span<double> src)
            => src.ReadOnly().Sum();

        [MethodImpl(Inline)]
        public static float Avg(this Span<float> src)
            => gcalc.favg<float>(src);

        [MethodImpl(Inline)]
        public static double Avg(this Span<double> src)
            => gcalc.favg<double>(src);

        [MethodImpl(Inline), Op]
        public static float Avg(this ReadOnlySpan<float> src)
            => gcalc.favg(src);

        [MethodImpl(Inline), Op]
        public static double Avg(this ReadOnlySpan<double> src)
            => gcalc.favg(src);
    }
}