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
    public readonly struct Gt<T> : ICmpPred<Gt<T>,T>
        where T : IExpr
    {
        public readonly T A;

        public readonly T B;

        [MethodImpl(Inline)]
        public Gt(T a, T b)
        {
            A = a;
            B = b;
        }

        public Label OpName => "gt<{0}>";

        public CmpPredKind Kind
            => CmpPredKind.GT;

        public Gt Untyped()
            => new Gt(A,B);

        [MethodImpl(Inline)]
        public Gt<T> Make(T a0, T a1)
            => new Gt<T>(a0, a1);

        [MethodImpl(Inline)]
        public string Format()
            => Untyped().Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Gt<T>((T a, T b) src)
            => new Gt<T>(src.a, src.b);

        [MethodImpl(Inline)]
        public static implicit operator CmpPred<T>(Gt<T> src)
            => new CmpPred<T>(src.A, src.B, src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator Gt<T>(CmpPred<T> src)
            => new Gt<T>(src.A, src.B);

        [MethodImpl(Inline)]
        public static implicit operator Gt(Gt<T> src)
            => src.Untyped();
    }
}