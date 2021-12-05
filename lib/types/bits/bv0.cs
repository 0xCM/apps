//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    public struct bv0 : IIndexedBits<byte>
    {
        public const uint Width = 0;

        BitWidth ISizedType.ContentWidth
            => Width;

        public bit this[uint i]
        {
            [MethodImpl(Inline)]
            get => 0;

            [MethodImpl(Inline)]
            set{}
        }
    }

}