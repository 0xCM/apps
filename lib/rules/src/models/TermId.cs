//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TermId
    {
        public uint Identifier {get;}

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public TermId(uint src)
            => Identifier = src;

        [MethodImpl(Inline)]
        public string Format()
            => Identifier.ToString();

        [MethodImpl(Inline)]
        public static implicit operator TermId(uint src)
            => new TermId(src);
    }
}