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
    public readonly struct Lt<T> : IScalarCmpPred<Lt<T>,T>
        where T : IScalarExpr
    {
        public T Left {get;}

        public T Right {get;}

        [MethodImpl(Inline)]
        public Lt(T a, T b)
        {
            Left = a;
            Right = b;
        }

        public Name OpName
            => "lt<{0}>";

        public CmpPredKind Kind
            => CmpPredKind.LT;

        public Lt Untyped()
            => new Lt(Left,Right);

        [MethodImpl(Inline)]
        public Lt<T> Create(T a0, T a1)
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
        public static implicit operator ScalarCmpPred<T>(Lt<T> src)
            => new ScalarCmpPred<T>(src.Left, src.Right, src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator Lt<T>(ScalarCmpPred<T> src)
            => new Lt<T>(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator Lt(Lt<T> src)
            => src.Untyped();
    }
}