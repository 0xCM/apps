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
    public readonly struct Ge<T> : ICmpPred<Ge<T>,T>
        where T : IExpr
    {
        public readonly T A;

        public readonly T B;

        [MethodImpl(Inline)]
        public Ge(T a, T b)
        {
            A = a;
            B = b;
        }

        public Label OpName => "ge<{0}>";

        public CmpPredKind Kind
            => CmpPredKind.GE;

        public Ge Untyped()
            => new Ge(A,B);

        [MethodImpl(Inline)]
        public Ge<T> Make(T a0, T a1)
            => new Ge<T>(a0, a1);

        [MethodImpl(Inline)]
        public string Format()
            => Untyped().Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Ge<T>((T a, T b) src)
            => new Ge<T>(src.a, src.b);

        [MethodImpl(Inline)]
        public static implicit operator CmpPred<T>(Ge<T> src)
            => new CmpPred<T>(src.A, src.B, src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator Ge<T>(CmpPred<T> src)
            => new Ge<T>(src.A, src.B);

        [MethodImpl(Inline)]
        public static implicit operator Ge(Ge<T> src)
            => src.Untyped();
    }
}