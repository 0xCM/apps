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

    using SZ = AsmPrefixCodes.SizeOverrideCode;
    using SG = AsmPrefixCodes.SegOverrideCode;
    using K = AsmOcTokenKind;
    using P = Pow2x32;

    [ApiHost]
    public readonly partial struct AsmOpCodes
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static AsmOpCodeSpec define(params AsmOcToken[] src)
            => new AsmOpCodeSpec(src);

        [MethodImpl(Inline), Op]
        public static AsmOpCodeBits bits()
            => default;

         [MethodImpl(Inline), Op, Closures(Closure)]
         public static AsmOcToken<K> token<K>(AsmOcTokenKind kind, K value)
            where K : unmanaged
                => new AsmOcToken<K>(kind,value);

        [MethodImpl(Inline), Op]
        public static bit IsCallRel32(ReadOnlySpan<byte> src, uint offset)
            => (offset + 4) <= src.Length && skip(src, offset) == 0xE8;

        [MethodImpl(Inline), Op]
        public static bit HasSegOverride(AsmOpCode src)
            => emath.oneof(src.Lead, SegOverrideCodes);

        [MethodImpl(Inline), Op]
        public static bit HasSizeOverride(AsmOpCode src)
            => emath.oneof(src.Lead, SZ.ADSZ, SZ.OPSZ);

        [Op]
        public static uint serialize(PointMapper<K,P> src, Span<ushort> dst)
        {
            var points = src.Points;
            var count = points.Length;
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var point = ref seek(points,i);
                ref var t0 = ref @as<byte>(seek(dst,i));
                ref var t1 = ref @as<Log2x32>(seek(t0,1));
                t0 = u8(point.Left);
                t1 = Pow2.log(point.Right);
            }

            return 0;
        }

        public static Index<ushort> serialize(PointMapper<K,P> src)
        {
            var dst = alloc<ushort>(src.PointCount);
            serialize(src,dst);
            return dst;
        }

        [Op]
        public static PointMapper<K,P> ockinds()
        {
            const byte Capacity = 15;
            var dst = alloc<Paired<K,P>>(Capacity);
            kseek(dst, K.None).Left = K.None;
            kseek(dst, K.None).Right = P.P2ᐞ00;

            kseek(dst, K.Hex8).Left = K.Hex8;
            kseek(dst, K.Hex8).Right = P.P2ᐞ01;

            kseek(dst, K.Rex).Left = K.Rex;
            kseek(dst, K.Rex).Right = P.P2ᐞ02;

            kseek(dst, K.Vex).Left = K.Vex;
            kseek(dst, K.Vex).Right = P.P2ᐞ03;

            kseek(dst, K.Evex).Left = K.Evex;
            kseek(dst, K.Evex).Right = P.P2ᐞ04;

            kseek(dst, K.RexB).Left = K.RexB;
            kseek(dst, K.RexB).Right = P.P2ᐞ06;

            kseek(dst, K.OcExtension).Left = K.OcExtension;
            kseek(dst, K.OcExtension).Right = P.P2ᐞ07;

            kseek(dst, K.SegOverride).Left = K.SegOverride;
            kseek(dst, K.SegOverride).Right = P.P2ᐞ08;

            kseek(dst, K.Disp).Left = K.Disp;
            kseek(dst, K.Disp).Right = P.P2ᐞ09;

            kseek(dst, K.ImmSize).Left = K.ImmSize;
            kseek(dst, K.ImmSize).Right = P.P2ᐞ10;

            kseek(dst, K.Exclusion).Left = K.Exclusion;
            kseek(dst, K.Exclusion).Right = P.P2ᐞ11;

            kseek(dst, K.FpuDigit).Left = K.FpuDigit;
            kseek(dst, K.FpuDigit).Right = P.P2ᐞ12;

            kseek(dst, K.Mask).Left = K.Mask;
            kseek(dst, K.Mask).Right = P.P2ᐞ13;

            kseek(dst, K.Operator).Left = K.Operator;
            kseek(dst, K.Operator).Right = P.P2ᐞ14;

            return new PointMapper<K,P>(dst);
        }

        static ReadOnlySpan<SG> SegOverrideCodes
            => new SG[]{SG.CS, SG.DS, SG.ES, SG.FS, SG.GS, SG.SS};
   }
}