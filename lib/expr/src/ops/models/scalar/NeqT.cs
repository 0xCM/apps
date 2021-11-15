//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Neq<T> : ICmpPred<Neq<T>,T>
        where T : IExpr
    {
        public readonly T A;

        public readonly T B;

        [MethodImpl(Inline)]
        public Neq(T a, T b)
        {
            A = a;
            B = b;
        }

        public Label OpName => "neq<{0}>";

        public CmpPredKind Kind
            => CmpPredKind.NEQ;

        public Neq Untyped()
            => new Neq(A,B);

        [MethodImpl(Inline)]
        public Neq<T> Make(T a0, T a1)
            => new Neq<T>(a0, a1);

        [MethodImpl(Inline)]
        public string Format()
            => Untyped().Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Neq<T>((T a, T b) src)
            => new Neq<T>(src.a, src.b);

        [MethodImpl(Inline)]
        public static implicit operator CmpPred<T>(Neq<T> src)
            => new CmpPred<T>(src.A, src.B, src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator Neq<T>(CmpPred<T> src)
            => new Neq<T>(src.A, src.B);

        [MethodImpl(Inline)]
        public static implicit operator Neq(Neq<T> src)
            => src.Untyped();
    }
}