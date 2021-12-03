//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.ScalarTypes
{
    /// <summary>
    /// Represents a character of width 16
    /// </summary>
    public struct c16<T> : IChar<T>
        where T : unmanaged
    {
        public const ulong Width = 16;

        public T Storage;

        BitWidth ISizedType.ContentWidth
            => Width;
    }
}