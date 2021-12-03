//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.ScalarTypes
{
    public struct u0<T> : IUnsigned<T>
        where T : unmanaged
    {
        public const uint Width = 0;

        BitWidth ISizedType.ContentWidth
            => Width;
    }
}