//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System.Runtime.CompilerServices;

    using static Root;

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