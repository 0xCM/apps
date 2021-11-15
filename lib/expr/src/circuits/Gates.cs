//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr.Circuits
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost("expr.gates")]
    public readonly partial struct gates
    {
        const NumericKind Closure = Integers;

        [MethodImpl(Inline), Op]
        public static GateInfo gate(GateKind kind, byte width, byte ins, byte outs)
            => new GateInfo(kind, width, ins, outs);

        [MethodImpl(Inline), Op]
        public static Wire wire(byte width)
            => new Wire(width);

        [MethodImpl(Inline), Op, Closures(Closure)]
        static bit u1<T>(T src)
            where T : unmanaged
                => @as<T,bit>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        static T u1<T>(bit src)
            => @as<bit,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        internal static T and<T>(T a, T b)
            where T : unmanaged
                => typeof(T) == typeof(bit) ? u1<T>(bit.and(u1(a), u1(b))) : gmath.and(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        internal static T or<T>(T a, T b)
            where T : unmanaged
                => typeof(T) == typeof(bit) ? u1<T>(bit.or(u1(a), u1(b))) : gmath.or(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        internal static T xor<T>(T a, T b)
            where T : unmanaged
                => typeof(T) == typeof(bit) ? u1<T>(bit.xor(u1(a),u1(b))) : gmath.xor(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        internal static T nand<T>(T a, T b)
            where T : unmanaged
                => typeof(T) == typeof(bit) ? u1<T>(bit.nand(u1(a),u1(b))) : gmath.nand(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        internal static T nor<T>(T a, T b)
            where T : unmanaged
                => typeof(T) == typeof(bit) ? u1<T>(bit.nor(u1(a),u1(b))) : gmath.nor(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        internal static T xnor<T>(T a, T b)
            where T : unmanaged
                => typeof(T) == typeof(bit) ? u1<T>(bit.xnor(u1(a),u1(b))) : gmath.xnor(a,b);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T mux<T>(T a, T b, T c)
            where T : unmanaged
                => typeof(T) == typeof(bit) ? u1<T>(bit.select(u1(a),u1(b), u1(c))) : gmath.select(a,b,c);

        [MethodImpl(Inline), Op, Closures(Closure)]
        internal static Pair<T> demux<T>(T a, T b)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        internal static T not<T>(T a)
            where T : unmanaged
                => typeof(T) == typeof(bit) ? u1<T>(bit.not(u1(a))) : gmath.not(a);
    }
}