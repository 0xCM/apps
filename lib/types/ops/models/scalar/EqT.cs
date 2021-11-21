//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Eq<T> : ICmpPred<Eq<T>,T>
        where T : IExpr
    {
        public readonly T A;

        public readonly T B;

        [MethodImpl(Inline)]
        public Eq(T a, T b)
        {
            A = a;
            B = b;
        }


        public Label OpName => "eq<{0}>";

        public CmpPredKind Kind
            => CmpPredKind.EQ;

        public Eq Untyped()
            => new Eq(A,B);

        [MethodImpl(Inline)]
        public string Format()
            => Untyped().Format();

        [MethodImpl(Inline)]
        public Eq<T> Make(T a0, T a1)
            => new Eq<T>(a0,a1);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Eq<T>((T a, T b) src)
            => new Eq<T>(src.a, src.b);

        [MethodImpl(Inline)]
        public static implicit operator CmpPred<T>(Eq<T> src)
            => new CmpPred<T>(src.A, src.B, src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator Eq<T>(CmpPred<T> src)
            => new Eq<T>(src.A, src.B);

        [MethodImpl(Inline)]
        public static implicit operator Eq(Eq<T> src)
            => src.Untyped();
    }
}