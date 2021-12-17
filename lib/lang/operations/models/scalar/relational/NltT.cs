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

    using api = ScalarCmpPreds;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Nlt<T> : IScalarCmpPred<Nlt<T>,T>
        where T : IScalarExpr
    {
        public T Left {get;}

        public T Right {get;}

        [MethodImpl(Inline)]
        public Nlt(T a, T b)
        {
            Left = a;
            Right = b;
        }

        public bool Eval()
            => default;


        public Label OpName
            => "nlt<{0}>";

        public CmpPredKind Kind
            => CmpPredKind.NLT;

        public Nlt Untyped()
            => new Nlt(Left,Right);

        [MethodImpl(Inline)]
        public Nlt<T> Create(T a0, T a1)
            => new Nlt<T>(a0, a1);

        [MethodImpl(Inline)]
        public string Format()
            => Untyped().Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Nlt<T>((T a, T b) src)
            => new Nlt<T>(src.a, src.b);

        [MethodImpl(Inline)]
        public static implicit operator ScalarCmpPred<T>(Nlt<T> src)
            => new ScalarCmpPred<T>(src.Left, src.Right, src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator Nlt<T>(ScalarCmpPred<T> src)
            => new Nlt<T>(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator Nlt(Nlt<T> src)
            => src.Untyped();
    }
}