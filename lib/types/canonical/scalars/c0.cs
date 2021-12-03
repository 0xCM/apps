//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.ScalarTypes
{
    /// <summary>
    /// Represents the empty character
    /// </summary>
    public struct c0<T> : IChar<T>
        where T : unmanaged
    {
        public const ulong Width = 0;

        BitWidth ISizedType.ContentWidth
            => Width;
    }
}