//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Canonical
{
    using System;

    /// <summary>
    /// Represents the empty vector
    /// </summary>
    public struct v0<T> : IVector<T>
        where T : unmanaged
    {
        public const ulong Width = 0;

        public ref T this[uint i]
            => throw new Exception("I do not exist");

        public uint N => 0;

        public Span<T> Cells
            => default;

        BitWidth ISizedType.ContentWidth
            => Width;
    }
}