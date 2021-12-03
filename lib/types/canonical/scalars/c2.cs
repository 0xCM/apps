//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.ScalarTypes
{
    /// <summary>
    /// Represents a character of width 2
    /// </summary>
    public struct c2<T> : IChar<T>
        where T : unmanaged
    {
        public const ulong Width = 2;

        public T Storage;

        public string Format()
            => Storage.ToString();

        public override string ToString()
            => Format();

        BitWidth ISizedType.ContentWidth
            => Width;
    }
}