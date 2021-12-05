//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct EvalPrimal
    {
        [MethodImpl(Inline), Op]
        public static CmpEval<char> gt(char a, char b)
            => EvalResults.gt(a, b, a > b);

        [MethodImpl(Inline), Op]
        public static CmpEval<byte> gt(byte a, byte b)
            => EvalResults.gt(a, b, a > b);

        [MethodImpl(Inline), Op]
        public static CmpEval<sbyte> gt(sbyte a, sbyte b)
            => EvalResults.gt(a, b, a > b);

        [MethodImpl(Inline), Op]
        public static CmpEval<short> gt(short a, short b)
            => EvalResults.gt(a, b, a > b);

        [MethodImpl(Inline), Op]
        public static CmpEval<ushort> gt(ushort a, ushort b)
            => EvalResults.gt(a, b, a > b);

        [MethodImpl(Inline), Op]
        public static CmpEval<int> gt(int a, int b)
            => EvalResults.gt(a, b, a > b);

        [MethodImpl(Inline), Op]
        public static CmpEval<uint> gt(uint a, uint b)
            => EvalResults.gt(a, b, a > b);

        [MethodImpl(Inline), Op]
        public static CmpEval<long> gt(long a, long b)
            => EvalResults.gt(a, b, a > b);

        [MethodImpl(Inline), Op]
        public static CmpEval<ulong> gt(ulong a, ulong b)
            => EvalResults.gt(a, b, a > b);

        [MethodImpl(Inline), Op]
        public static CmpEval<float> gt(float a, float b)
            => EvalResults.gt(a, b, a > b);

        [MethodImpl(Inline), Op]
        public static CmpEval<double> gt(double a, double b)
            => EvalResults.gt(a, b, a > b);

        [MethodImpl(Inline), Op]
        public static CmpEval<decimal> gt(decimal a, decimal b)
            => EvalResults.gt(a, b, a > b);
    }
}