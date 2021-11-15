//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    public struct u64<T> : IUnsigned<T>
        where T : unmanaged
    {
        public const ulong Width = 64;

        public T Storage;

        [MethodImpl(Inline)]
        public u64(T src)
        {
            Storage = src;
        }

        BitWidth IBlittable.ContentWidth
            => Width;
    }

}