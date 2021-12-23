//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    public struct u0<T> : IUnsignedInteger<T>
        where T : unmanaged
    {
        public const uint Width = 0;

        BitWidth ISizedValue.ContentWidth
            => Width;
    }
}