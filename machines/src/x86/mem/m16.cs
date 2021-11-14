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
    /// Defines a 16-bit memory operand
    /// </summary>
    public struct m16 : IMem16<m16,ushort>
    {
        public ushort Content {get;}

        [MethodImpl(Inline)]
        public m16(ushort src)
            => Content = src;

        [MethodImpl(Inline)]
        public static implicit operator m16(ushort src)
            => new m16(src);

        [MethodImpl(Inline)]
        public static implicit operator ushort(m16 src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator m16(Cell16 src)
            => new m16(src.Content);
    }
}