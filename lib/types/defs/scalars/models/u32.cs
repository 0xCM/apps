//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.ScalarTypes
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    /// <summary>
    /// Defines an unsigned 32-bit integer over parametric storage
    /// </summary>
    public struct u32<T> : IUnsigned<T>
        where T : unmanaged
    {
        public const uint Width = 32;

        public T Storage;

        [MethodImpl(Inline)]
        public u32(T src)
        {
            Storage = src;
        }

        public string Format()
            => Storage.ToString();

        public override string ToString()
            => Format();

        BitWidth IValue.ContentWidth
            => Width;
    }
}