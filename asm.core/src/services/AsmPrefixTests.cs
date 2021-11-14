//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using REP = AsmPrefixCodes.RepPrefixCode;
    using L = AsmPrefixCodes.LockPrefixCode;
    using SZ = AsmPrefixCodes.SizeOverrideCode;

    [ApiHost]
    public readonly struct AsmPrefixTests
    {
        const byte MinRexCode = 0x40;

        const byte MaxRexCode = 0x4F;

        [MethodImpl(Inline), Op]
        public static bit rex(in AsmOpCodeString src)
            => src.Data.Contains("REX", StringComparison.InvariantCultureIgnoreCase);

        /// <summary>
        /// Tests whether a specified byte represents the operand size override prefix,
        /// that selects an instruction's non-default operand size
        /// </summary>
        /// <param name="src">The byte to thest</param>
        [MethodImpl(Inline), Op]
        public static bit opsz(byte src)
            => (SZ)src == SZ.OPSZ;

        /// <summary>
        /// Tests whether a specified byte represents the address size override prefix
        /// that selects an instruction's non-default address size
        /// </summary>
        /// <param name="src">The byte to thest</param>
        [MethodImpl(Inline), Op]
        public static bit adsz(byte src)
            => (SZ)src == SZ.ADSZ;

        [MethodImpl(Inline), Op]
        public static bit rex(byte src)
            => math.between(src, MinRexCode, MaxRexCode);

        [MethodImpl(Inline), Op]
        public static bit rex(AsmOpCode src)
            => rex(src.Lead);

        [MethodImpl(Inline), Op]
        public static bit vex(byte src)
            => src == 0xC4 || src == 0xC5;

        [MethodImpl(Inline), Op]
        public static bit vex(uint src)
            => (byte)src == 0xC4 || (byte)src == 0xC5;

        [MethodImpl(Inline), Op]
        public static bit rex(in AsmHexCode src)
            => rex(skip(src.Bytes,0));

        [MethodImpl(Inline), Op]
        public static bit vex(in AsmHexCode src)
            => vex(skip(src.Bytes,0));

        [MethodImpl(Inline), Op]
        public static bit evex(uint src)
            => (byte)src == 0x62;

        [MethodImpl(Inline), Op]
        public static bit repeat(AsmOpCode src)
            => emath.oneof(src.Lead, REP.REPNZ, REP.REPZ);

        [MethodImpl(Inline), Op]
        public static bit @lock(AsmOpCode src)
            => emath.same(L.LOCK, src.Lead);

        [MethodImpl(Inline), Op]
        public static uint rex<T>(ReadOnlySpan<T> src, ref uint i, Span<T> dst)
            where T : struct, IAsmHexProvider
        {
            var i0 = i;
            var count = src.Length;
            for(var j = 0; j<count; j++)
            {
                ref readonly var provider = ref skip(src,j);
                if(rex(provider.AsmHex(out _)))
                    seek(dst, i++) = provider;
            }
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint vex<T>(ReadOnlySpan<T> src, ref uint i, Span<T> dst)
            where T : struct, IAsmHexProvider
        {
            var i0 = i;
            var count = src.Length;
            for(var j = 0; j<count; j++)
            {
                ref readonly var provider = ref skip(src,j);
                if(vex(provider.AsmHex(out _)))
                    seek(dst, i++) = provider;
            }
            return i - i0;
        }
    }
}