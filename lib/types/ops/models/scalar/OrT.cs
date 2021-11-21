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
    public readonly struct Or<T> : IBinaryBitLogicOp<Or<T>,T>
        where T : IExpr
    {
        public readonly T A;

        public readonly T B;

        [MethodImpl(Inline)]
        public Or(T a, T b)
        {
            A = a;
            B = b;
        }

        public Label OpName => "or<{0}>";

        public BinaryBitLogicKind Kind
            => BinaryBitLogicKind.Or;

        [MethodImpl(Inline)]
        public Or<T> Make(T a0, T a1)
            => new Or<T>(a0, a1);

        public Or Untyped()
            => new Or(A,B);

        [MethodImpl(Inline)]
        public string Format()
            => Untyped().Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Or<T>((T a, T b) src)
            => new Or<T>(src.a, src.b);

        [MethodImpl(Inline)]
        public static implicit operator Or(Or<T> src)
            => src.Untyped();
    }
}