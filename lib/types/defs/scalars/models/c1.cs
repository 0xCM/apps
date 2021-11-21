//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.ScalarTypes
{
    /// <summary>
    /// Represents a character of width 1
    /// </summary>
    public struct c1<T> : IChar<T>
        where T : unmanaged
    {
        public const ulong Width = 1;

        public T Storage;

        public string Format()
            => Storage.ToString();

        public override string ToString()
            => Format();

        BitWidth IBlittable.ContentWidth
            => Width;
    }
}