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

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Nlt<T> : ICmpPred<Nlt<T>,T>
        where T : IExpr
    {
        public readonly T A;

        public readonly T B;

        [MethodImpl(Inline)]
        public Nlt(T a, T b)
        {
            A = a;
            B = b;
        }

        public Label OpName => "nlt<{0}>";

        public CmpPredKind Kind
            => CmpPredKind.NLT;

        public Nlt Untyped()
            => new Nlt(A,B);

        [MethodImpl(Inline)]
        public Nlt<T> Make(T a0, T a1)
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
        public static implicit operator CmpPred<T>(Nlt<T> src)
            => new CmpPred<T>(src.A, src.B, src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator Nlt<T>(CmpPred<T> src)
            => new Nlt<T>(src.A, src.B);

        [MethodImpl(Inline)]
        public static implicit operator Nlt(Nlt<T> src)
            => src.Untyped();
    }
}