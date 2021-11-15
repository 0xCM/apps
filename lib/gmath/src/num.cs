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
    public readonly struct num
    {
        [MethodImpl(Inline), Factory, Closures(AllNumeric)]
        public static num<T> from<T>(T value)
            where T : unmanaged
                => new num<T>(value);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static num<T> zero<T>()
            where T : unmanaged
                => new num<T>(core.zero<T>());

        [MethodImpl(Inline), One, Closures(AllNumeric)]
        public static num<T> one<T>()
            where T : unmanaged
                => new num<T>(core.one<T>());

        [MethodImpl(Inline), Ones, Closures(AllNumeric)]
        public static num<T> ones<T>()
            where T : unmanaged
                => new num<T>(core.ones<T>());

        [MethodImpl(Inline), Add, Closures(AllNumeric)]
        public static num<T> add<T>(num<T> a, num<T> b)
            where T : unmanaged
                => from(gmath.add(a.Value, b.Value));

        [MethodImpl(Inline), Mul, Closures(AllNumeric)]
        public static num<T> mul<T>(num<T> a, num<T> b)
            where T : unmanaged
                => from(gmath.mul(a.Value, b.Value));

        [MethodImpl(Inline), Sub, Closures(AllNumeric)]
        public static num<T> sub<T>(num<T> a, num<T> b)
            where T : unmanaged
                => from(gmath.sub(a.Value, b.Value));

        [MethodImpl(Inline), Div, Closures(AllNumeric)]
        public static num<T> div<T>(num<T> a, num<T> b)
            where T : unmanaged
                => from(gmath.div(a.Value, b.Value));

        [MethodImpl(Inline), Mod, Closures(AllNumeric)]
        public static num<T> mod<T>(num<T> a, num<T> b)
            where T : unmanaged
                => from(gmath.mod(a.Value, b.Value));

        [MethodImpl(Inline), Negate, Closures(AllNumeric)]
        public static num<T> negate<T>(num<T> a)
            where T : unmanaged
                => from(gmath.negate(a.Value));

        [MethodImpl(Inline), And, Closures(Integers)]
        public static num<T> and<T>(num<T> a, num<T> b)
            where T : unmanaged
                => from(gmath.and(a.Value, b.Value));

        [MethodImpl(Inline), Or, Closures(Integers)]
        public static num<T> or<T>(num<T> a, num<T> b)
            where T : unmanaged
                => from(gmath.or(a.Value, b.Value));

        [MethodImpl(Inline), Xor, Closures(Integers)]
        public static num<T> xor<T>(num<T> a, num<T> b)
            where T : unmanaged
                => from(gmath.xor(a.Value, b.Value));

        [MethodImpl(Inline), Not, Closures(Integers)]
        public static num<T> not<T>(num<T> a)
            where T : unmanaged
                => from(gmath.not(a.Value));

        [MethodImpl(Inline), Sll, Closures(Integers)]
        public static num<T> sll<T>(num<T> a, byte offset)
            where T : unmanaged
                => from(gmath.sll(a.Value, offset));

        [MethodImpl(Inline), Srl, Closures(Integers)]
        public static num<T> srl<T>(num<T> a, byte offset)
            where T : unmanaged
                => from(gmath.srl(a.Value, offset));

        [MethodImpl(Inline), Eq, Closures(AllNumeric)]
        public static bit eq<T>(num<T> a, num<T> b)
            where T : unmanaged
                => gmath.eq(a.Value,b.Value);

        [MethodImpl(Inline), Neq, Closures(AllNumeric)]
        public static bit neq<T>(num<T> a, num<T> b)
            where T : unmanaged
                => gmath.neq(a.Value,b.Value);

        [MethodImpl(Inline), Lt, Closures(AllNumeric)]
        public static bit lt<T>(num<T> a, num<T> b)
            where T : unmanaged
                => gmath.lt(a.Value,b.Value);

        [MethodImpl(Inline), Gt, Closures(AllNumeric)]
        public static bit gt<T>(num<T> a, num<T> b)
            where T : unmanaged
                => gmath.gt(a.Value,b.Value);

        [MethodImpl(Inline), LtEq, Closures(AllNumeric)]
        public static bit lteq<T>(num<T> a, num<T> b)
            where T : unmanaged
                => gmath.lteq(a.Value,b.Value);

        [MethodImpl(Inline), GtEq, Closures(AllNumeric)]
        public static bit gteq<T>(num<T> a, num<T> b)
            where T : unmanaged
                => gmath.gteq(a.Value,b.Value);
    }
}