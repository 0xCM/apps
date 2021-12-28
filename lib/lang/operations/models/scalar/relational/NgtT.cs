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
    public readonly struct Ngt<T> : IScalarCmpPred<Ngt<T>,T>
        where T : IScalarExpr
    {
        public T Left {get;}

        public T Right {get;}

        [MethodImpl(Inline)]
        public Ngt(T a, T b)
        {
            Left = a;
            Right = b;
        }

        public bool Eval()
            => default;


        public Name OpName
            => "ngt<{0}>";

        public CmpPredKind Kind
            => CmpPredKind.NGT;

        public Ngt Untyped()
            => new Ngt(Left,Right);

        [MethodImpl(Inline)]
        public Ngt<T> Create(T a0, T a1)
            => new Ngt<T>(a0, a1);

        [MethodImpl(Inline)]
        public string Format()
            => Untyped().Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Ngt<T>((T a, T b) src)
            => new Ngt<T>(src.a, src.b);

        [MethodImpl(Inline)]
        public static implicit operator ScalarCmpPred<T>(Ngt<T> src)
            => new ScalarCmpPred<T>(src.Left, src.Right, src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator Ngt<T>(ScalarCmpPred<T> src)
            => new Ngt<T>(src.Left, src.Right);
    }
}