//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a 64-bit memory operand
    /// </summary>
    public struct m64 : IMem64<m64,ulong>
    {
        public ulong Content {get;}

        [MethodImpl(Inline)]
        public m64(ulong src)
            => Content = src;

        public DataWidth Width
            => DataWidth.W64;

        [MethodImpl(Inline)]
        public static implicit operator m64(ulong src)
            => new m64(src);

        [MethodImpl(Inline)]
        public static implicit operator ulong(m64 src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator m64(Cell64 src)
            => new m64(src.Content);
    }
}