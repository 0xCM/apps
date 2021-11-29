//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct expr
    {
        [MethodImpl(Inline), Op]
        public static Literal<bit> literal(in Label name, bit value)
            => literal<bit>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<bool> literal(in Label name, bool value)
            => literal<bool>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<byte> literal(in Label name, byte value)
            => literal<byte>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<ushort> literal(in Label name, ushort value)
            => literal<ushort>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<uint> literal(in Label name, uint value)
            => literal<uint>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<ulong> literal(in Label name, ulong value)
            => literal<ulong>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<sbyte> literal(in Label name, sbyte value)
            => literal<sbyte>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<short> literal(in Label name, short value)
            => literal<short>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<int> literal(in Label name, int value)
            => literal<int>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<long> literal(in Label name, long value)
            => literal<long>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<float> literal(in Label name, float value)
            => literal<float>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<double> literal(in Label name, double value)
            => literal<double>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<decimal> literal(in Label name, decimal value)
            => literal<decimal>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<char> literal(in Label name, char value)
            => literal<char>(name, value);

        [MethodImpl(Inline), Op]
        public static Literal<string> literal(in Label name, string value)
            => literal<string>(name, value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        static Literal<T> literal<T>(in Label name, Constant<T> value)
            => new Literal<T>(name, value);
    }
}