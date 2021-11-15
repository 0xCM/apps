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
    public readonly struct Le<T> : ICmpPred<Le<T>,T>
        where T : IExpr
    {
        public readonly T A;

        public readonly T B;

        [MethodImpl(Inline)]
        public Le(T a, T b)
        {
            A = a;
            B = b;
        }

        public Label OpName => "le<{0}>";

        public CmpPredKind Kind
            => CmpPredKind.LE;

        public Le Untyped()
            => new Le(A,B);

        [MethodImpl(Inline)]
        public Le<T> Make(T a0, T a1)
            => new Le<T>(a0, a1);

        [MethodImpl(Inline)]
        public string Format()
            => Untyped().Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Le<T>((T a, T b) src)
            => new Le<T>(src.a, src.b);

        [MethodImpl(Inline)]
        public static implicit operator CmpPred<T>(Le<T> src)
            => new CmpPred<T>(src.A, src.B, src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator Le<T>(CmpPred<T> src)
            => new Le<T>(src.A, src.B);

        [MethodImpl(Inline)]
        public static implicit operator Le(Le<T> src)
            => src.Untyped();
    }
}