//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris MoAnde, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops.Scalar
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct And<T>
        where T : unmanaged
    {
        public T Apply(T a, T b)
            => gmath.and(a,b);

        public Label OpName => "and<{0}>";

        public BinaryBitLogicKind Kind
            => BinaryBitLogicKind.And;

        public override string ToString()
            => EmptyString;
    }
}