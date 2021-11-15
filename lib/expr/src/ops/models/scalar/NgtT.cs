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
    public readonly struct Ngt<T> : ICmpPred<Ngt<T>,T>
        where T : IExpr
    {
        public readonly T A;

        public readonly T B;

        [MethodImpl(Inline)]
        public Ngt(T a, T b)
        {
            A = a;
            B = b;
        }

        public Label OpName => "ngt<{0}>";

        public CmpPredKind Kind
            => CmpPredKind.NGT;

        public Ngt Untyped()
            => new Ngt(A,B);

        [MethodImpl(Inline)]
        public Ngt<T> Make(T a0, T a1)
            => new Ngt<T>(a0, a1);

        [MethodImpl(Inline)]
        public string Format()
            => Untyped().Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Ngt<T>((T a, T b) src)
            => new Ngt<T>(src.a, src.b);

        [MethodImpl(Inline)]
        public static implicit operator CmpPred<T>(Ngt<T> src)
            => new CmpPred<T>(src.A, src.B, src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator Ngt<T>(CmpPred<T> src)
            => new Ngt<T>(src.A, src.B);
    }
}