//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.ScalarTypes
{
    /// <summary>
    /// Represents a character of width 3
    /// </summary>
    public struct c3<T> : IChar<T>
        where T : unmanaged
    {
        public const ulong Width = 3;

        public T Storage;

        BitWidth IValue.ContentWidth
            => Width;
    }
}