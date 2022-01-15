//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    using api = ScalarOps;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Le<T> : IScalarCmpPred<Le<T>,T>
        where T : IScalarExpr
    {
        public T Left {get;}

        public T Right {get;}

        [MethodImpl(Inline)]
        public Le(T a, T b)
        {
            Left = a;
            Right = b;
        }

        public Name OpName
            => "le<{0}>";

        public CmpPredKind Kind
            => CmpPredKind.LE;

        public Le Untyped()
            => new Le(Left,Right);

        [MethodImpl(Inline)]
        public Le<T> Create(T a0, T a1)
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
        public static implicit operator ScalarCmpPred<T>(Le<T> src)
            => new ScalarCmpPred<T>(src.Left, src.Right, src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator Le<T>(ScalarCmpPred<T> src)
            => new Le<T>(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator Le(Le<T> src)
            => src.Untyped();
    }
}