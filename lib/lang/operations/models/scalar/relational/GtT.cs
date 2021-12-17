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
    public readonly struct Gt<T> : IScalarCmpPred<Gt<T>,T>
        where T : IScalarExpr
    {
        public T Left {get;}

        public T Right {get;}

        [MethodImpl(Inline)]
        public Gt(T a, T b)
        {
            Left = a;
            Right = b;
        }

        public bool Eval()
            => default;


        public Label OpName
            => "gt<{0}>";

        public CmpPredKind Kind
            => CmpPredKind.GT;

        public Gt Untyped()
            => new Gt(Left,Right);

        [MethodImpl(Inline)]
        public Gt<T> Create(T a0, T a1)
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
        public static implicit operator ScalarCmpPred<T>(Gt<T> src)
            => new ScalarCmpPred<T>(src.Left, src.Right, src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator Gt<T>(ScalarCmpPred<T> src)
            => new Gt<T>(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator Gt(Gt<T> src)
            => src.Untyped();
    }
}