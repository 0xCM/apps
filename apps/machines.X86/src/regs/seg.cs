//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines
{
    using System;
    using System.Runtime.CompilerServices;

    using Asm;

    using static Root;

    /// <summary>
    /// Represents a segment register
    /// </summary>
    public struct seg
    {
        public SegRegKind Kind {get;}

        public bool IsEmpty => false;

        [MethodImpl(Inline)]
        public seg(SegRegKind src)
        {
            Kind = src;
        }

        public static seg Empty
            => new seg(SegRegKind.CS);
    }
}