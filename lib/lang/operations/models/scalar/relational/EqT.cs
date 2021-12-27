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

    using api = ScalarOps;
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Eq<T> : IScalarCmpPred<Eq<T>,T>
        where T : IScalarExpr
    {
        const string RenderPattern = "eq<{0}>({1}, {2})";

        public T Left {get;}

        public T Right {get;}

        [MethodImpl(Inline)]
        public Eq(T a, T b)
        {
            Left = a;
            Right = b;
        }

        public Label OpName
            => "eq<{0}>";

        public CmpPredKind Kind
            => CmpPredKind.EQ;

        public Eq Untyped()
            => new Eq(Left,Right);

        [MethodImpl(Inline)]
        public Eq<T> Create(T a0, T a1)
            => new Eq<T>(a0,a1);

        public string Format()
            => string.Format(RenderPattern, typeof(T).DisplayName() , Left, Right);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Eq<T>((T a, T b) src)
            => new Eq<T>(src.a, src.b);

        [MethodImpl(Inline)]
        public static implicit operator ScalarCmpPred<T>(Eq<T> src)
            => new ScalarCmpPred<T>(src.Left, src.Right, src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator Eq<T>(ScalarCmpPred<T> src)
            => new Eq<T>(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator Eq(Eq<T> src)
            => src.Untyped();
    }
}