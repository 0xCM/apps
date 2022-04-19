//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ResSeg
    {
        public Identifier Name {get;}

        public MemorySeg Segment {get;}

        [MethodImpl(Inline)]
        public ResSeg(Identifier name, in MemorySeg segment)
        {
            Name = name;
            Segment = segment;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format("{0}[{1}:{2}]", Name, Segment.BaseAddress, Segment.Length);

        public override string ToString()
            => Format();
    }
}