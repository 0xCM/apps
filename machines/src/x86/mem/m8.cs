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
    /// Defines an 8-bit memory operand
    /// </summary>
    public struct m8 : IMem8<m8,byte>
    {
        public byte Content {get;}

        [MethodImpl(Inline)]
        public m8(byte src)
            => Content = src;

        [MethodImpl(Inline)]
        public static implicit operator m8(byte src)
            => new m8(src);

        [MethodImpl(Inline)]
        public static implicit operator byte(m8 src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator m8(Cell8 src)
            => new m8(src.Content);
    }
}