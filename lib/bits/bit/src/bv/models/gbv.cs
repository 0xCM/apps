//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct BV
    {
        public struct gbv<T>
            where T : unmanaged
        {
            public uint Width;

            public T Storage;

            [MethodImpl(Inline)]
            public gbv(uint width, T bits)
            {
                Width = width;
                Storage = bits;
            }
        }
    }
}