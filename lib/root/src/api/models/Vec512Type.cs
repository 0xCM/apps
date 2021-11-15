//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Represents the generic type definition for a 512-bit vector
    /// </summary>
    public readonly struct Vec512Type : IVectorKind<Vec512Type,W512>
    {
        [MethodImpl(Inline)]
        public static implicit operator NativeVectorWidth(Vec512Type src)
            => src.W;

        [MethodImpl(Inline)]
        public static implicit operator Vec512Type(W512 src)
            => default;

        public W512 W
            => default;

        public NativeVectorWidth Class
            => NativeVectorWidth.W512;

        public uint Value
            => (uint)W.DataWidth;

        public int BitWidth
            => W;
    }
}