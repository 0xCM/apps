//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris MoNote, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Not<T> : IUnaryBitLogicOp<Not<T>,T>
        where T : IExpr
    {
        public readonly T A;

        [MethodImpl(Inline)]
        public Not(T a)
        {
            A = a;
        }

        public Label OpName => "not<{0}>";

        public UnaryBitLogicKind Kind
            => UnaryBitLogicKind.Not;

        [MethodImpl(Inline)]
        public Not<T> Make(T a0)
            => new Not<T>(a0);

        public Not Untyped()
            => new Not(A);

        [MethodImpl(Inline)]
        public string Format()
            => Untyped().Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Not<T>((T a, T b) src)
            => new Not<T>(src.a);

        [MethodImpl(Inline)]
        public static implicit operator Not(Not<T> src)
            => src.Untyped();
    }
}