//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    using api = ScalarCmpPreds;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Neq<T> : IScalarCmpPred<Neq<T>,T>
        where T : IScalarExpr
    {
        public T Left {get;}

        public T Right {get;}

        [MethodImpl(Inline)]
        public Neq(T a, T b)
        {
            Left = a;
            Right = b;
        }

        public bool Eval()
            => api.eval(this);

        public Label OpName
            => "neq<{0}>";

        public CmpPredKind Kind
            => CmpPredKind.NEQ;

        public Neq Untyped()
            => new Neq(Left,Right);

        [MethodImpl(Inline)]
        public Neq<T> Create(T a0, T a1)
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
        public static implicit operator ScalarCmpPred<T>(Neq<T> src)
            => new ScalarCmpPred<T>(src.Left, src.Right, src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator Neq<T>(ScalarCmpPred<T> src)
            => new Neq<T>(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator Neq(Neq<T> src)
            => src.Untyped();
    }
}