//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    /// <summary>
    /// Represents the empty character
    /// </summary>
    public struct c0<T> : IChar<T>
        where T : unmanaged
    {
        public const ulong Width = 0;

        BitWidth IBlittable.ContentWidth
            => Width;
    }
}