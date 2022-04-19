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
        public static CmpEval<char> eq(char a, char b)
            => EvalResults.eq(a, b, a == b);

        [MethodImpl(Inline), Op]
        public static CmpEval<string> eq(string a, string b)
            => EvalResults.eq(a, b, a == b);

        [MethodImpl(Inline), Op]
        public static CmpEval<byte> eq(byte a, byte b)
            => EvalResults.eq(a, b, a == b);

        [MethodImpl(Inline), Op]
        public static CmpEval<sbyte> eq(sbyte a, sbyte b)
            => EvalResults.eq(a, b, a == b);

        [MethodImpl(Inline), Op]
        public static CmpEval<short> eq(short a, short b)
            => EvalResults.eq(a, b, a == b);

        [MethodImpl(Inline), Op]
        public static CmpEval<ushort> eq(ushort a, ushort b)
            => EvalResults.eq(a, b, a == b);

        [MethodImpl(Inline), Op]
        public static CmpEval<int> eq(int a, int b)
            => EvalResults.eq(a, b, a == b);

        [MethodImpl(Inline), Op]
        public static CmpEval<uint> eq(uint a, uint b)
            => EvalResults.eq(a, b, a == b);

        [MethodImpl(Inline), Op]
        public static CmpEval<long> eq(long a, long b)
            => EvalResults.eq(a, b, a == b);

        [MethodImpl(Inline), Op]
        public static CmpEval<ulong> eq(ulong a, ulong b)
            => EvalResults.eq(a, b, a == b);

        [MethodImpl(Inline), Op]
        public static CmpEval<float> eq(float a, float b)
            => EvalResults.eq(a, b, a == b);

        [MethodImpl(Inline), Op]
        public static CmpEval<double> eq(double a, double b)
            => EvalResults.eq(a, b, a == b);

        [MethodImpl(Inline), Op]
        public static CmpEval<decimal> eq(decimal a, decimal b)
            => EvalResults.eq(a, b, a == b);

        [MethodImpl(Inline), Op]
        public static CmpEval<bool> eq(bool a, bool b)
            => EvalResults.eq(a, b, a == b);
    }
}