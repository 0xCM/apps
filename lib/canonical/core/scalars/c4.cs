//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Canonical
{
    /// <summary>
    /// Represents a character of width 4
    /// </summary>
    public struct c4<T> : IChar<T>
        where T : unmanaged
    {
        public const ulong Width = 4;

        public T Storage;

        BitWidth ISizedType.ContentWidth
            => Width;
    }
}