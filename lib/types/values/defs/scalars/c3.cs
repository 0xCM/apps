//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    /// <summary>
    /// Represents a character of width 3
    /// </summary>
    public struct c3 : IChar<byte>
    {
        public const ulong Width = 3;

        public byte Storage;

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}