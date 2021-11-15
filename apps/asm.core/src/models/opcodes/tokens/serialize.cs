//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static core;

    using K = AsmOcTokenKind;
    using P = Pow2x32;

    partial struct TokenMaps
    {
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
                t0 = u8(point.Source);
                t1 = Pow2.log(point.Target);
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
            var dst = alloc<PointMap<K,P>>(Capacity);
            kseek(dst, K.None).Source = K.None;
            kseek(dst, K.None).Target = P.P2ᐞ00;

            kseek(dst, K.Byte).Source = K.Byte;
            kseek(dst, K.Byte).Target = P.P2ᐞ01;

            kseek(dst, K.Rex).Source = K.Rex;
            kseek(dst, K.Rex).Target = P.P2ᐞ02;

            kseek(dst, K.Vex).Source = K.Vex;
            kseek(dst, K.Vex).Target = P.P2ᐞ03;

            kseek(dst, K.Evex).Source = K.Evex;
            kseek(dst, K.Evex).Target = P.P2ᐞ04;

            kseek(dst, K.Escape).Source = K.Escape;
            kseek(dst, K.Escape).Target = P.P2ᐞ05;

            kseek(dst, K.RexBExtension).Source = K.RexBExtension;
            kseek(dst, K.RexBExtension).Target = P.P2ᐞ06;

            kseek(dst, K.OcExtension).Source = K.OcExtension;
            kseek(dst, K.OcExtension).Target = P.P2ᐞ07;

            kseek(dst, K.SegOverride).Source = K.SegOverride;
            kseek(dst, K.SegOverride).Target = P.P2ᐞ08;

            kseek(dst, K.Disp).Source = K.Disp;
            kseek(dst, K.Disp).Target = P.P2ᐞ09;

            kseek(dst, K.ImmSize).Source = K.ImmSize;
            kseek(dst, K.ImmSize).Target = P.P2ᐞ10;

            kseek(dst, K.Exclusion).Source = K.Exclusion;
            kseek(dst, K.Exclusion).Target = P.P2ᐞ11;

            kseek(dst, K.FpuDigit).Source = K.FpuDigit;
            kseek(dst, K.FpuDigit).Target = P.P2ᐞ12;

            kseek(dst, K.Mask).Source = K.Mask;
            kseek(dst, K.Mask).Target = P.P2ᐞ13;

            kseek(dst, K.Operator).Source = K.Operator;
            kseek(dst, K.Operator).Target = P.P2ᐞ14;

            return new PointMapper<K,P>(dst);
        }
    }
}