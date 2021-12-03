//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;

    public readonly struct Vec128Kind<T> : IVectorKind<Vec128Kind<T>,W128,T>
        where T : unmanaged
    {
        public W128 W
            => default;

        public NativeVectorWidth Width
            => NativeVectorWidth.W128;

        public NumericKind CellKind
            => NumericKinds.kind<T>();

        public NumericWidth CellWidth
            => (NumericWidth)Widths.bits<T>();

        [MethodImpl(Inline)]
        public static implicit operator NativeVectorWidth(Vec128Kind<T> src)
            => NativeVectorWidth.W128;

        [MethodImpl(Inline)]
        public static implicit operator Vec128Type(Vec128Kind<T> src)
            => default;
    }
}