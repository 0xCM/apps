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
    public readonly struct Lt<T> : ICmpPred<Lt<T>,T>
        where T : IExpr
    {
        public T A {get;}

        public T B {get;}

        [MethodImpl(Inline)]
        public Lt(T a, T b)
        {
            A = a;
            B = b;
        }

        public Label OpName => "lt<{0}>";

        public CmpPredKind Kind
            => CmpPredKind.LT;

        public Lt Untyped()
            => new Lt(A,B);

        [MethodImpl(Inline)]
        public Lt<T> Make(T a0, T a1)
            => new Lt<T>(a0, a1);

        [MethodImpl(Inline)]
        public string Format()
            => Untyped().Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Lt<T>((T a, T b) src)
            => new Lt<T>(src.a, src.b);

        [MethodImpl(Inline)]
        public static implicit operator CmpPred<T>(Lt<T> src)
            => new CmpPred<T>(src.A, src.B, src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator Lt<T>(CmpPred<T> src)
            => new Lt<T>(src.A, src.B);

        [MethodImpl(Inline)]
        public static implicit operator Lt(Lt<T> src)
            => src.Untyped();

    }
}