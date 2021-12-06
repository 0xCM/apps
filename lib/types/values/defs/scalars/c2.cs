//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
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

        BitWidth ISizedValue.ContentWidth
            => Width;
    }

    /// <summary>
    /// Represents a character of width 2
    /// </summary>
    public struct c2 : IChar<byte>
    {
        public const ulong Width = 2;

        public byte Storage;

        public c2(byte src)
        {
            Storage = src;
        }

        public string Format()
            => Storage.ToString();

        public override string ToString()
            => Format();

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}