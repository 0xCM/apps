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

        BitWidth ISizedValue.ContentWidth
            => Width;
    }

    /// <summary>
    /// Represents the empty character
    /// </summary>
    public struct c0 : IChar
    {
        public BitWidth ContentWidth => 0;

        public BitWidth StorageWidth => 0;
    }
}